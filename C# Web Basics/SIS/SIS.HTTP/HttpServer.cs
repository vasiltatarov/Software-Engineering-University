using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SIS.HTTP
{
    public class HttpServer : IHttpServer
    {
        private readonly TcpListener _tcpListener;

        public HttpServer(int port)
        {
            this._tcpListener = new TcpListener(IPAddress.Loopback, port);
        }

        public async Task StartAsync()
        {
            this._tcpListener.Start();
            while (true)
            {
                TcpClient tcpClient = await _tcpListener.AcceptTcpClientAsync();
                await Task.Run(() => ProcessClientAsync(tcpClient));
            }
        }

        public void Stop()
            => this._tcpListener.Stop();

        public async Task ResetAsync()
        {
            this.Stop();
            await this.StartAsync();
        }

        private async Task ProcessClientAsync(TcpClient tcpClient)
        {
            const string NewLine = "\r\n";
            using NetworkStream networkStream = tcpClient.GetStream();
            var requestBytes = new byte[1000000];
            var bytesRead = await networkStream.ReadAsync(requestBytes, 0, requestBytes.Length);
            var request = Encoding.UTF8.GetString(requestBytes, 0, requestBytes.Length);
            var fileContent = Encoding.UTF8.GetBytes("<h1>Hello from vasko server!</h1>");
            var headers = "HTTP/1.0 200 OK" + NewLine +
                          "Server: SoftUniServer/1.0" + NewLine +
                          "Content-Type: text/html" + NewLine +
                          "Content-Length: " + fileContent.Length + NewLine +
                          NewLine;
            var headersBytes = Encoding.UTF8.GetBytes(headers);
            await networkStream.WriteAsync(headersBytes, 0, headersBytes.Length);
            await networkStream.WriteAsync(fileContent, 0, fileContent.Length);

            Console.WriteLine(request);
            Console.WriteLine(new string('=', 70));
        }
    }
}

using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientDemo
{
    /// <summary>
    /// HTTP default port - 80
    /// HTTPS default port - 443
    /// </summary>
    public class Program
    {
        public const string NewLine = "\r\n";

        public static async Task Main(string[] args)
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Loopback, 12345);
            tcpListener.Start();

            while (true)
            {
                var client = await tcpListener.AcceptTcpClientAsync();
                await Task.Run(() => ProcessClientAsync(client));
            }
        }

        private static async Task ProcessClientAsync(TcpClient client)
        {
            using var stream = client.GetStream();

            var buffer = new byte[1000000];
            var length = await stream.ReadAsync(buffer, 0, buffer.Length);

            var requestString = Encoding.UTF8.GetString(buffer, 0, length);

            Console.WriteLine(requestString);

            var html = $"<h1>Hello from VaskoServer {DateTime.UtcNow}</h1>" +
                       $"<form method=post><input name=username /><br /><input name=password/><br />" +
                       $"<input type=submit /></form>";

            //var responce = ResponseStatus200OK(html);
            //var responce = ResponceStatusRedirect(html);
            //var responce = ResponceContentDisposition(html);

            var responce = "HTTP/1.1 200 OK" + NewLine +
                           "Server: VaskoServer 2021" + NewLine +
                           "Content-Type: text/html; charset=utf-8" + NewLine +
                           "Content-Length: " + html.Length + NewLine +
                           NewLine + html + NewLine;

            var responseBytes = Encoding.UTF8.GetBytes(responce);
            await stream.WriteAsync(responseBytes);

            Console.WriteLine(new string('=', 70));
        }

        // Response with download file
        private static string ResponceContentDisposition(string html)
        {
            var responce = "HTTP/1.1 200 OK" + NewLine +
                           "Server: VaskoServer 2021" + NewLine +
                           "Content-Type: text/plain; charset=utf-8" + NewLine +
                           "Content-Disposition: attachment; filename=vasko.txt" + NewLine +
                           "Content-Length: " + html.Length + NewLine +
                           NewLine + html + NewLine;
            return responce;
        }

        //Response with status redirect
        private static string ResponceStatusRedirect(string html)
        {
            var responce = "HTTP/1.1 307 Redirect" + NewLine +
                           "Server: VaskoServer 2021" + NewLine +
                           "Location: https://www.google.com" + NewLine +
                           "Content-Type: text/html; charset=utf-8" + NewLine +
                           "Content-Length: " + html.Length + NewLine +
                           NewLine + html + NewLine;
            return responce;
        }

        // Response with status 200 OK
        private static string ResponseStatus200OK(string html)
        {
            var responce = "HTTP/1.1 200 OK" + NewLine +
                           "Server: VaskoServer 2021" + NewLine +
                           "Content-Type: text/html; charset=utf-8" + NewLine +
                           "Content-Length: " + html.Length + NewLine +
                           NewLine + html + NewLine;
            return responce;
        }

        public static async Task ReadData()
        {
            var url = "https://softuni.bg/";

            HttpClient http = new HttpClient();

            //var html = await http.GetStringAsync(url);
            //Console.WriteLine(html);
            var response = await http.GetAsync(url);

            Console.WriteLine(response.StatusCode);
            Console.WriteLine(string.Join(Environment.NewLine,
                response.Headers
                    .Select(x => x.Key + " " + x.Value.First())));
        }
    }
}

using System.Threading.Tasks;
using SIS.HTTP;

namespace DemoApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var httpServer = new HttpServer(80);
            await httpServer.StartAsync();
        }
    }
}

using System.Threading.Tasks;

namespace SIS.HTTP
{
    public interface IHttpServer
    {
        Task StartAsync();

        void Stop();

        Task ResetAsync();
    }
}

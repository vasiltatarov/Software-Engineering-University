using MyWebServer.Controllers;
using MyWebServer.Http;
using Panda.Services;

namespace Panda.Controllers
{
    public class ReceiptsController : Controller
    {
        private readonly IReceiptService receiptService;

        public ReceiptsController(IReceiptService receiptService) => this.receiptService = receiptService;

        public HttpResponse Index()
        {
            if (!this.User.IsAuthenticated)
            {
                return this.Redirect("/");
            }

            var viewModel = this.receiptService.All();

            return this.View(viewModel);
        }
    }
}

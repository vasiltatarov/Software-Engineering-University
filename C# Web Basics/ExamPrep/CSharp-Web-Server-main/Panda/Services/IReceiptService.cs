using System.Collections.Generic;
using Panda.ViewModels.Receipts;

namespace Panda.Services
{
    public interface IReceiptService
    {
        IEnumerable<ReceiptViewModel> All();
    }
}

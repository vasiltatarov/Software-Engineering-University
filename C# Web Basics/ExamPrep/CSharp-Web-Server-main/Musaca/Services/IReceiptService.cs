using System.Collections.Generic;
using Musaca.ViewModels.Receipts;

namespace Musaca.Services
{
    public interface IReceiptService
    {
        void Create(string userId);

        IEnumerable<ReceiptViewModel> All(string userId);
    }
}

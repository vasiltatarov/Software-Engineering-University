using System.Collections.Generic;
using System.Linq;
using Panda.Data;
using Panda.ViewModels.Receipts;

namespace Panda.Services
{
    public class ReceiptService : IReceiptService
    {
        private readonly ApplicationDbContext data;

        public ReceiptService(ApplicationDbContext data) => this.data = data;

        public IEnumerable<ReceiptViewModel> All()
            => this.data.Receipts
                .Select(x => new ReceiptViewModel
                {
                    Id = x.Id,
                    Recipient = x.Recipient.Username,
                    IssuedOn = x.IssuedOn,
                    Fee = x.Fee,
                })
                .ToList();
    }
}

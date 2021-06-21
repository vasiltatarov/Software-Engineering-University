using System;

namespace Musaca.ViewModels.Receipts
{
    public class ReceiptViewModel
    {
        public string Id { get; set; }

        public decimal Total { get; set; }

        public DateTime IssuedOn { get; set; }

        public string Cashier { get; set; }
    }
}

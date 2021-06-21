using System;
using System.Collections.Generic;
using System.Linq;
using Musaca.Data;
using Musaca.Data.Models;
using Musaca.ViewModels.Receipts;

namespace Musaca.Services
{
    public class ReceiptService : IReceiptService
    {
        private readonly ApplicationDbContext data;

        public ReceiptService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public void Create(string userId)
        {
            var orders = this.data.Orders
                .Where(x => x.CashierId == userId && x.Status == Status.Active);

            if (!orders.Any())
            {
                return;
            }

            var receipt = new Receipt
            {
                IssuedOn = DateTime.Now,
                CashierId = userId,
                Total = orders.Sum(x => x.Product.Price),
            };

            foreach (var order in orders)
            {
                order.Status = Status.Completed;
            }

            this.data.Receipts.Add(receipt);
            this.data.SaveChanges();
        }

        public IEnumerable<ReceiptViewModel> All(string userId)
            => this.data.Receipts
                .Where(x => x.CashierId == userId)
                .Select(x => new ReceiptViewModel
                {
                    Id = x.Id,
                    IssuedOn = x.IssuedOn,
                    Cashier = x.Cashier.Username,
                    Total = x.Total,
                })
                .ToList();
    }
}

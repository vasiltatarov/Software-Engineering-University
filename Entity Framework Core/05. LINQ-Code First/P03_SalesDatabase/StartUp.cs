using Microsoft.EntityFrameworkCore;
using P03_SalesDatabase.Data;
using P03_SalesDatabase.Data.Models;

namespace P03_SalesDatabase
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new SalesContext();
            context.Database.Migrate();

            //var product = new Product()
            //{
            //    Name = "Koza",
            //    Quantity = 10,
            //    Price = 100,
            //    Description = "Shtastlivi balkanski kozi",
            //};

            //var customer = new Customer()
            //{
            //    Name = "Svetlin",
            //    Email = "Svetlin@gmail.com",
            //    CreditCardNumber = "2648997200",
            //};

            //var store = new Store()
            //{
            //    Name = "Gipo.OOD",
            //};

            var sale = new Sale()
            {
                Product = new Product()
                {
                    Name = "Rimsko Pravo",
                    Quantity = 1,
                    Price = 25,
                    Description = "Uchebnik po Rimsko pravo",
                },
                Customer = new Customer()
                {
                    Name = "Donika",
                    Email = "Donikard@gmail.com",
                    CreditCardNumber = "2543547200",
                },
                StoreId = 1,
            };

            //context.Sales.Add(sale);

            context.SaveChanges();
        }
    }
}

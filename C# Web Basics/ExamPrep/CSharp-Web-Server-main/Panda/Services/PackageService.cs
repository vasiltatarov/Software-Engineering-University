using System;
using System.Collections.Generic;
using System.Linq;
using Panda.Data;
using Panda.Data.Models;
using Panda.ViewModels.Packages;
using Panda.ViewModels.Users;

namespace Panda.Services
{
    public class PackageService : IPackageService
    {
        private readonly ApplicationDbContext data;
        private readonly IUserService userService;

        public PackageService(ApplicationDbContext data, IUserService userService)
        {
            this.data = data;
            this.userService = userService;
        }

        public IEnumerable<UserNameViewModel> Users()
            => this.data.Users
                .Select(x => new UserNameViewModel
                {
                    Name = x.Username,
                })
                .ToList();

        public void Add(string description, double weight, string shippingAddress, string recipient)
        {
            var userId = this.userService.GetUserId(recipient);
            if (userId == null)
            {
                return;
            }

            var package = new Package
            {
                Description = description,
                Weight = weight,
                ShippingAddress = shippingAddress,
                RecipientId = userId,
                Status = Status.Pending,
                EstimatedDeliveryDate = DateTime.Now,
            };

            this.data.Packages.Add(package);
            this.data.SaveChanges();
        }

        public IEnumerable<PackageViewModel> AllPending()
            => this.data.Packages
                .Where(x => x.Status == Status.Pending)
                .Select(x => new PackageViewModel
                {
                    Id = x.Id,
                    Description = x.Description,
                    RecipientName = x.Recipient.Username,
                    ShippingAddress = x.ShippingAddress,
                    Weight = x.Weight,
                })
                .ToList();

        public IEnumerable<DeliveredPackageViewModel> AllDelivered()
            => this.data.Packages
                .Where(x => x.Status == Status.Delivered)
                .Select(x => new DeliveredPackageViewModel
                {
                    Description = x.Description,
                    ShippingAddress = x.ShippingAddress,
                    Weight = x.Weight,
                    RecipientName = x.Recipient.Username,
                    Status = Enum.GetName(x.Status),
                })
                .ToList();

        public void DeliveredPackage(string packageId)
        {
            var package = this.data.Packages.FirstOrDefault(x => x.Id == packageId);
            if (package == null)
            {
                return;
            }

            package.Status = Status.Delivered;

            var receipt = new Receipt
            {
                Fee = (decimal) package.Weight * 2.67M,
                IssuedOn = DateTime.Now,
                PackageId = packageId,
                RecipientId = package.RecipientId,
            };

            this.data.Receipts.Add(receipt);
            this.data.SaveChanges();
        }
    }
}

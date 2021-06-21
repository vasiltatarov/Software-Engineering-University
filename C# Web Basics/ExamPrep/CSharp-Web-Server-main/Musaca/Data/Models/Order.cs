using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Musaca.Data.Models
{
    public class Order
    {
        public int Id { get; set; }

        public Status Status { get; set; }

        public DateTime IssuedOn { get; set; }

        [Required]
        public string ProductId { get; set; }

        public virtual Product Product { get; set; }

        [Required]
        public string CashierId { get; set; }

        public virtual User Cashier { get; set; }

        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace Musaca.Data.Models
{
    using static DataConstants;

    public class Receipt
    {
        [Key]
        [Required]
        [MaxLength(IdMaxLength)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public decimal Total { get; set; }

        public DateTime IssuedOn { get; set; }

        public string CashierId { get; set; }

        public virtual User Cashier { get; set; }
    }
}

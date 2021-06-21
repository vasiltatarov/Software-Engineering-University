using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Musaca.Data.Models
{
    using static DataConstants;

    public class Product
    {
        [Key]
        [Required]
        [MaxLength(IdMaxLength)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace Andrey.Data.Models
{
    using static DataConstants;

    public class Product
    {
        [Key]
        [Required]
        [MaxLength(IdMaxLength)]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(ProductMaxName)]
        public string Name { get; set; }
        
        [MaxLength(ProductMaxDescription)]
        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }

        public Category Category { get; set; }

        public Gender Gender { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace FastFood.Core.ViewModels.Items
{
    public class CreateItemInputModel
    {
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}

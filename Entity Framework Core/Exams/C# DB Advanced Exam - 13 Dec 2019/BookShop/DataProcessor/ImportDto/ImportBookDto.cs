using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using BookShop.Data.Models.Enums;

namespace BookShop.DataProcessor.ImportDto
{
    [XmlType("Book")]
    public class ImportBookDto
    {
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Genre")]
        public int Genre { get; set; }

        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        [XmlElement("Price")]
        public decimal Price { get; set; }

        [Range(50, 5000)]
        [XmlElement("Pages")]
        public int Pages { get; set; }

        [Required]
        public string PublishedOn { get; set; }
    }
}

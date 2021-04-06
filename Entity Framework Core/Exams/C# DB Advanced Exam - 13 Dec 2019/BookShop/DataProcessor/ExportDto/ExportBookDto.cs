using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace BookShop.DataProcessor.ExportDto
{
    [XmlType("Book")]
    public class ExportBookDto
    {
        [XmlAttribute("Pages")]
        [Range(50, 5000)]
        public int Pages { get; set; }

        [XmlElement("Name")]
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Name { get; set; }

        [XmlElement("Date")]
        [Required]
        public string Date { get; set; }
    }
}

using System;
using System.Xml.Serialization;

namespace CarDealer.Dtos.Import
{
    [XmlType("Customer")]
    public class CustomerDTO
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("birthDate")]
        public DateTime BirthDate { get; set; }

        [XmlAttribute("isYoungDriver")]
        public bool IsYoungDriver { get; set; }
    }
}

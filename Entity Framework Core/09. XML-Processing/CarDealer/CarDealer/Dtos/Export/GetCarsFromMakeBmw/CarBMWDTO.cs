using System.Xml.Serialization;

namespace CarDealer.Dtos.Export.GetCarsFromMakeBmw
{
    [XmlType("car")]
    public class CarBMWDTO
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("model")]
        public string Model { get; set; }

        [XmlAttribute("travelled-distance")]
        public long TravelledDistance { get; set; }
    }
}

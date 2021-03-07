using System.Xml.Serialization;

namespace CarDealer.Dtos.Export
{
    [XmlType("cars")]
    class CarsAndPartsDTO
    {
        [XmlElement("car")]
        public GetCarDTO Car { get; set; }
    }
}

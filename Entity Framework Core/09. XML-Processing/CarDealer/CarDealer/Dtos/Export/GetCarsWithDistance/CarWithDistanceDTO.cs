﻿using System.Xml.Serialization;

namespace CarDealer.Dtos.Export.GetCarsWithDistance
{
    [XmlType("car")]
    public class CarWithDistanceDTO
    {
        [XmlElement("make")]
        public string Make { get; set; }

        [XmlElement("model")]
        public string Model { get; set; }

        [XmlElement("travelled-distance")]
        public long TravelledDistance { get; set; }
    }
}

﻿using System;
using System.Xml.Serialization;

namespace CarDealer.Dtos.Import
{
    [XmlType("CustomerName")]
    public class CustomerDTO
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("birthDate")]
        public DateTime BirthDate { get; set; }

        [XmlElement("isYoungDriver")]
        public bool IsYoungDriver { get; set; }
    }
}

using System.Collections.Generic;
using Newtonsoft.Json;

namespace CarDealer.DTO.Car
{

    public class CarWithPartsDTO
    {
        [JsonProperty("car")]
        public CarDTO Car { get; set; }

        [JsonProperty("parts")]
        public List<PartDTO> Parts { get; set; }
    }
}

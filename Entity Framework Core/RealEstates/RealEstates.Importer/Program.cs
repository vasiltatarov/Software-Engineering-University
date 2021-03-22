using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using RealEstates.Data;
using RealEstates.Importer.Models;
using RealEstates.Services;

namespace RealEstates.Importer
{
    class Program
    {
        static void Main(string[] args)
        {
            ImportJsonFile("imot.bg-houses-Sofia-raw-data-2021-03-18.json");
            ImportJsonFile("imot.bg-raw-data-2021-03-18.json");
        }

        private static void ImportJsonFile(string fileName)
        {
            var context = new ApplicationDbContext();
            var propertiesService = new PropertiesService(context);

            var inputJson = File.ReadAllText(fileName);
            var properties = JsonSerializer.Deserialize<IEnumerable<ImportPropertyDto>>(inputJson);

            foreach (var dto in properties)
            {
                propertiesService.Add(dto.Size, dto.YardSize, dto.Floor, dto.TotalFloors, dto.District, dto.Year,
                    dto.Type, dto.BuildingType, dto.Price);
            }
        }
    }
}

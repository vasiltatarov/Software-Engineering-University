using System;
using System.Text;
using Microsoft.EntityFrameworkCore;
using RealEstates.Data;
using RealEstates.Services;

namespace RealEstates.ConsoleApplication
{
    /// <summary>
    /// This console app will be the simple UI of the application.
    /// </summary>
    public class Startup
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            var context = new ApplicationDbContext();
            context.Database.Migrate();

            IPropertiesService propertiesService = new PropertiesService(context);
            IDistrictsService districtsService = new DistrictsService(context);

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Choose an option:");
                Console.WriteLine($"1. Property search by price and size:");
                Console.WriteLine($"2. Property search by price:");
                Console.WriteLine($"3. Most expensive districts:");
                Console.WriteLine($"4. Average price per square meter:");
                Console.WriteLine($"0. Exit");

                var input = Console.ReadLine();
                var hasOption = int.TryParse(input, out int option);

                if (hasOption && option == 0)
                {
                    return;
                }

                if (hasOption && option >= 1 && option <= 4)
                {
                    switch (option)
                    {
                        case 1:
                            PropertySearchByPriceAndSize(propertiesService);
                            break;
                        case 2:
                            PropertySearchByPrice(propertiesService);
                            break;
                        case 3:
                            MostExpensiveDistricts(districtsService);
                            break;
                        case 4:
                            AveragePricePerSquareMeter(propertiesService);
                            break;
                    }
                }

                Console.WriteLine($"Press any key to continue:");
                Console.ReadKey();
            }
        }

        private static void AveragePricePerSquareMeter(IPropertiesService propertiesService)
        {
            var avg = propertiesService.AveragePricePerSquareMeter();
            Console.WriteLine($"Average price per square meter: {avg:F2}");
        }

        private static void MostExpensiveDistricts(IDistrictsService districtsService)
        {
            Console.Write($"Count: ");
            var count = int.Parse(Console.ReadLine());

            var districts = districtsService.GetMostExpensiveDistricts(count);

            foreach (var district in districts)
            {
                Console.WriteLine($"{district.Name} => {district.AveragePricePerSquareMeter:F2}€/m² ({district.PropertiesCount})");
            }
        }

        private static void PropertySearchByPriceAndSize(IPropertiesService propertiesService)
        {
            Console.Write($"Min price: ");
            var minPrice = decimal.Parse(Console.ReadLine());
            Console.Write($"Max price: ");
            var maxPrice = decimal.Parse(Console.ReadLine());
            Console.Write($"Min size: ");
            var minSize = int.Parse(Console.ReadLine());
            Console.Write($"Max size: ");
            var maxSize = int.Parse(Console.ReadLine());

            var properties = propertiesService.SearchByPriceAndSize(minPrice, maxPrice, minSize, maxSize);

            foreach (var property in properties)
            {
                Console.WriteLine
                    ($"{property.DistrictName}; {property.BuildingType}; {property.PropertyType} => {property.Price}€ => {property.Size}m²");
            }
        }

        private static void PropertySearchByPrice(IPropertiesService propertiesService)
        {
            Console.Write($"Min price: ");
            var minPrice = decimal.Parse(Console.ReadLine());
            Console.Write($"Max price: ");
            var maxPrice = decimal.Parse(Console.ReadLine());

            var properties = propertiesService.SearchByPrice(minPrice, maxPrice);

            foreach (var property in properties)
            {
                Console.WriteLine
                    ($"{property.DistrictName}; {property.BuildingType}; {property.PropertyType} => {property.Price}€ => {property.Size}m²");
            }
        }
    }
}

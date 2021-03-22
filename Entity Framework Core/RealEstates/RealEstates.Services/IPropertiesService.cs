using System.Collections.Generic;
using RealEstates.Services.Models;

namespace RealEstates.Services
{
    public interface IPropertiesService
    {
        void Add(int size, int yardSize, int floor, int totalFloors, string district, int year, string propertyType, string buildingType, decimal price);

        IEnumerable<PropertyInfoDto> SearchByPrice(decimal minPrice, decimal maxPrice);

        IEnumerable<PropertyInfoDto> SearchByPriceAndSize(decimal minPrice, decimal maxPrice, int minSize, int maxSize);

        IEnumerable<PropertyInfoDto> GetMostExpensiveProperties(int count);

        IEnumerable<PropertyInfoDto> SearchByAllCriterion(string keyword, string type, int? minSquareMeter, int? maxSquareMeter, string buildingType, decimal? minPrice, decimal? maxPrice);

        decimal AveragePricePerSquareMeter();
    }
}

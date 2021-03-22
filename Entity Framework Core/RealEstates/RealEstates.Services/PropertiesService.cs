using System.Collections.Generic;
using System.Linq;
using RealEstates.Data;
using RealEstates.Models;
using RealEstates.Services.Models;

namespace RealEstates.Services
{
    public class PropertiesService : IPropertiesService
    {
        private readonly ApplicationDbContext _context;

        public PropertiesService()
        {
            this._context = new ApplicationDbContext();
        }

        public void Add(int size, int yardSize, int floor, int totalFloors, string district, int year, string propertyType,
            string buildingType, decimal price)
        {
            var districtType = this._context.Districts.FirstOrDefault(x => x.Name == district);
            if (districtType == null)
            {
                districtType = new District() { Name = district, };
            }

            var realEstatePropertyType = this._context.RealEstatePropertyTypes.FirstOrDefault(x => x.Type == propertyType);
            if (realEstatePropertyType == null)
            {
                realEstatePropertyType = new RealEstatePropertyType() { Type = propertyType, };
            }

            var realEstateBuildingType = this._context.BuildingTypes.FirstOrDefault(x => x.Type == buildingType);
            if (realEstateBuildingType == null)
            {
                realEstateBuildingType = new BuildingType() { Type = buildingType, };
            }

            var realEstateProperty = new RealEstatePropertyAd()
            {
                Size = size,
                YardSize = yardSize <= 0 ? null : yardSize,
                Price = price <= 0 ? null : price,
                TotalBuildingFloors = totalFloors <= 0 ? null : totalFloors,
                Floor = floor <= 0 ? null : floor,
                BuildingYear = year <= 0 ? null : year,
                District = districtType,
                RealEstatePropertyType = realEstatePropertyType,
                BuildingType = realEstateBuildingType,
            };

            this._context.RealEstatePropertyAds.Add(realEstateProperty);
            this._context.SaveChanges();
        }

        public IEnumerable<PropertyInfoDto> SearchByPrice(decimal minPrice, decimal maxPrice)
            => this._context.RealEstatePropertyAds
                .Where(x => x.Price.HasValue &&
                            x.Price >= minPrice &&
                            x.Price <= maxPrice)
                .Select(x => new PropertyInfoDto()
                {
                    Size = x.Size,
                    BuildingType = x.BuildingType.Type,
                    DistrictName = x.District.Name,
                    Price = x.Price ?? 0,
                    PropertyType = x.RealEstatePropertyType.Type,
                })
                .ToList();

        public IEnumerable<PropertyInfoDto> SearchByPriceAndSize(decimal minPrice, decimal maxPrice, int minSize, int maxSize)
            => this._context.RealEstatePropertyAds
                .Where(x => x.Price.HasValue &&
                            x.Price >= minPrice &&
                            x.Price <= maxPrice &&
                            x.Size >= minSize &&
                            x.Size <= maxSize)
                .Select(x => new PropertyInfoDto()
                {
                    Size = x.Size,
                    BuildingType = x.BuildingType.Type,
                    DistrictName = x.District.Name,
                    Price = x.Price ?? 0,
                    PropertyType = x.RealEstatePropertyType.Type,
                })
                .ToList();

        public IEnumerable<PropertyInfoDto> GetMostExpensiveProperties(int count)
            => this._context.RealEstatePropertyAds
                .Where(x => x.Price.HasValue)
                .Select(x => new PropertyInfoDto()
                {
                    Size = x.Size,
                    BuildingType = x.BuildingType.Type,
                    DistrictName = x.District.Name,
                    Price = x.Price ?? 0,
                    PropertyType = x.RealEstatePropertyType.Type,
                })
                .OrderByDescending(x => x.Price)
                .Take(count)
                .ToList();

        public IEnumerable<PropertyInfoDto> SearchByAllCriterion(string keyword, string type, int? minSquareMeter, int? maxSquareMeter,
            string buildingType, decimal? minPrice, decimal? maxPrice)
        {
            var properties = this._context.RealEstatePropertyAds
                .Select(x => new PropertyInfoDto()
                {
                    Size = x.Size,
                    BuildingType = x.BuildingType.Type,
                    DistrictName = x.District.Name,
                    Price = x.Price ?? 0,
                    PropertyType = x.RealEstatePropertyType.Type,
                    Year = x.BuildingYear ?? 0,
                    Floor = x.Floor ?? 0,
                    TotalFloor = x.TotalBuildingFloors ?? 0,
                })
                .ToList();

            if (keyword != null)
            {
                properties = properties.Where(x => x.DistrictName.ToLower().Contains(keyword.ToLower())).ToList();
            }
            if (type != null && type != "Всички...")
            {
                properties = properties.Where(x => x.PropertyType == type).ToList();
            }
            if (minSquareMeter.HasValue)
            {
                properties = properties.Where(x => x.Size >= minSquareMeter).ToList();
            }
            if (maxSquareMeter.HasValue)
            {
                properties = properties.Where(x => x.Size <= maxSquareMeter).ToList();
            }
            if (buildingType != null && buildingType != "Всички...")
            {
                properties = properties.Where(x => x.BuildingType == buildingType).ToList();
            }
            if (minPrice.HasValue)
            {
                properties = properties.Where(x => x.Price >= minPrice).ToList();
            }
            if (maxPrice.HasValue)
            {
                properties = properties.Where(x => x.Price <= maxPrice).ToList();
            }

            return properties;
        }

        public decimal AveragePricePerSquareMeter()
            => this._context.RealEstatePropertyAds
                .Where(x => x.Price.HasValue)
                .Average(x => x.Price / x.Size) ?? 0;
    }
}

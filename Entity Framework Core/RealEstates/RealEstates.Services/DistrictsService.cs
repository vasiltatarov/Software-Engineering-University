using System.Collections.Generic;
using System.Linq;
using RealEstates.Data;
using RealEstates.Services.Models;

namespace RealEstates.Services
{
    public class DistrictsService : IDistrictsService
    {
        private readonly ApplicationDbContext _context;

        public DistrictsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<DistrictInfoDto> GetMostExpensiveDistricts(int count)
            => this._context.Districts
                .Select(x => new DistrictInfoDto()
                {
                    Name = x.Name,
                    PropertiesCount = x.RealEstatePropertyAds.Count,
                    AveragePricePerSquareMeter = x.RealEstatePropertyAds
                        .Where(p => p.Price.HasValue)
                        .Average(p => p.Price / p.Size) ?? 0,
                })
                .OrderByDescending(x => x.AveragePricePerSquareMeter)
                .Take(count)
                .ToList();
    }
}

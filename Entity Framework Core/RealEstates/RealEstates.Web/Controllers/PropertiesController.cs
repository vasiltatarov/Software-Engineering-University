using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PagedList;
using RealEstates.Services;
using RealEstates.Services.Models;

namespace RealEstates.Web.Controllers
{
    public class PropertiesController : Controller
    {
        private const int ItemsOnPage = 50;

        private readonly IPropertiesService _propertiesService;

        public PropertiesController(IPropertiesService propertiesService)
        {
            this._propertiesService = propertiesService;
        }

        public IActionResult GetProperties(string keyword, string type,
            int? minSquareMeter, 
            int? maxSquareMeter, 
            string buildingType,
            decimal? minPrice, 
            decimal? maxPrice,
            int page = 1)
        {
            var properties = this._propertiesService.SearchByAllCriterion(keyword, type, minSquareMeter, maxSquareMeter,
                buildingType, minPrice, maxPrice);

            return this.View(properties.ToPagedList(page, ItemsOnPage));
        }
    }
}

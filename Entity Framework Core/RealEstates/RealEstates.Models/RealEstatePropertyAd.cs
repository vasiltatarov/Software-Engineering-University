using System.Collections.Generic;

namespace RealEstates.Models
{
    public class RealEstatePropertyAd
    {
        public RealEstatePropertyAd()
        {
            this.Tags = new HashSet<RealEstatePropertyTag>();
        }

        public int Id { get; set; }
        
        public int Size { get; set; }

        public int? YardSize { get; set; }

        public int? Floor { get; set; }

        public int? TotalBuildingFloors { get; set; }

        public int DistrictId { get; set; }

        public virtual District District { get; set; }

        public int? BuildingYear { get; set; }

        public int RealEstatePropertyTypeId { get; set; }

        public virtual RealEstatePropertyType RealEstatePropertyType { get; set; }

        public int BuildingTypeId { get; set; }

        public virtual BuildingType BuildingType { get; set; }

        /// <summary>
        /// The price is in Euro. 
        /// </summary>
        public decimal? Price { get; set; }

        public virtual ICollection<RealEstatePropertyTag> Tags { get; set; }
    }
}
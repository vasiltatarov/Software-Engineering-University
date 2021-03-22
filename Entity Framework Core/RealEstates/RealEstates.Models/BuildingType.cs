using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RealEstates.Models
{
    public class BuildingType
    {
        public BuildingType()
        {
            this.RealEstatePropertyAds = new HashSet<RealEstatePropertyAd>();
        }

        public int Id { get; set; }

        [Required]
        public string Type { get; set; }

        public virtual ICollection<RealEstatePropertyAd> RealEstatePropertyAds { get; set; }
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RealEstates.Models
{
    public class District
    {
        public District()
        {
            this.RealEstatePropertyAds = new HashSet<RealEstatePropertyAd>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<RealEstatePropertyAd> RealEstatePropertyAds { get; set; }
    }
}

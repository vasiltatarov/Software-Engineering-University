namespace RealEstates.Models
{
    public class RealEstatePropertyTag
    {
        public int RealEstatePropertyAdId { get; set; }

        public virtual RealEstatePropertyAd RealEstatePropertyAd { get; set; }

        public int TagId { get; set; }

        public virtual Tag Tag { get; set; }
    }
}

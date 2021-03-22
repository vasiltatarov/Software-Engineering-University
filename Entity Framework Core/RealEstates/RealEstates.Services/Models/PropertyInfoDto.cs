namespace RealEstates.Services.Models
{
    public class PropertyInfoDto
    {
        public string DistrictName { get; set; }

        public int Size { get; set; }

        public decimal Price { get; set; }

        public string PropertyType { get; set; }

        public string BuildingType { get; set; }

        public int Year { get; set; }

        public int Floor { get; set; }

        public int TotalFloor { get; set; }
    }
}

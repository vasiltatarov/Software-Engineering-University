namespace CarShop.ViewModels.Cars
{
    public class CarViewModel
    {
        public string Id { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public string PictureUrl { get; set; }

        public string PlateNumber { get; set; }

        public string OwnerId { get; set; }

        public int UnfixedIssues { get; set; }

        public int FixedIssues { get; set; }
    }
}

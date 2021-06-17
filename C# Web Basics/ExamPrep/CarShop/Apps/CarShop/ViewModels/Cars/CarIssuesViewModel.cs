namespace CarShop.ViewModels.Cars
{
    using System.Collections.Generic;

    using CarShop.ViewModels.Issues;

    public class CarIssuesViewModel
    {
        public string Id { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public IEnumerable<IssuesViewModel> Issues { get; set; }
    }
}

namespace Facade.Models
{
    public class CarBuilderFacade
    {
        public CarBuilderFacade()
        {
            Car = new Car();
        }

        protected Car Car { get; set; }

        public Car Build() => Car;

        public CarInfoBuilder Info => new CarInfoBuilder(Car);

        public CarAddresBuilder Built => new CarAddresBuilder(Car);
    }
}

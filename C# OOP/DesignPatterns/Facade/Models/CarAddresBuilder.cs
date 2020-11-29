namespace Facade.Models
{
    public class CarAddresBuilder : CarBuilderFacade
    {
        public CarAddresBuilder(Car car)
        {
            Car = car;
        }

        public CarAddresBuilder AtAddress(string address)
        {
            Car.Address = address;
            return this;
        }

        public CarAddresBuilder InCity(string city)
        {
            Car.City = city;
            return this;
        }
    }
}

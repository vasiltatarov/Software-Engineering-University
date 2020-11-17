namespace EasterRaces.Models.Cars.Entities
{
    public class SportsCar : Car
    {
        private const double Default_CubicCentimeters = 3000;
        private const int Min_Horse_Power = 250;
        private const int Max_Horse_Power = 450;

        public SportsCar(string model, int horsePower) 
            : base(model, horsePower, Default_CubicCentimeters, Min_Horse_Power, Max_Horse_Power)
        {
        }
    }
}

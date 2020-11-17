namespace EasterRaces.Models.Cars.Entities
{
    public class MuscleCar : Car
    {
        private const double Default_CubicCentimeters = 5000;
        private const int Min_Horse_Power = 400;
        private const int Max_Horse_Power = 600;

        public MuscleCar(string model, int horsePower)
            : base(model, horsePower, Default_CubicCentimeters, Min_Horse_Power, Max_Horse_Power)
        {
        }
    }
}

﻿namespace P01_Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double DefaultAirConditionerFuelConsumption = 0.9;

        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity, bool hasAirConditioner = true) 
            : base(fuelQuantity, fuelConsumption, tankCapacity, hasAirConditioner)
        {
        }

        public override double AirConditionerFuelConsumption => DefaultAirConditionerFuelConsumption;
    }
}

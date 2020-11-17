using System;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Models.Cars.Entities
{
    public abstract class Car : ICar
    {
        private const int Default_Model_Symbol = 4;
        private string model;
        private int horsePower;

        protected Car(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {
            this.MinHorsePower = minHorsePower;
            this.MaxHorsePower = maxHorsePower;
            this.Model = model;
            this.HorsePower = horsePower;
            this.CubicCentimeters = cubicCentimeters;
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < Default_Model_Symbol)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidModel, value, Default_Model_Symbol));
                }

                this.model = value;
            }
        }

        public int HorsePower
        {
            get
            {
                return this.horsePower;
            }
            private set
            {
                if (value < this.MinHorsePower || value > this.MaxHorsePower)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, value));
                }

                this.horsePower = value;
            }
        }

        public double CubicCentimeters { get; private set; }

        public int MinHorsePower { get; }

        public int MaxHorsePower { get; }

        public double CalculateRacePoints(int laps)
            => this.CubicCentimeters / this.HorsePower * laps;
    }
}

using System.Collections.Generic;
using System.Linq;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> data;
        private int capacity;

        public Parking(int capacity)
        {
            this.capacity = capacity;
            this.data = new List<Car>();
        }

        public int Count => this.data.Count;

        public string AddCar(Car car)
        {
            if (this.data.Any(x => x.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }

            if (this.data.Count >= this.capacity)
            {
                return "Parking is full!";
            }

            this.data.Add(car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        public string RemoveCar(string registrationNumber)
        {
            Car found = null;

            foreach (var car in this.data)
            {
                if (car.RegistrationNumber == registrationNumber)
                {
                    found = car;
                }
            }

            if (found == null)
            {
                return "Car with that registration number, doesn't exist!";
            }

            this.data.Remove(found);
            return $"Successfully removed {registrationNumber}";
        }

        public Car GetCar(string RegistrationNumber)
        {
            foreach (var car in this.data)
            {
                if (car.RegistrationNumber == RegistrationNumber)
                {
                    return car;
                }
            }

            return null;
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var registration in registrationNumbers)
            {
                this.RemoveCar(registration);
            }
        }
    }
}

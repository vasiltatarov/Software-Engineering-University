using System;
using CarManager;
using NUnit.Framework;

namespace Tests
{
    public class CarTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorSholdWorksCorrectly()
        {
            var car = new Car("Germany", "BMW", 10, 45);

            Assert.AreEqual(car.Make, "Germany");
            Assert.AreEqual(car.Model, "BMW");
            Assert.AreEqual(car.FuelConsumption, 10);
            Assert.AreEqual(car.FuelCapacity, 45);
            Assert.AreEqual(car.FuelAmount, 0);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void MakePropertyShouldThrownExceptionWithInvalidData(string make)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new Car(make, "BMW", 10, 45);
            });
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ModelPropertyShouldThrownExceptionWithInvalidData(string model)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new Car("Germany", model, 10, 45);
            });
        }

        [Test]
        [TestCase(-14)]
        [TestCase(0)]
        public void FuelConsumptionPropertyShouldThrownExceptionWithInvalidData(double fuelConsumption)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new Car("Germany", "BMW", fuelConsumption, 45);
            });
        }

        [Test]
        [TestCase(-14)]
        [TestCase(0)]
        public void FuelCapacityPropertyShouldThrownExceptionWithInvalidData(double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new Car("Germany", "BMW", 10, fuelCapacity);
            });
        }

        [Test]
        [TestCase(12)]
        public void RefuelMethodShouldWorksCorrectly(double fuelToRefuel)
        {
            var car = new Car("Germany", "BMW", 10, 45);
            car.Refuel(fuelToRefuel);

            Assert.AreEqual(car.FuelAmount, 12);
        }

        [Test]
        [TestCase(70)]
        public void RefuelMethodShouldWorksCorrectlyWithMoreFuelToRefuel(double fuelToRefuel)
        {
            var car = new Car("Germany", "BMW", 10, 45);
            var expectedFuelAmount = car.FuelCapacity;
            car.Refuel(fuelToRefuel);

            Assert.AreEqual(car.FuelAmount, expectedFuelAmount);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-12)]
        public void RefuelMethodShouldThrownExceptionWithNegativeAmountToRefuel(double fuelToRefuel)
        {
            var car = new Car("Germany", "BMW", 10, 45);

            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(fuelToRefuel);
            });
        }

        [Test]
        [TestCase(50)]
        public void DriveMethodShouldWorksCorrectly(double distance)
        {
            var initialFuel = 20;

            var car = new Car("Germany", "BMW", 10, 45);
            car.Refuel(initialFuel);
            car.Drive(distance);

            Assert.AreNotEqual(initialFuel, car.FuelAmount);
        }

        [Test]
        [TestCase(50)]
        public void DriveMethodShouldThrownExceptionWithNotEnoughFuealAmount(double distance)
        {
            var car = new Car("Germany", "BMW", 10, 45);

            Assert.Throws<InvalidOperationException>(() =>
            {
                car.Drive(distance);
            });
        }
    }
}
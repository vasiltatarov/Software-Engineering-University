using System;
using NUnit.Framework;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private RaceEntry driver;

        [SetUp]
        public void Setup()
        {
            this.driver = new RaceEntry();
        }

        [Test]
        public void ConstructorShouldWorkCorrectly()
        {
            Assert.AreEqual(this.driver.Counter, 0);
        }

        [Test]
        public void AddDriverShouldThrownExceptionWihNullDriver()
        {
            UnitDriver driver = null;

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.driver.AddDriver(driver);
            });
        }

        [Test]
        public void AddDriverShouldThrownExceptionWihAlreadyExistDriver()
        {
            UnitCar car = new UnitCar("bmw", 12, 23);
            UnitDriver driver = new UnitDriver("vasko", car);

            this.driver.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.driver.AddDriver(driver);
            });
        }

        [Test]
        public void AddDriverShouldWorksCorrectly()
        {
            UnitCar car = new UnitCar("bmw", 12, 23);
            UnitDriver driver = new UnitDriver("vasko", car);

            var result = this.driver.AddDriver(driver);

            Assert.AreEqual(this.driver.Counter, 1);
            Assert.AreEqual(result, $"Driver {driver.Name} added in race.");
        }

        [Test]
        public void CalculateAverageHorsePowerShouldThrownExceptionWithNotEnoughParticipants()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.driver.CalculateAverageHorsePower();
            });
        }

        [Test]
        public void CalculateAverageHorsePowerShouldWorksCorrectly()
        {
            UnitCar car = new UnitCar("bmw", 100, 23);
            UnitDriver driver = new UnitDriver("vasko", car);
            UnitCar car1 = new UnitCar("ford", 100, 324);
            UnitDriver driver1 = new UnitDriver("nasko", car1);

            this.driver.AddDriver(driver);
            this.driver.AddDriver(driver1);

            var result = this.driver.CalculateAverageHorsePower();

            Assert.AreEqual(result, 100);
        }
    }
}
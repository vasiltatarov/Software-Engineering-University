using NUnit.Framework;

namespace Robots.Tests
{
    using System;

    [TestFixture]
    public class RobotsTests
    {
        private Robot robot;
        private RobotManager robotManager;

        [SetUp]
        public void TestInit()
        {
            this.robot = new Robot("vasko", 100);
            this.robotManager = new RobotManager(10);
        }

        [Test]
        public void TestConstructorRobot()
        {
            Assert.AreEqual(this.robot.Name, "vasko");
            Assert.AreEqual(this.robot.MaximumBattery, 100);
            Assert.AreEqual(this.robot.Battery, 100);
        }

        [Test]
        public void TestConstructorRobotManager()
        {
            Assert.AreEqual(this.robotManager.Capacity, 10);
            Assert.AreEqual(this.robotManager.Count, 0);
        }

        [Test]
        [TestCase(-12)]
        public void CapacityShouldThrownExceptionWithNegativeValue(int capacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.robotManager = new RobotManager(capacity);
            });
        }

        [Test]
        public void AddRobotShouldWorkCorrectly()
        {
            this.robotManager.Add(this.robot);

            Assert.AreEqual(this.robotManager.Count, 1);
        }

        [Test]
        public void AddRobotShouldThrownExceptionWithExistingRobot()
        {
            this.robotManager.Add(this.robot);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.robotManager.Add(this.robot);
            });
        }

        [Test]
        public void AddRobotShouldThrownExceptionWithExistingNotEnoughCapacity()
        {
            this.robotManager = new RobotManager(0);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.robotManager.Add(this.robot);
            });
        }

        [Test]
        [TestCase("vasko")]
        public void RemoveRobotShouldWorkCorrectly(string name)
        {
            this.robotManager.Add(this.robot);

            Assert.AreEqual(this.robotManager.Count, 1);

            this.robotManager.Remove(name);

            Assert.AreEqual(this.robotManager.Count, 0);
        }

        [Test]
        [TestCase("nasko")]
        public void RemoveRobotShouldThrownExceptionWithNonExistingRobot(string name)
        {
            this.robotManager.Add(this.robot);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.robotManager.Remove(name);
            });
        }

        [Test]
        [TestCase("nasko")]
        public void WorkShouldThrownExceptionWithNonExistingRobot(string name)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.robotManager.Work(name, "IT", 20);
            });
        }

        [Test]
        [TestCase("vasko")]
        public void WorkShouldThrownExceptionWithNotEnoughBattery(string name)
        {
            this.robotManager.Add(this.robot);
            var batteryUsage = 200;

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.robotManager.Work(name, "IT", batteryUsage);
            });
        }

        [Test]
        [TestCase("vasko")]
        public void WorkShouldWorkCorrectly(string name)
        {
            this.robotManager.Add(this.robot);

            var batteryUsage = 20;

            this.robotManager.Work(name, "IT", batteryUsage);

            Assert.AreEqual(this.robot.Battery, 80);
        }

        [Test]
        [TestCase("vasko")]
        public void ChargeShouldWorkCorrectly(string name)
        {
            this.robotManager.Add(this.robot);

            this.robotManager.Work(name, "IT", 50);

            Assert.AreEqual(50, this.robot.Battery);

            this.robotManager.Charge(name);

            Assert.AreEqual(100, this.robot.Battery);
        }

        [Test]
        [TestCase("nasko")]
        public void ChargeShouldThrownException(string name)
        {
            this.robotManager.Add(this.robot);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.robotManager.Charge(name);
            });
        }
    }
}

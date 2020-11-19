using System;
using NUnit.Framework;

namespace Computers.Tests
{
    public class Tests
    {
        private ComputerManager computerManager;
        private Computer computer;

        [SetUp]
        public void Setup()
        {
            this.computer = new Computer("Test", "abc", 10);
            this.computerManager = new ComputerManager();
        }

        [Test]
        public void AddMethodShouldThrowNullExceptionWhenVariableIsNull()
        {
            Computer testComputer = null;
            Assert.Throws<ArgumentNullException>(()
                => this.computerManager.AddComputer(testComputer));
        }

        [Test]
        public void AddMethodShouldThrowExceptionWhenAddSameComputer()
        {
            computerManager.AddComputer(computer);
            Assert.Throws<ArgumentException>(()
                => computerManager.AddComputer(computer));
        }

        [Test]
        public void AddMethodShouldWorkCorrectly()
        {
            computerManager.AddComputer(computer);

            var exp = 1;
            Assert.AreEqual(exp, this.computerManager.Count);
        }

        [Test]
        public void RemoveMethodShouldThrowNullExceptionWhenManufacturerIsNull()
        {
            this.computerManager.AddComputer(this.computer);

            Assert.Throws<ArgumentNullException>(() => this.computerManager.RemoveComputer(null, "a"));
        }

        [Test]
        public void RemoveMethodShouldThrowNullExceptionWhenModelIsNull()
        {
            this.computerManager.AddComputer(this.computer);

            Assert.Throws<ArgumentNullException>(() => this.computerManager.RemoveComputer("sony", null));
        }

        [Test]
        public void RemoveMethodShouldWorkCorectlly()
        {
            this.computerManager.AddComputer(this.computer);
            var test = this.computerManager.RemoveComputer("Test", "abc");
            Assert.That(test.Model == "abc" && test.Manufacturer == "Test");
        }

        [Test]
        public void GetComputerShouldThrowExcpetionWhenManufacturerIsNull()
        {
            Assert.Throws<ArgumentNullException>(()
                => this.computerManager.GetComputer(null, "abc"));
        }

        [Test]
        public void GetComputerShouldThrowExcpetionWhenModelIsNull()
        {
            Assert.Throws<ArgumentNullException>(()
                => this.computerManager.GetComputer("Test", null));
        }

        [Test]
        public void GetComputerShouldThrowExceptionWhenComputerIsNull()
        {
            Assert.Throws<ArgumentException>(()
                => this.computerManager.GetComputer("abc", "abc"));
        }

        [Test]
        public void GetComputerShouldWorkCorectlly()
        {
            this.computerManager.AddComputer(computer);
            var test = this.computerManager.GetComputer("Test", "abc");
            Assert.That(test == computer);
        }

        [Test]
        public void GetComputersShouldThrowExceptionWhenManufacturerIsNull()
        {
            Assert.Throws<ArgumentNullException>(()
                => this.computerManager.GetComputersByManufacturer(null));
        }

        [Test]
        public void GetComputersShouldWorkCorrectly()
        {
            this.computerManager.AddComputer(computer);
            this.computerManager.AddComputer(new Computer("a", "a", 10));

            var exp = 1;
            Assert.AreEqual(exp, this.computerManager.GetComputersByManufacturer("a").Count);

        }
    }
}
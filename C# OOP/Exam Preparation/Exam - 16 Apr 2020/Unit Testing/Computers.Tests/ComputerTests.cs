using System;

namespace Computers.Tests
{
    using NUnit.Framework;

    public class ComputerTests
    {
        private Computer computer;

        [SetUp]
        public void Setup()
        {
            this.computer = new Computer("HP");
        }

        [Test]
        [TestCase("HP")]
        public void ConstructorShouldInitializeComputerCorrectly(string name)
        {
            Assert.AreEqual(this.computer.Name, name);
            Assert.AreEqual(this.computer.Parts.Count, 0);
            Assert.AreEqual(this.computer.TotalPrice, 0);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        [TestCase("  ")]
        public void NamePropertyShouldThrownExceptionWithInvalidData(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                this.computer = new Computer(name);
            });
        }

        [Test]
        public void AddPartShouldWorkCorrectly()
        {
            var part = new Part("test", 12);
            var part1 = new Part("test1", 122);

            this.computer.AddPart(part);
            this.computer.AddPart(part1);

            Assert.AreEqual(this.computer.Parts.Count, 2);
        }

        [Test]
        public void AddPartShouldThrownExceptionWithNullParts()
        {
            Part part = null;

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.computer.AddPart(part);
            });
        }

        [Test]
        public void TotalPriceShouldWorkCorrectly()
        {
            var part = new Part("test", 10);
            var part1 = new Part("test1", 10);

            this.computer.AddPart(part);
            this.computer.AddPart(part1);

            var expected = part1.Price + part.Price;

            Assert.AreEqual(expected, this.computer.TotalPrice);
        }

        [Test]
        public void RemovePartShouldReturnTrueWhenRemoveSuccessfully()
        {
            var part = new Part("test", 10);
            var part1 = new Part("test1", 10);

            this.computer.AddPart(part);
            this.computer.AddPart(part1);

            Assert.AreEqual(this.computer.Parts.Count, 2);

            var result =this.computer.RemovePart(part);

            Assert.AreEqual(this.computer.Parts.Count, 1);
            Assert.AreEqual(result, true);
        }

        [Test]
        public void RemovePartShouldReturnFalseWhenNotRemoveSuccessfully()
        {
            var part = new Part("test", 10);
            var part1 = new Part("test1", 10);

            this.computer.AddPart(part);

            Assert.AreEqual(this.computer.Parts.Count, 1);

            var result = this.computer.RemovePart(part1);

            Assert.AreEqual(this.computer.Parts.Count, 1);
            Assert.AreEqual(result, false);
        }

        [Test]
        public void GetPartShouldWorkCorrectly()
        {
            var part = new Part("test", 10);
            var part1 = new Part("test1", 10);

            this.computer.AddPart(part);
            this.computer.AddPart(part1);

            var result = this.computer.GetPart(part.Name);

            Assert.AreSame(result, part);
        }

        [Test]
        [TestCase("nema")]
        public void GetPartShouldReturnNull(string partName)
        {
            var part = new Part("test", 10);
            var part1 = new Part("test1", 10);

            this.computer.AddPart(part);
            this.computer.AddPart(part1);

            var result = this.computer.GetPart(partName);

            Assert.AreEqual(result, null);
        }

        [Test]
        public void GetPartShouldReturnNull()
        {
            var part = new Part("test", 10);
            var part1 = new Part("test1", 10);
            var part2 = new Part("test2", 11);

            this.computer.AddPart(part);
            this.computer.AddPart(part1);
            this.computer.AddPart(part2);

            var result = this.computer.Parts;

            Assert.AreEqual(result.Count, 3);
        }
    }
}
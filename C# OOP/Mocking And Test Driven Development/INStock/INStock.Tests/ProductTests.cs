using INStock.Models;

namespace INStock.Tests
{
    using NUnit.Framework;

    public class ProductTests
    {
        private Product firstProduct;

        [SetUp]
        public void TestInit()
        {
            this.firstProduct = new Product("vafla", 0.50m, 1);
        }

        [Test]
        public void TestConstructor()
        {
            Assert.AreEqual(this.firstProduct.Label, "vafla");
            Assert.AreEqual(this.firstProduct.Price, 0.50m);
            Assert.AreEqual(this.firstProduct.Quantity, 1);
        }

        [Test]
        public void TestCompareToMethodShouldReturnZero()
        {
            var otherProduct = new Product("vafla", 0.70m, 34);

            Assert.AreEqual(this.firstProduct.CompareTo(otherProduct), 0);
        }

        [Test]
        public void TestCompareToMethodShouldReturnDifferentByZero()
        {
            var otherProduct = new Product("pasta", 0.70m, 34);

            Assert.AreNotEqual(this.firstProduct.CompareTo(otherProduct), 0);
        }
    }
}
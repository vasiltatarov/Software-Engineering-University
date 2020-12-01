using System;
using NUnit.Framework;

namespace Store.Tests
{
    public class StoreManagerTests
    {
        private Product _product;
        private StoreManager _storeManager;

        [SetUp]
        public void Setup()
        {
            _product = new Product("vafla", 1, 2);
            _storeManager = new StoreManager();
        }

        [Test]
        public void ProductShouldBeInitializeWithCorrectProperties()
        {
            Assert.AreEqual(_product.Name, "vafla");
            Assert.AreEqual(_product.Quantity, 1);
            Assert.AreEqual(_product.Price, 2);
        }

        [Test]
        public void StoreManagerShouldBeInitializeCorrectly()
        {
            Assert.AreEqual(_storeManager.Products.Count, 0);
            Assert.AreEqual(_storeManager.Count, 0);
        }

        [Test]
        public void AddProductShouldThrownExceptionWhenTryToAddNullProduct()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                _storeManager.AddProduct(null);
            });
        }

        [Test]
        [TestCase(-324)]
        [TestCase(0)]
        public void AddProductShouldThrownExceptionWhenTryToAddProductWithNegativeQuantity(int quantity)
        {
            _product.Quantity = quantity;

            Assert.Throws<ArgumentException>(() =>
            {
                _storeManager.AddProduct(_product);
            });
        }

        [Test]
        public void AddProductShouldAddNewProductCorrectly()
        {
            _storeManager.AddProduct(_product);

            Assert.AreEqual(_storeManager.Count, 1);
            Assert.AreEqual(_storeManager.Products.Count, 1);
        }

        [Test]
        [TestCase("Invalid")]
        public void BuyProductShouldThrownExceptionWhenNotExistProduct(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                _storeManager.BuyProduct(name, 1);
            });
        }

        [Test]
        [TestCase("vafla", 10)]
        [TestCase("vafla", 2)]
        public void BuyProductShouldThrownExceptionWhenProductQuantityIsNegative(string name, int quantity)
        {
            _storeManager.AddProduct(_product);

            Assert.Throws<ArgumentException>(() =>
            {
                _storeManager.BuyProduct(name, quantity);
            });
        }

        [Test]
        [TestCase("vafla", 3)]
        public void BuyProductShouldWorkCorrectlyWithValidData(string name, int quantity)
        {
            //Arrange
            _product.Quantity = 5;
            _storeManager.AddProduct(_product);

            //Act
            var price = _storeManager.BuyProduct(name, quantity);

            var expectedPrice = quantity * _product.Price;
            var expectedProductQuantity = 2;

            //Assert
            Assert.AreEqual(expectedPrice, price);
            Assert.AreEqual(expectedProductQuantity, _product.Quantity);
        }

        [Test]
        public void GetTheMostExpensiveProductShouldReturnNull()
        {
            var expectedProduct = _storeManager.GetTheMostExpensiveProduct();

            Assert.AreEqual(expectedProduct, null);
        }

        [Test]
        public void GetTheMostExpensiveProductShouldReturnMostExpensiveProduct()
        {
            //Arrange
            _storeManager.AddProduct(_product);
            _storeManager.AddProduct(new Product("Bicycle", 12, 250));

            //Act
            var expectedProductPrice = _storeManager.GetTheMostExpensiveProduct();

            //Assert
            Assert.AreEqual(expectedProductPrice.Price, 250);
        }
    }
}
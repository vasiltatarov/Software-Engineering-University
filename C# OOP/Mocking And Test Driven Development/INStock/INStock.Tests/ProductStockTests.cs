using System;
using System.Collections.Generic;
using System.Linq;
using INStock.Contracts;
using INStock.Models;

namespace INStock.Tests
{
    using NUnit.Framework;

    public class ProductStockTests
    {
        private ProductStock products;
        private Product product;

        [SetUp]
        public void TestInit()
        {
            this.products = new ProductStock();
            this.product = new Product("vafla", 0.50m, 1);
            this.products.Add(this.product);
        }

        [Test]
        public void AddMethodShouldAddNewProductSuccessfully()
        {
            var otherProduct = new Product("pasta", 0.50m, 1);
            this.products.Add(otherProduct);

            Assert.AreEqual(this.products.Count, 2);
        }

        [Test]
        public void AddMethodShouldThrownExceptionIfTryToAddDuplicatesProduct()
        {
            Assert.Throws<InvalidOperationException>(() => { this.products.Add(this.product); });
        }

        [Test]
        public void ContainsMethodShouldReturnTrueIfProductExist()
        {
            var isContains = this.products.Contains(this.product);

            Assert.AreEqual(isContains, true);
        }

        [Test]
        public void ContainsMethodShouldReturnFalseIfProductExist()
        {
            var fakeProduct = new Product("Nqma", 1, 1);
            var isContains = this.products.Contains(fakeProduct);

            Assert.AreEqual(isContains, false);
        }

        [Test]
        public void RemoveMethodShouldReturnTrueIfProductExist()
        {
            var result = this.products.Remove(this.product);

            Assert.AreEqual(this.products.Count, 0);
            Assert.AreEqual(result, true);
        }

        [Test]
        public void RemoveMethodShouldReturnFalseIfProductNotExist()
        {
            var fakeProduct = new Product("nema", 1, 2);
            var result = this.products.Remove(fakeProduct);

            Assert.AreEqual(this.products.Count, 1);
            Assert.AreEqual(result, false);
        }

        [Test]
        public void CountMethodShouldWorksCorrectly()
        {
            this.products.Add(new Product("test", 2, 2));
            this.products.Add(new Product("test1", 2, 2));

            Assert.AreEqual(this.products.Count, 3);
        }

        [Test]
        [TestCase(1)]
        public void FindMethodShouldReturnNthProductInTheCollection(int index)
        {
            var productToReturn = new Product("test", 2, 2);
            this.products.Add(productToReturn);

            var returnedProduct = this.products.Find(index);

            Assert.AreEqual(returnedProduct.CompareTo(productToReturn), 0);
        }

        [Test]
        [TestCase(10)]
        public void FindMethodShouldThrownExceptionWithInvalidIndex(int index)
        {
            Assert.Throws<IndexOutOfRangeException>(() => { this.products.Find(index); });
        }

        [Test]
        [TestCase("vafla")]
        public void FindByLabelWithGivenLabel(string label)
        {
            var expectedProduct = this.products.FindByLabel(label);

            Assert.AreEqual(expectedProduct.CompareTo(this.product), 0);
        }

        [Test]
        [TestCase("nema")]
        public void FindByLabelShouldThrownExceptionIfNoSuchProductInStocks(string label)
        {
            Assert.Throws<ArgumentException>(() => { this.products.FindByLabel(label); });
        }

        [Test]
        public void FindAllInPriceRangeShouldReturnCorrectResultInDescending()
        {
            this.products.Add(new Product("test", 1, 2));
            this.products.Add(new Product("test1", 2, 2));

            var result = this.products.FindAllInRange(0.80m, 3.0m).ToArray();

            Assert.AreEqual(result.Length, 2);
            Assert.AreEqual(result[0].Price, 2);
            Assert.AreEqual(result[1].Price, 1);
        }

        [Test]
        public void FindAllInPriceRangeShouldReturnEmptyCollection()
        {
            var result = this.products.FindAllInRange(0.80m, 3.0m).ToArray();

            Assert.AreEqual(result.Length, 0);
        }

        [Test]
        [TestCase(0.50)]
        public void FindAllByPriceShouldReturnAllProductWithGivenPrice(decimal price)
        {
            this.products.Add(new Product("pasta", 0.50m, 12));

            var result = this.products.FindAllByPrice(price).ToArray();

            Assert.AreEqual(result.Length, 2);
        }

        [Test]
        [TestCase(0.80)]
        public void FindAllByPriceShouldReturnEmptyCollection(decimal price)
        {
            var result = this.products.FindAllByPrice(price).ToArray();

            Assert.AreEqual(result.Length, 0);
        }

        [Test]
        public void FindMostExpensiveProductsShouldWorkCorrectly()
        {
            var test = new Product("pasta", 4.50m, 25);
            this.products.Add(test);

            var result = this.products.FindMostExpensiveProduct();

            Assert.AreEqual(result.CompareTo(test), 0);
        }

        [Test]
        public void FindMostExpensiveProductsShouldReturnNullIfCollectionIsEmpty()
        {
            var newProducts = new ProductStock();

            var result = newProducts.FindMostExpensiveProduct();

            Assert.AreEqual(result, null);
        }

        [Test]
        [TestCase(1)]
        public void FindAllByQuantityShouldReturnAllWithGivenQuantity(int quantity)
        {
            var test = new Product("pasta", 4.50m, 1);
            this.products.Add(test);

            var result = this.products.FindAllByQuantity(quantity).ToArray();

            Assert.AreEqual(result.Length, 2);
        }

        [Test]
        [TestCase(10)]
        public void FindAllByQuantityShouldReturnEmptyCollection(int quantity)
        {
            var result = this.products.FindAllByQuantity(quantity).ToArray();

            Assert.AreEqual(result.Length, 0);
        }

        [Test]
        public void GetEnumeratorShouldReturnWholeCollection()
        {
            this.products.Add(new Product("test", 1, 2));
            this.products.Add(new Product("test1", 2, 2));

            var expectedCollection = new List<IProduct>();

            foreach (var product in this.products)
            {
                expectedCollection.Add(product);
            }

            CollectionAssert.AreEqual(expectedCollection, this.products);
        }

        [Test]
        [TestCase(0)]
        public void thisGetterShouldReturnProductInGivenIndex(int index)
        {
            var result = this.products[index];

            Assert.AreEqual(result.CompareTo(this.product), 0);
        }

        [Test]
        [TestCase(10)]
        public void thisGetterShouldThrownExceptionWithInvalidIndex(int index)
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                var result = this.products[index];
            });
        }

        [Test]
        [TestCase(0)]
        public void thisSetterShouldChangeProductOnGivenIndex(int index)
        {
            var newProduct = new Product("Nema", 1, 2);
            this.products[index] = newProduct;

            Assert.AreEqual(this.products[index].CompareTo(newProduct), 0);
        }

        [Test]
        [TestCase(10)]
        public void thisSetterShouldThrownExceptionWithInvalidIndex(int index)
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                this.products[index] = new Product("Nema", 1, 2);
            });
        }
    }
}

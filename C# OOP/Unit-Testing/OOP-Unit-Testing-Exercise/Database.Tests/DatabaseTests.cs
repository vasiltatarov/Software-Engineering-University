using System;
using NUnit.Framework;

namespace Tests
{
    public class DatabaseTests
    {
        private readonly int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };

        private Database.Database data;

        [SetUp]

        public void Setup()
        {
            this.data = new Database.Database(arr);
        }

        [Test]
        public void ConstructorShouldWorkCorrectly()
        {
            Assert.That(this.data.Count, Is.EqualTo(16));
        }

        [Test]
        public void ConstructorShouldThrowExceptionWithInvalidElements()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.data.Add(544);
            });
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3 })]
        public void AddOperationShouldWorksCorrectly(int[] data)
        {
            this.data = new Database.Database(data);

            var count = this.data.Count;
            this.data.Add(544);

            Assert.AreEqual(this.data.Count, count + 1);
        }

        [Test]
        public void AddOperationShouldThrowExceptionIfTryToPutMoreElements()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.data.Add(324);
            });
        }

        [Test]
        public void RemoveOperationShouldRemovingElementAtLastIndex()
        {
            var currCount = this.data.Count;
            this.data.Remove();

            Assert.AreEqual(this.data.Count, currCount - 1);
        }

        [Test]
        [TestCase(new int[] { 1 })]
        public void RemoveOperationShouldThrownExceptionIfEmpty(int[] data)
        {
            this.data = new Database.Database(data);
            this.data.Remove();

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.data.Remove();
            });
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        [TestCase(new int[] { })]
        public void FetchMethodShouldWorksCorrectly(int[] data)
        {
            this.data = new Database.Database(data);

            var actualData = this.data.Fetch();

            CollectionAssert.AreEqual(data, actualData);
        }
    }
}
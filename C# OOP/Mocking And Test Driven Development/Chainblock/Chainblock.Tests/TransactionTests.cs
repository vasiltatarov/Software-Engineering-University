namespace _Chainblock.Tests
{
    using System;
    using NUnit.Framework;
    using Models;

    public class TransactionTests
    {
        [Test]
        public void ConstructorShouldWorksCorrectly()
        {
            var id = 1;
            var status = TransactionStatus.Aborted;
            var from = "gosho";
            var to = "pesho";
            var amount = 500;
            var tr = new Transaction(id, status, from, to, amount);

            Assert.AreEqual(id, tr.Id);
            Assert.AreEqual(status, tr.Status);
            Assert.AreEqual(from, tr.From);
            Assert.AreEqual(to, tr.To);
            Assert.AreEqual(amount, tr.Amount);
        }

        [Test]
        [TestCase(-21)]
        [TestCase(0)]
        public void IdPropertyShouldThrownExceptionWithZeroOrNegativeData(int id)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                new Transaction(id, TransactionStatus.Aborted, "gosho", "pesho", 500);
            });
        }

        [Test]
        [TestCase(null)]
        [TestCase("    ")]
        [TestCase("")]
        public void FromPropertyShouldThrownExceptionWithInvaWithNullOrEmptyData(string from)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                new Transaction(14, TransactionStatus.Aborted, from, "pesho", 500);
            });
        }

        [Test]
        [TestCase(null)]
        [TestCase("    ")]
        [TestCase("")]
        public void ToPropertyShouldThrownExceptionWithInvaWithNullOrEmptyData(string to)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                new Transaction(14, TransactionStatus.Aborted, "pesho", to, 500);
            });
        }

        [Test]
        [TestCase(-21)]
        [TestCase(0)]
        public void AmountPropertyShouldThrownExceptionWithZeroOrNegativeData(double amount)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                new Transaction(56, TransactionStatus.Aborted, "gosho", "pesho", amount);
            });
        }
    }
}

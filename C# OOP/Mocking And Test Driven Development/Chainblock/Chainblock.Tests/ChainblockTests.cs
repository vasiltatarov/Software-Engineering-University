using System;
using System.Linq;
using _Chainblock.Models;
using _Chainblock.Models.Contracts;
using NUnit.Framework;

namespace _Chainblock.Tests
{
    public class ChainblockTests
    {
        private Chainblock chainblock;

        [SetUp]
        public void TestInit()
        {
            this.chainblock = new Chainblock();
        }

        [Test]
        public void ConstructorShouldWorksCorrectly()
        {
            var expectedCount = 0;

            Assert.AreEqual(expectedCount, this.chainblock.Count);
        }

        [Test]
        public void AddShoudlWorksCorrectly()
        {
            var expectedCount = 1;

            this.chainblock.Add(new Transaction(1, TransactionStatus.Aborted, "vasko", "pesho", 230));

            Assert.AreEqual(expectedCount, this.chainblock.Count);
        }

        [Test]
        public void AddShoudlNotAddTransactionWithExistId()
        {
            var expectedCount = 1;

            this.chainblock.Add(new Transaction(1, TransactionStatus.Aborted, "vasko", "pesho", 230));
            this.chainblock.Add(new Transaction(1, TransactionStatus.Aborted, "valio", "svetlio", 23));

            Assert.AreEqual(expectedCount, this.chainblock.Count);
        }

        [Test]
        public void ContainsShouldReturnTrueIfTransactionExist()
        {
            var tr = new Transaction(1, TransactionStatus.Aborted, "vasko", "pesho", 230);
            this.chainblock.Add(tr);

            var expectedResult = this.chainblock.Contains(tr);
            var expectedResultWithId = this.chainblock.Contains(1);

            Assert.AreEqual(expectedResult, true);
            Assert.AreEqual(expectedResultWithId, true);
        }

        [Test]
        public void ContainsShouldReturnFalseIfTransactionNotExist()
        {
            var tr = new Transaction(1, TransactionStatus.Aborted, "vasko", "pesho", 230);

            var expectedResult = this.chainblock.Contains(tr);
            var expectedResultWithId = this.chainblock.Contains(1);

            Assert.AreEqual(expectedResult, false);
            Assert.AreEqual(expectedResultWithId, false);
        }

        [Test]
        public void ChangeTransactionStatusShouldWorksCorrectly()
        {
            var tr = new Transaction(1, TransactionStatus.Aborted, "vasko", "pesho", 230);
            this.chainblock.Add(tr);

            var id = 1;
            var status = TransactionStatus.Failed;

            this.chainblock.ChangeTransactionStatus(id, status);
            ITransaction changedTr = null;

            foreach (var transaction in this.chainblock)
            {
                changedTr = transaction;
            }

            Assert.AreEqual(status, changedTr.Status);
        }

        [Test]
        public void ChangeTransactionStatusShouldThrownExceptionWithInvalidId()
        {
            var id = 10;
            var expectedChange = TransactionStatus.Failed;

            Assert.Throws<ArgumentException>(() =>
            {
                this.chainblock.ChangeTransactionStatus(id, expectedChange);
            });
        }

        [Test]
        [TestCase(1)]
        public void RemoveTransactionByIdShouldRemoveCorrectTransaction(int id)
        {
            var tr = new Transaction(1, TransactionStatus.Aborted, "vasko", "pesho", 230);
            this.chainblock.Add(tr);

            var expectedCound = 0;
            this.chainblock.RemoveTransactionById(id);

            Assert.AreEqual(expectedCound, this.chainblock.Count);
        }

        [Test]
        [TestCase(11)]
        public void RemoveTransactionByIdShouldThrownExceptionWithInvalidId(int id)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.chainblock.RemoveTransactionById(id);
            });
        }

        [Test]
        public void GetByTransactionStatusShouldReturnTransactionsWithGivenStatus()
        {
            var tr = new Transaction(1, TransactionStatus.Aborted, "vasko", "pesho", 230);
            var otherTr = new Transaction(2, TransactionStatus.Aborted, "nasko", "gosho", 300);
            this.chainblock.Add(tr);
            this.chainblock.Add(otherTr);

            var status = TransactionStatus.Aborted;
            var result = this.chainblock.GetByTransactionStatus(status).ToArray();

            Assert.AreEqual(result.Length, 2);
            Assert.AreEqual(result[0].Amount, 300);
            Assert.AreEqual(result[1].Amount, 230);
        }

        [Test]
        public void GetByTransactionStatusShouldThrownExceptionWithInvalidStatus()
        {
            var tr = new Transaction(1, TransactionStatus.Aborted, "vasko", "pesho", 230);
            this.chainblock.Add(tr);

            var status = TransactionStatus.Failed;

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.chainblock.GetByTransactionStatus(status);
            });
        }

        [Test]
        public void GetAllSendersWithTransactionStatusShouldReturnAllSendersWhichHaveTransactionWithGivenStatus()
        {
            var tr = new Transaction(1, TransactionStatus.Aborted, "vasko", "pesho", 230);
            var otherTr = new Transaction(2, TransactionStatus.Aborted, "nasko", "gosho", 300);
            var thirdTr = new Transaction(3, TransactionStatus.Aborted, "nasko", "sesko", 320);
            this.chainblock.Add(tr);
            this.chainblock.Add(otherTr);
            this.chainblock.Add(thirdTr);

            var status = TransactionStatus.Aborted;
            var result = this.chainblock.GetAllSendersWithTransactionStatus(status).ToArray();

            Assert.AreEqual(result.Length, 3);
            Assert.AreEqual(result[0], "nasko");
            Assert.AreEqual(result[1], "nasko");
            Assert.AreEqual(result[2], "vasko");
        }

        [Test]
        public void GetAllSendersWithTransactionStatusShouldThrownExceptionWithInvalidStatus()
        {
            var tr = new Transaction(1, TransactionStatus.Aborted, "vasko", "pesho", 230);
            this.chainblock.Add(tr);

            var status = TransactionStatus.Failed;

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.chainblock.GetAllSendersWithTransactionStatus(status);
            });
        }

        [Test]
        public void GetAllReceiversWithTransactionStatusShouldReturnAllSendersWhichHaveTransactionWithGivenStatus()
        {
            var tr = new Transaction(1, TransactionStatus.Aborted, "vasko", "pesho", 230);
            var otherTr = new Transaction(2, TransactionStatus.Aborted, "nasko", "gosho", 300);
            var thirdTr = new Transaction(3, TransactionStatus.Aborted, "nasko", "sesko", 320);
            this.chainblock.Add(tr);
            this.chainblock.Add(otherTr);
            this.chainblock.Add(thirdTr);

            var status = TransactionStatus.Aborted;
            var result = this.chainblock.GetAllReceiversWithTransactionStatus(status).ToArray();

            Assert.AreEqual(result.Length, 3);
            Assert.AreEqual(result[0], "sesko");
            Assert.AreEqual(result[1], "gosho");
            Assert.AreEqual(result[2], "pesho");
        }

        [Test]
        public void GetAllReceiversWithTransactionStatusShouldThrownExceptionWithInvalidStatus()
        {
            var tr = new Transaction(1, TransactionStatus.Aborted, "vasko", "pesho", 230);
            this.chainblock.Add(tr);

            var status = TransactionStatus.Failed;

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.chainblock.GetAllSendersWithTransactionStatus(status);
            });
        }


        [Test]
        public void GetAllOrderedByAmountDescendingThenByIdShouldReturnCorrectCollection()
        {
            var tr = new Transaction(1, TransactionStatus.Aborted, "vasko", "pesho", 230);
            var otherTr = new Transaction(2, TransactionStatus.Aborted, "nasko", "gosho", 300);
            this.chainblock.Add(tr);
            this.chainblock.Add(otherTr);

            var result = this.chainblock.GetAllOrderedByAmountDescendingThenById().ToArray();

            Assert.AreEqual(result.Length, 2);
            Assert.AreEqual(result[0].Amount, 300);
            Assert.AreEqual(result[1].Amount, 230);
        }

        [Test]
        public void GetAllOrderedByAmountDescendingThenByIdShouldReturnEmptyCollection()
        {
            var result = this.chainblock.GetAllOrderedByAmountDescendingThenById().ToArray();

            Assert.AreEqual(result.Length, 0);
        }

        [Test]
        [TestCase("nasko")]
        public void GetBySenderOrderedByAmountDescendingShouldReturnCorrectCollection(string name)
        {
            var tr = new Transaction(1, TransactionStatus.Aborted, "vasko", "pesho", 230);
            var otherTr = new Transaction(2, TransactionStatus.Aborted, "nasko", "gosho", 300);
            var thirdTr = new Transaction(3, TransactionStatus.Aborted, "nasko", "sesko", 320);
            this.chainblock.Add(tr);
            this.chainblock.Add(otherTr);
            this.chainblock.Add(thirdTr);

            var result = this.chainblock.GetBySenderOrderedByAmountDescending(name).ToArray();

            Assert.AreEqual(result.Length, 2);
            Assert.AreEqual(result[0].Amount, 320);
            Assert.AreEqual(result[1].Amount, 300);
        }

        [Test]
        [TestCase("Name")]
        public void GetBySenderOrderedByAmountDescendingShouldThrownExceptionIfEmpty(string name)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.chainblock.GetBySenderOrderedByAmountDescending(name);
            });
        }

        [Test]
        [TestCase("gosho")]
        public void GetByReceiverOrderedByAmountThenByIdShouldReturnCorrectCollection(string name)
        {
            var tr = new Transaction(1, TransactionStatus.Aborted, "vasko", "pesho", 230);
            var otherTr = new Transaction(2, TransactionStatus.Aborted, "nasko", "gosho", 300);
            var thirdTr = new Transaction(3, TransactionStatus.Aborted, "nasko", "sesko", 320);
            this.chainblock.Add(tr);
            this.chainblock.Add(otherTr);
            this.chainblock.Add(thirdTr);

            var result = this.chainblock.GetByReceiverOrderedByAmountThenById(name).ToArray();

            Assert.AreEqual(result.Length, 1);
            Assert.AreEqual(result[0].Amount, 300);
        }

        [Test]
        [TestCase("Name")]
        public void GetByReceiverOrderedByAmountThenByIdShouldThrownExceptionIfEmpty(string name)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.chainblock.GetByReceiverOrderedByAmountThenById(name);
            });
        }

        [Test]
        public void GetByTransactionStatusAndMaximumAmountShouldReturnCorrectCollection()
        {
            var tr = new Transaction(1, TransactionStatus.Aborted, "vasko", "pesho", 230);
            var otherTr = new Transaction(2, TransactionStatus.Aborted, "nasko", "gosho", 300);
            var thirdTr = new Transaction(3, TransactionStatus.Aborted, "nasko", "sesko", 320);
            this.chainblock.Add(tr);
            this.chainblock.Add(otherTr);
            this.chainblock.Add(thirdTr);

            var status = TransactionStatus.Aborted;
            var amount = 310;
            var result = this.chainblock.GetByTransactionStatusAndMaximumAmount(status, amount).ToArray();

            Assert.AreEqual(result.Length, 2);
            Assert.AreEqual(result[0].Amount, 300);
            Assert.AreEqual(result[1].Amount, 230);
        }

        [Test]
        public void GetByTransactionStatusAndMaximumAmountShouldReturnEmptyCollection()
        {
            var tr = new Transaction(1, TransactionStatus.Aborted, "vasko", "pesho", 230);
            var otherTr = new Transaction(2, TransactionStatus.Aborted, "nasko", "gosho", 300);
            this.chainblock.Add(tr);
            this.chainblock.Add(otherTr);

            var status = TransactionStatus.Failed;
            var amount = 310;
            var result = this.chainblock.GetByTransactionStatusAndMaximumAmount(status, amount).ToArray();

            Assert.AreEqual(result.Length, 0);
        }

        [Test]
        public void GetBySenderAndMinimumAmountDescendingShouldReturnCorrectCollection()
        {
            var otherTr = new Transaction(2, TransactionStatus.Aborted, "nasko", "gosho", 300);
            var thirdTr = new Transaction(3, TransactionStatus.Aborted, "nasko", "sesko", 320);
            this.chainblock.Add(otherTr);
            this.chainblock.Add(thirdTr);

            var sender = "nasko";
            var amount = 310;
            var result = this.chainblock.GetBySenderAndMinimumAmountDescending(sender, amount).ToArray();

            Assert.AreEqual(result.Length, 1);
            Assert.AreEqual(result[0].Amount, 320);
        }

        [Test]
        public void GetBySenderAndMinimumAmountDescendingShouldThrownExcepion()
        {
            var sender = "baba";
            var amount = 310;

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.chainblock.GetBySenderAndMinimumAmountDescending(sender, amount);
            });
        }

        [Test]
        public void GetByReceiverAndAmountRangeShouldReturnCorrectCollection()
        {
            var tr = new Transaction(1, TransactionStatus.Aborted, "vasko", "pesho", 230);
            var otherTr = new Transaction(2, TransactionStatus.Aborted, "nasko", "gosho", 300);
            var thirdTr = new Transaction(3, TransactionStatus.Aborted, "nasko", "sesko", 320);
            this.chainblock.Add(tr);
            this.chainblock.Add(otherTr);
            this.chainblock.Add(thirdTr);

            var receiver = "gosho";
            var lo = 210;
            var hi = 310;
            var result = this.chainblock.GetByReceiverAndAmountRange(receiver, lo, hi).ToArray();

            Assert.AreEqual(result.Length, 1);
            Assert.AreEqual(result[0].Amount, 300);
        }

        [Test]
        public void GetByReceiverAndAmountRangeShouldThrownExcepion()
        {
            var receiver = "baba";
            var lo = 310;
            var hi = 521;

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.chainblock.GetByReceiverAndAmountRange(receiver, lo, hi);
            });
        }

        [Test]
        public void GetAllInAmountRangeShouldReturnCorrectCollection()
        {
            var tr = new Transaction(1, TransactionStatus.Aborted, "vasko", "pesho", 230);
            var otherTr = new Transaction(2, TransactionStatus.Aborted, "nasko", "gosho", 300);
            var thirdTr = new Transaction(3, TransactionStatus.Aborted, "nasko", "sesko", 320);
            this.chainblock.Add(tr);
            this.chainblock.Add(otherTr);
            this.chainblock.Add(thirdTr);

            var lo = 210;
            var hi = 310;
            var result = this.chainblock.GetAllInAmountRange(lo, hi).ToArray();

            Assert.AreEqual(result.Length, 2);
            Assert.AreEqual(result[0].Amount, 230);
            Assert.AreEqual(result[1].Amount, 300);
        }

        [Test]
        public void GetAllInAmountRangeShouldReturnEmptyCollection()
        {
            var tr = new Transaction(1, TransactionStatus.Aborted, "vasko", "pesho", 230);
            var otherTr = new Transaction(2, TransactionStatus.Aborted, "nasko", "gosho", 300);
            this.chainblock.Add(tr);
            this.chainblock.Add(otherTr);

            var lo = 310;
            var hi = 521;
            var result = this.chainblock.GetAllInAmountRange(lo, hi).ToArray();

            Assert.AreEqual(result.Length, 0);
        }
    }
}

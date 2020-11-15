using System;
using ExtendedDatabase;
using NUnit.Framework;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private readonly Person[] persons =
        {
            new Person(12, "vasko"),
            new Person(15, "slavi"),
        };

        private ExtendedDatabase.ExtendedDatabase db;

        [SetUp]
        public void Setup()
        {
            this.db = new ExtendedDatabase.ExtendedDatabase(persons);
        }

        [Test]
        public void ConstructorShouldWorksCorrectly()
        {
            Assert.AreEqual(this.db.Count, 2);
        }

        [Test]
        public void ConstructorShouldThrownExceptionWithMoreData()
        {
            var persons = new Person[17];

            for (int i = 0; i < persons.Length; i++)
            {
                persons[i] = new Person(100 + i, $"qni{i}");
            }

            Assert.Throws<ArgumentException>(() =>
            {
                this.db = new ExtendedDatabase.ExtendedDatabase(persons);
            });
        }

        [Test]
        public void AddOperationShouldWorksCorrectly()
        {
            this.db.Add(new Person(999, "Malincho"));

            Assert.AreEqual(this.db.Count, 3);
        }

        [Test]
        public void AddShouldThrowExceptionWithMoreData()
        {
            for (int i = 2; i < 16; i++)
            {
                this.db.Add(new Person(100 + i, $"qni{i}"));
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.db.Add(new Person(458, "Gosho"));
            });
        }

        [Test]
        public void AddOperationShouldThrownExceptionIfAddPersonWithSameUsername()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.db.Add(new Person(1, "vasko"));
            });
        }

        [Test]
        public void AddOperationShouldThrownExceptionIfAddPersonWithSameId()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.db.Add(new Person(12, "rafa"));
            });
        }

        [Test]
        public void RemoveOperationShouldWorksCorrectly()
        {
            this.db.Remove();

            Assert.AreEqual(this.db.Count, 1);
        }

        [Test]
        public void RemoveOperationShouldThrownExceptionIfEmpty()
        {
            this.db.Remove();
            this.db.Remove();

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.db.Remove();
            });
        }

        [Test]
        [TestCase("vasko")]
        public void FindByUsernameShouldWorkCorrectly(string username)
        {
            var found = this.db.FindByUsername(username);

            Assert.AreEqual(found, persons[0]);
        }

        [Test]
        [TestCase("nasko")]
        public void FindByUsernameShouldThrownExceptionWithAlreadyExistUsername(string username)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.db.FindByUsername(username);
            });
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void FindByUsernameShouldThrownExceptionWithInvalidParameters(string username)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                this.db.FindByUsername(username);
            });
        }

        [Test]
        [TestCase(12)]
        public void FindByIdShouldWorksCorrectly(long id)
        {
            var found = this.db.FindById(id);

            Assert.AreEqual(found, persons[0]);
        }

        [Test]
        [TestCase(1001)]
        public void FindByIdShouldThrownExceptionWithInvalidId(long id)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.db.FindById(id);
            });
        }

        [Test]
        [TestCase(-155)]
        public void FindByIdShouldThrownExceptionWithNegativeId(long id)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                this.db.FindById(id);
            });
        }
    }
}
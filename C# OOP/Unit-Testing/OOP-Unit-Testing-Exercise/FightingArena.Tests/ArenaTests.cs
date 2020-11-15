using System;
using FightingArena;
using NUnit.Framework;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;
        private Warrior warrior;
        private Warrior testWarrior;

        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
            this.warrior = new Warrior("Svetlio", 100, 200);
            this.testWarrior = new Warrior("Test", 100, 200);
        }

        [Test]
        public void ArenaEnrollSholdWorksCorrectly()
        {
            this.arena.Enroll(this.warrior);
            var expectedCount = 1;

            Assert.AreEqual(this.arena.Count, expectedCount);
        }

        [Test]
        public void AlreadyEnrolledWarriorsShouldNotBeAbleToEnrollAgain()
        {
            this.arena.Enroll(this.warrior);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Enroll(new Warrior(this.warrior.Name, 1, 2));
            });
        }

        [Test]
        public void FightMethodShouldThrownExceptionIfOneOfTheWarriorsNotEnrolledForTheFight()
        {
            this.arena.Enroll(this.warrior);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Fight(this.warrior.Name, this.testWarrior.Name);
            });
        }

        [Test]
        public void TestFightBetweenTwoWarriors()
        {
            var expectedAtackerHP = this.warrior.HP - this.testWarrior.Damage;
            var expectedDeffenderHP = this.testWarrior.HP - this.warrior.Damage;

            this.arena.Enroll(this.warrior);
            this.arena.Enroll(this.testWarrior);

            //Act
            this.arena.Fight(this.warrior.Name, this.testWarrior.Name);

            //Assert
            Assert.AreEqual(expectedAtackerHP, this.warrior.HP);
            Assert.AreEqual(expectedDeffenderHP, this.testWarrior.HP);
        }
    }
}

using System;
using FightingArena;
using NUnit.Framework;

namespace Tests
{
    public class WarriorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorShouldWorksCorrectly()
        {
            var warrior = new Warrior("Svetlio", 100, 200);

            Assert.AreEqual(warrior.Name, "Svetlio");
            Assert.AreEqual(warrior.Damage, 100);
            Assert.AreEqual(warrior.HP, 200);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void NamePropertyShouldThrownExceptionWithNullOrEmptyData(string name)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new Warrior(name, 100, 200);
            });
        }

        [Test]
        [TestCase(0)]
        [TestCase(-12)]
        public void DamagePropertyShouldThrownExceptionWithNegativeData(int damage)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new Warrior("Svetlio", damage, 200);
            });
        }

        [Test]
        [TestCase(-12)]
        public void HpPropertyShouldThrownExceptionWithNegativeData(int hp)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new Warrior("Svetlio", 100, hp);
            });
        }

        [Test]
        public void AttackMethodShouldWorksCorrectly()
        {
            var warrior = new Warrior("Svetlio", 10, 100);
            var opponent = new Warrior("Test", 10, 100);

            var expectedWarriorHP = warrior.HP - opponent.Damage;
            var expectedOpponentHP = opponent.HP - warrior.Damage;

            warrior.Attack(opponent);

            Assert.AreEqual(expectedWarriorHP, warrior.HP);
            Assert.AreEqual(expectedOpponentHP, opponent.HP);
        }

        [Test]
        [TestCase(25)]
        [TestCase(30)]
        public void AttackMethodShouldThrowExceptionIfWarriorTryToAttackWithLowHp(int belowHP)
        {
            var warrior = new Warrior("Svetlio", 100, belowHP);
            var opponent = new Warrior("Test", 10, 40);

            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior.Attack(opponent);
            });
        }

        [Test]
        [TestCase(25)]
        [TestCase(30)]
        public void AttackMethodShouldThrowExceptionIfWarriorTryToAttackWarriorsWhichHPbBelow30(int belowHP)
        {
            var warrior = new Warrior("Svetlio", 100, 200);
            var opponent = new Warrior("Test", 10, belowHP);

            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior.Attack(opponent);
            });
        }

        [Test]
        public void AttackMethodShouldThrowExceptionIfWarriorTryAttackStrongerEnemies()
        {
            var warrior = new Warrior("Svetlio", 100, 50);
            var opponent = new Warrior("Test", 100, 200);

            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior.Attack(opponent);
            });
        }

        [Test]
        public void TestKillingEnemyWithAttack()
        {
            var warrior = new Warrior("Svetlio", 80, 100);
            var opponent = new Warrior("Test", 10, 60);

            var expectedWarriorHP = warrior.HP - opponent.Damage;
            var expectedOpponentHP = 0;

            warrior.Attack(opponent);

            Assert.AreEqual(expectedWarriorHP, warrior.HP);
            Assert.AreEqual(expectedOpponentHP, opponent.HP);
        }
    }
}
using Moq;
using NUnit.Framework;
using Skeleton.Models.Contracts;

[TestFixture]
public class HeroTests
{
    private const int EXPERIENCE = 100;

    //With Mocking
    [Test]
    public void HeroShouldGainXpWhenTargetDies()
    {
        var fakeWeapon = Mock.Of<IWeapon>();
        var fakeTarget = new Mock<ITarget>();

        fakeTarget.Setup(t => t.IsDead())
            .Returns(true);
        fakeTarget.Setup(t => t.GiveExperience()).Returns(EXPERIENCE);

        var hero = new Hero("TestHero", fakeWeapon);

        hero.Attack(fakeTarget.Object);

        Assert.That(hero.Experience, Is.EqualTo(EXPERIENCE));
    }

    //Without Mocking

    //private IWeapon weapon;
    //private ITarget target;
    //private Hero hero;

    //[SetUp]
    //public void TestInit()
    //{
    //    this.weapon = new Axe(30, 50);
    //    this.target = new Dummy(10, 100);
    //    this.hero = new Hero("Vasko", this.weapon);
    //}

    //[Test]
    //public void HeroGainsXPWhenTargetDies()
    //{
    //    var initialXp = this.hero.Experience;

    //    this.hero.Attack(this.target);

    //    var result = this.hero.Experience != initialXp;

    //    Assert.That(result, Is.EqualTo(true));
    //}
}
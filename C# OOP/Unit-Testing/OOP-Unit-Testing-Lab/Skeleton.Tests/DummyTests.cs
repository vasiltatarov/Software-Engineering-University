using NUnit.Framework;
using Skeleton.Models.Contracts;

[TestFixture]
public class DummyTests
{
    private IWeapon axe;
    private ITarget dummy;

    [SetUp]
    public void TestInit()
    {
        this.axe = new Axe(2, 2);
        this.dummy = new Dummy(20, 20);
    }

    [Test]
    public void DummyLooseHealthIfAttacked()
    {
        this.axe.Attack(this.dummy);

        Assert.That(this.dummy.Health, Is.EqualTo(18));
    }

    [Test]
    public void DeadDummyThrowsExceptionIfAttacked()
    {
        var axe = new Axe(20, 100);
        axe.Attack(this.dummy);

        Assert.That(() => axe.Attack(this.dummy),
            Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."));
    }

    [Test]
    public void DeadDummyCanGiveXP()
    {
        var axe = new Axe(20, 100);
        axe.Attack(this.dummy);

        Assert.That(() => this.dummy.GiveExperience() != 0);
    }

    [Test]
    public void AliveDummyCantGiveXp()
    {
        Assert.That(() => this.dummy.GiveExperience(), 
            Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."));
    }
}

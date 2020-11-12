using NUnit.Framework;
using Skeleton.Models.Contracts;

[TestFixture]
public class AxeTests
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
    public void AxeLooseDurabilityAfterAttack()
    {
        this.axe.Attack(dummy);

        Assert.That(this.axe.DurabilityPoints, Is.EqualTo(1), "Axe Durability doesn't change after attack.");
    }

    [Test]
    public void CannotAttackWithBrokenAxe()
    {
        this.axe.Attack(dummy);
        this.axe.Attack(dummy);

        Assert.That(() => this.axe.Attack(this.dummy),
            Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."));
    }
}
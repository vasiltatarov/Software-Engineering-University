namespace P08_ExplicitInterfaces.Contracts
{
    public interface IResident
    {
        string Name { get; }

        string Country { get; }

        string GetName() => $"Mr/Ms/Mrs {this.Name}";
    }
}

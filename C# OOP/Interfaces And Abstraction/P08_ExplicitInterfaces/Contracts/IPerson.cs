namespace P08_ExplicitInterfaces.Contracts
{
    public interface IPerson
    {
        string Name { get; }

        int Age { get; }

        string GetName() => this.Name;
    }
}

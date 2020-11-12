using System;

public class StartUp
{
    static void Main(string[] args)
    {
        var axe = new Axe(100, 200);
        var dummy = new Dummy(200, 300);
        Console.WriteLine(axe.DurabilityPoints);
        axe.Attack(dummy);
        Console.WriteLine(axe.DurabilityPoints);
    }
}

using System;

namespace Stealer
{
    public class StartUp
    {
        public static void Main()
        {
            //var spy = new Spy();
            //var result = spy.StealFieldInfo("Stealer.Hacker", "username", "password");
            //Console.WriteLine(result);

            //var spy = new Spy();
            //var result = spy.RevealPrivateMethods("Stealer.Hacker");
            //Console.WriteLine(result);

            var spy = new Spy();
            var result = spy.CollectGettersAndSetters("Stealer.Hacker");
            Console.WriteLine(result);
        }
    }
}

using System;
using System.Collections.Generic;
using CounterStrike.Models.Guns;
using CounterStrike.Models.Maps;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;

namespace CounterStrike
{
    using CounterStrike.Core;
    using CounterStrike.Core.Contracts;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}

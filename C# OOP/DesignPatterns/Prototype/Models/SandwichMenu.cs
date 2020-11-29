using System.Collections.Generic;

namespace Prototype.Models
{
    public class SandwichMenu
    {
        private readonly Dictionary<string, SandwichPrototype> _sandwitches = new Dictionary<string, SandwichPrototype>();

        public SandwichPrototype this[string name]
        {
            get => _sandwitches[name];
            set => _sandwitches.Add(name, value);
        }
    }
}

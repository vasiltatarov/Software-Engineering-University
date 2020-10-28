using System;
using System.Collections.Generic;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        private Random rand;

        public RandomList()
        {
            this.rand = new Random();
        }

        public string RandomString()
        {
            var index = rand.Next(0, base.Count);
            var toRemove = base[index];
            base.RemoveAt(index);

            return toRemove;
        }
    }
}

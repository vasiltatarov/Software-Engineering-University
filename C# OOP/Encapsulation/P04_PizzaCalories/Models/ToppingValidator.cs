using System.Collections.Generic;

namespace P04_PizzaCalories.Models
{
    public static class ToppingValidator
    {
        private static Dictionary<string, double> toppingTypes;

        public static bool IsValidBakingType(string bakingType)
        {
            if (toppingTypes == null)
            {
                Initialize();
            }

            return toppingTypes.ContainsKey(bakingType);
        }

        private static void Initialize()
        {
            toppingTypes = new Dictionary<string, double>();

            toppingTypes.Add("meat", 1.2);
            toppingTypes.Add("veggies", 0.8);
            toppingTypes.Add("cheese", 1.1);
            toppingTypes.Add("sauce", 0.9);
        }

        public static double GetCalories(string bakingType, double grams)
            => (2.0 * grams) * toppingTypes[bakingType.ToLower()];
    }
}

using System.Collections.Generic;

namespace P04_PizzaCalories.Models
{
    public static class DoughValidator
    {
        private static Dictionary<string, double> flourTypes;
        private static Dictionary<string, double> bakingTechnique;

        public static bool IsValidFlourType(string flourType)
        {
            if (flourTypes == null && bakingTechnique == null)
            {
                Initialize();
            }

            return flourTypes.ContainsKey(flourType);
        }

        public static bool IsValidTechType(string techType)
        {
            if (flourTypes == null && bakingTechnique == null)
            {
                Initialize();
            }

            return bakingTechnique.ContainsKey(techType);
        }

        public static double GetCalories(string flourType, string techType, double grams)
            => (2 * grams) * flourTypes[flourType.ToLower()] * bakingTechnique[techType.ToLower()];

        private static void Initialize()
        {
            flourTypes = new Dictionary<string, double>();
            bakingTechnique = new Dictionary<string, double>();

            flourTypes.Add("white", 1.5);
            flourTypes.Add("wholegrain", 1);

            bakingTechnique.Add("crispy", 0.9);
            bakingTechnique.Add("chewy", 1.1);
            bakingTechnique.Add("homemade", 1);
        }
    }
}

using Prototype.Models;

namespace Prototype
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            SandwichMenu sandwichMenu = new SandwichMenu();

            sandwichMenu["BLT"] = new Sandwich("Wheat", "Bacon", "", "Lettuce, Tomato");
            sandwichMenu["PB&J"] = new Sandwich("White", "", "", "Peanut butter, Jelly");
            sandwichMenu["Turkey"] = new Sandwich("Rye", "Turkey", "Swiss", "Lettuce, Onion, Tomato");

            Sandwich sandwich1 = sandwichMenu["BLT"].Clone() as Sandwich;
            Sandwich sandwich2 = sandwichMenu["Turkey"].Clone() as Sandwich;
        }
    }
}

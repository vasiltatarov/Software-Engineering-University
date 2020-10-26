using P03_StudentSystem.Models;

namespace P03_StudentSystem
{
    public class StartUp
    {
        public static void Main()
        {
            var students = new StudentSystem();
            var inputOutputProvider = new InputOutputProvider();
            var engine = new Engine(students, inputOutputProvider);

            engine.Procces();
        }
    }
}

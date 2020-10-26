using P03_StudentSystem.Iterfaces;

namespace P03_StudentSystem
{
    public class Engine
    {
        private StudentSystem studentSystem;
        private IInputOutputProvider inputOutputProvider;

        public Engine(StudentSystem students, IInputOutputProvider inputOutputProvider)
        {
            this.studentSystem = students;
            this.inputOutputProvider = inputOutputProvider;
        }

        public void Procces()
        {
            var isContinue = true;

            while (isContinue)
            {
                var line = this.inputOutputProvider.GetInput();

                var command = CommandParser.ParseCommand(line);
                var name = command.Name;
                var args = command.Arguments;

                if (name == "Create")
                {
                    var studentName = args[0];
                    var age = int.Parse(args[1]);
                    var grade = double.Parse(args[2]);

                    this.studentSystem.Add(studentName, age, grade);
                }
                else if (name == "Show")
                {
                    var studentName = args[0];

                    this.inputOutputProvider.ShowOutput(this.studentSystem.GetDetails(studentName));
                }
                else if (name == "Exit")
                {
                    isContinue = false;
                }
            }
        }
    }
}

using P03_StudentSystem.Iterfaces;
using System;

namespace P03_StudentSystem.Models
{
    public class InputOutputProvider : IInputOutputProvider
    {
        public string GetInput()
        {
            return Console.ReadLine();
        }

        public void ShowOutput(string data)
        {
            Console.WriteLine(data);
        }
    }
}

using ConsoleUI.Controls;
using System;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            CheckboxOption[] options = {
                new CheckboxOption("Option 1", true),
                new CheckboxOption("Option 2"),
                new CheckboxOption("Option 3")
            };

            var checkbox = new Checkbox(options);
            checkbox.Show();
        }
    }
}

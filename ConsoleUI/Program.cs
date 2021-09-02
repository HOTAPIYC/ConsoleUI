using ConsoleUI.Controls;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            List<ISelectable> options = new List<ISelectable>
            {
                new Option("Option 1", true),
                new Option("Option 2"),
                new Option("Option 3")
            };

            var checkbox = new Checkbox(options);
            var selection = checkbox.Show();

            Console.WriteLine("Selected options: ");
            selection.ForEach((result) => Console.WriteLine($"{result.Text} "));

            var input = new ValidatedInput("Please enter a string: ");
            input.SetValidation((input) => !string.IsNullOrEmpty(input), "Input is empty string!");
            var result = input.Promt();

            Console.WriteLine($"Entered input: {result}");
        }
    }

    public class Option : ISelectable
    {
        public string Text { get; }
        public bool Selected { get; set; }
        public Option(string text, bool selected = false)
        {
            Text = text;
            Selected = selected;
        }
    }
}

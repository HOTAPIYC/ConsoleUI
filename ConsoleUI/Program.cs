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

            Console.Write("Selected options: ");
            selection.ForEach((result) => Console.Write($"{result.Text} "));
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

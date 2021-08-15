using System;

namespace ConsoleUI.Controls
{
    public class Checkbox
    {
        private CheckboxOption[] _options;

        public Checkbox(CheckboxOption[] options)
        {
            _options = options;
        }

        public CheckboxOption[] Show()
        {
            var selectedIndex = 0;
            var confirm = false;

            while (true)
            {
                for (var i = 0; i < _options.Length; i++)
                {
                    if (i == selectedIndex && !confirm)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }

                    Console.WriteLine($"{GetSelectorField(_options[i])} {_options[i].Text}");
                    Console.ResetColor();
                }

                if (confirm)
                {
                    break;
                }

                var key = Console.ReadKey().Key;

                if (key == ConsoleKey.DownArrow && selectedIndex < _options.Length)
                {
                    selectedIndex++;
                }
                if (key == ConsoleKey.UpArrow && selectedIndex > 0)
                {
                    selectedIndex--;
                }
                if (key == ConsoleKey.Spacebar)
                {
                    _options[selectedIndex].Selected = !_options[selectedIndex].Selected;
                }
                if (key == ConsoleKey.Enter)
                {
                    confirm = true;
                }

                Console.SetCursorPosition(0, Console.CursorTop - _options.Length);
            }

            string GetSelectorField(CheckboxOption option)
            {
                if (option.Selected)
                {
                    return "[*]";
                }
                else
                {
                    return "[ ]";
                }
            }

            return _options;
        }
    }
}

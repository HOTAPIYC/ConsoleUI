using System;

namespace ConsoleUI.Controls
{
    public class ValidatedInput
    {
        public delegate bool Validation(string input);
        private string _promt;
        private string _error = "Error on input!";
        private Validation _callback;

        public ValidatedInput(string promt)
        {
            _promt = promt;
        }

        public string Promt()
        {
            var input = string.Empty;

            while (true)
            {
                Console.WriteLine(_promt);
                input = Console.ReadLine();
                var valid = _callback(input);

                if (valid)
                {
                    Console.Write(new String(' ', _error.Length));
                    Console.SetCursorPosition(0, Console.CursorTop);
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine(_error);
                    Console.ResetColor();
                    Console.SetCursorPosition(0, Console.CursorTop - 3);
                }
            }

            return input;
        }

        public void SetValidation(Validation callback, string error)
        {
            _callback = callback;
            _error = error;
        }
    }
}

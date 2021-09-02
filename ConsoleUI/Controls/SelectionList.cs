using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Controls
{
    public class SelectionList
    {
        private List<ISelectable> _items;

        public SelectionList(List<ISelectable> items)
        {
            _items = items;
        }

        public ISelectable Show()
        {
            var selectedIndex = 0;
            var visibleIndex = 0;
            var confirm = false;

            while (true)
            {
                var boundary = _items.Count > 3 ? 3 : _items.Count;

                for (var i = 0; i < _items.Count; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    if (i >= visibleIndex && i < visibleIndex + boundary)
                    {
                        Console.WriteLine(_items[i].Text);
                    }
                    Console.ResetColor();
                }

                if (confirm)
                {
                    break;
                }

                var key = Console.ReadKey().Key;

                var scrollDownRequired = (visibleIndex + boundary - 1) == selectedIndex;
                var scrollDownLimit = visibleIndex == (_items.Count - boundary);
                var scrollUpRequired = selectedIndex == visibleIndex;
                var scrollUpLimit = visibleIndex <= 0;

                var lastIndexSelected = selectedIndex == _items.Count - 1;
                var firstIndexSelected = selectedIndex == 0;

                if (key == ConsoleKey.DownArrow && scrollDownRequired && !scrollDownLimit)
                {
                    visibleIndex++;
                }
                if (key == ConsoleKey.DownArrow && !lastIndexSelected)
                {
                    selectedIndex++;
                }
                if (key == ConsoleKey.UpArrow && scrollUpRequired && !scrollUpLimit)
                {
                    visibleIndex--;
                }
                if (key == ConsoleKey.UpArrow && !firstIndexSelected)
                {
                    selectedIndex--;
                }
                if (key == ConsoleKey.Enter)
                {
                    confirm = true;
                }

                Console.SetCursorPosition(0, Console.CursorTop - boundary);
            }

            return _items[selectedIndex];
        }
    }
}

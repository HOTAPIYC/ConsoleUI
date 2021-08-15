using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Controls
{
    public interface ISelectable
    {
        public string Text { get; }
        public bool Selected { get; set; }
    }
}

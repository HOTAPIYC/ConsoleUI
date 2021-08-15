namespace ConsoleUI.Controls
{
    public class CheckboxOption
    {
        public string Text { get; }
        public bool Selected { get; set; }

        public CheckboxOption(string text, bool selected = false)
        {
            Text = text;
            Selected = selected;
        }
    }
}

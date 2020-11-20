namespace Composite.Styles
{
    public class Style : IStyle
    {
        protected Style(uint? color)
        {
            Color = color;
            IsEnabled = true;
        }

        public Style()
        {
            IsEnabled = true;
            Color = null;
        }

        public bool? IsEnabled { get; set; }
        public uint? Color { get; set; }
    }
}
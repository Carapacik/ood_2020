namespace Composite.Styles
{
    public class OutlineStyle : Style, IOutlineStyle
    {
        public OutlineStyle(uint? color, uint? thickness) : base(color)
        {
            Thickness = thickness;
        }

        public uint? Thickness { get; set; }
    }
}
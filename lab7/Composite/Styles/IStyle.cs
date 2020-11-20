namespace Composite.Styles
{
    public interface IStyle
    {
        bool? IsEnabled { get; set; }
        uint? Color { get; set; }
    }
}
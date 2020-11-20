using Composite.Styles;

namespace Composite.Shapes
{
    public interface IShape : IDrawable
    {
        IOutlineStyle OutlineStyle { get; }
        IStyle FillStyle { get; }
        public Rect GetFrame();
        public void SetFrame(Rect frame);
    }
}
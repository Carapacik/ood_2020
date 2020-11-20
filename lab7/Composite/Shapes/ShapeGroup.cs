using System.Collections.Generic;
using System.Linq;
using Composite.Styles;
using MoreLinq;

namespace Composite.Shapes
{
    public class ShapeGroup : ShapeManager, IShape
    {
        private readonly IStyleEnumerator<IStyle> _fillStyleEnumerator;
        private readonly IStyleEnumerator<IOutlineStyle> _outlineStyleEnumerator;

        public ShapeGroup()
        {
            _fillStyleEnumerator = new FillStyleEnumerator(this);
            _outlineStyleEnumerator = new OutlineStyleEnumerator(this);
        }

        public Rect GetFrame()
        {
            var notNullShapes = Shapes.Where(x => x.GetFrame() != null).ToList();
            if (notNullShapes.Count == 0)
                return null;

            var leftTop = new Point(notNullShapes.Min(x => x.GetFrame().LeftTop.X),
                notNullShapes.Min(y => y.GetFrame().LeftTop.Y));
            var maxWidthElement =
                notNullShapes.MaxBy(x => x.GetFrame().LeftTop.X + x.GetFrame().Width).FirstOrDefault();
            var width = maxWidthElement.GetFrame().LeftTop.X + maxWidthElement.GetFrame().Width - leftTop.X;
            var maxHeightElement =
                notNullShapes.MaxBy(y => y.GetFrame().LeftTop.Y + y.GetFrame().Height).FirstOrDefault();
            var height = maxHeightElement.GetFrame().LeftTop.Y + maxHeightElement.GetFrame().Height - leftTop.Y;
            return new Rect(leftTop, width, height);
        }

        public void SetFrame(Rect frame)
        {
            var prevFrame = GetFrame();
            foreach (var shape in Shapes.Where(shape => shape.GetFrame() != null))
            {
                var relativeLeftTop = new Point((shape.GetFrame().LeftTop.X - prevFrame.LeftTop.X) / prevFrame.Width,
                    (shape.GetFrame().LeftTop.Y - prevFrame.LeftTop.Y) / prevFrame.Height);

                var relativeWidth = shape.GetFrame().Width / prevFrame.Width;
                var relativeHeight = shape.GetFrame().Height / prevFrame.Height;

                var newPoint = new Point(frame.LeftTop.X + relativeLeftTop.X * frame.Width,
                    frame.LeftTop.Y + relativeLeftTop.Y * frame.Height);
                var newWidth = relativeWidth * frame.Width;
                var newHeight = relativeHeight * frame.Height;
                shape.SetFrame(new Rect(newPoint, newWidth, newHeight));
            }
        }

        public IOutlineStyle OutlineStyle
        {
            get
            {
                if (ShapesCount <= 0)
                    return null;

                var groupStyle = new OutlineGroupStyle(_outlineStyleEnumerator);
                return groupStyle;
            }
        }

        public IStyle FillStyle
        {
            get
            {
                if (ShapesCount <= 0)
                    return null;

                var groupStyle = new GroupStyle<IStyle>(_fillStyleEnumerator);
                return groupStyle;
            }
        }

        public void Draw(ICanvas canvas)
        {
            foreach (var shape in Shapes) shape.Draw(canvas);
        }

        private class FillStyleEnumerator : IStyleEnumerator<IStyle>
        {
            private readonly ShapeManager _shapeManager;

            public FillStyleEnumerator(ShapeManager shapeManager)
            {
                _shapeManager = shapeManager;
            }

            public IList<IStyle> StyleList => _shapeManager.Shapes.Select(style => style.FillStyle).ToList();
        }

        private class OutlineStyleEnumerator : IStyleEnumerator<IOutlineStyle>
        {
            private readonly ShapeManager _shapeManager;

            public OutlineStyleEnumerator(ShapeManager shapeManager)
            {
                _shapeManager = shapeManager;
            }

            public IList<IOutlineStyle> StyleList => _shapeManager.Shapes.Select(style => style.OutlineStyle).ToList();
        }
    }
}
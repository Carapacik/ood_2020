using System.Collections.Generic;

namespace Composite.Shapes
{
    public class ShapeManager
    {
        private readonly List<IShape> _shapes = new();
        public int ShapesCount => _shapes.Count;

        public void InsertShape(IShape shape, int position = 0)
        {
            _shapes.Insert(position, shape);
        }

        public IShape GetShapeByIndex(int index)
        {
            return _shapes[index];
        }

        public void RemoveShapeAtIndex(int index)
        {
            _shapes.RemoveAt(index);
        }
    }
}
using System.Collections.Generic;

namespace Composite.Shapes
{
    public class ShapeManager
    {
        public readonly List<IShape> Shapes = new List<IShape>();
        protected int ShapesCount => Shapes.Count;

        public void InsertShape(IShape shape, int position = 0)
        {
            Shapes.Insert(position, shape);
        }

        public IShape GetShapeByIndex(int index)
        {
            return Shapes[index];
        }

        public void RemoveShapeAtIndex(int index)
        {
            Shapes.RemoveAt(index);
        }
    }
}
using System;
using System.Collections.Generic;
using Factory.Shapes;

namespace Factory
{
    public class PictureDraft
    {
        private readonly List<Shape> _shapes = new List<Shape>();
        public int ShapeCount => _shapes.Count;

        public void AddShape(Shape shape)
        {
            _shapes.Add(shape);
        }

        public Shape GetShape(int index)
        {
            return index >= 0 && index < _shapes.Count ? _shapes[index] : throw new Exception("Index out of range");
        }
    }
}
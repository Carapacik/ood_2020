using Factory.Shapes;

namespace Factory
{
    public interface IShapeFactory
    {
        Shape CreateShape(string description);
    }
}
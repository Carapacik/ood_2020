namespace Adapter.GraphicsLib
{
    public interface ICanvas
    {
        void SetColor(uint rgbColor);
        void MoveTo(int x, int y);
        void LineTo(int x, int y);
    }
}
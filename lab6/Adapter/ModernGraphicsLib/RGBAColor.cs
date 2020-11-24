namespace Adapter.ModernGraphicsLib
{
    public class RgbaColor
    {
        public RgbaColor(float r, float g, float b, float a)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }

        public float R { get; set; }
        public float G { get; set; }
        public float B { get; set; }
        public float A { get; set; }

        public override string ToString()
        {
            return $"\r\n    <color r={R} g={G} b={B} a={A}/>\r\n";
        }
    }
}
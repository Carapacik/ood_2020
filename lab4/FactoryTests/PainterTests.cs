using System.IO;
using Factory;
using Factory.Shapes;
using Xunit;

namespace FactoryTests
{
    public class PainterTests
    {
        [Fact]
        private void DrawPicture_DraftWithShapes_AllShapesHaveBeenDrown()
        {
            var painter = new Painter();
            var draft = new PictureDraft();
            draft.AddShape(new Ellipse(Color.Black, new Point(10, 10), 5, 6));
            draft.AddShape(new Rectangle(Color.Pink, new Point(10, 10), new Point(15, 15)));
            draft.AddShape(new Triangle(Color.Red, new Point(10, 10), new Point(25, 25), new Point(30, 10)));
            var sw = new StringWriter();
            var canvas = new TestCanvas(sw);

            painter.DrawPicture(draft, canvas);

            const string expected =
                "Black ellipse center: (10, 10) radiusX: 5, radiusY: 6\r\nPink line from (10, 10) to (15, 10)\r\n" +
                "Pink line from (15, 10) to (15, 15)\r\nPink line from (15, 15) to (10, 15)\r\n" +
                "Pink line from (10, 15) to (10, 10)\r\nRed line from (10, 10) to (25, 25)\r\n" +
                "Red line from (25, 25) to (30, 10)\r\nRed line from (30, 10) to (10, 10)\r\n";
            
            Assert.Equal(expected, sw.ToString());
        }
    }
}
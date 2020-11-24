using System;
using System.IO;
using Adapter;
using Xunit;

namespace AdapterTests
{
    public class ClassTests
    {
        [Fact]
        private void LineTo_WithMoveAndSetColor_LineWithColorIsDrawn()
        {
            const int fromX = 10;
            const int fromY = 15;
            const int toX = 15;
            const int toY = 70;
            var expected = $"<draw>\r\n  <line fromX={fromX} fromY={fromY} toX={toX} toY={toY}>\r\n" +
                           "    <color r=0,02745098 g=0,5647059 b=0,8039216 a=1/>\r\n  </line>\r\n</draw>\r\n";
            var sw = new StringWriter();
            var adapter = new ClassAdapter(sw);

            adapter.BeginDraw();
            adapter.SetColor(0x0790CD);
            adapter.MoveTo(fromX, fromY);
            adapter.LineTo(toX, toY);
            adapter.EndDraw();

            Assert.Equal(expected, sw.ToString());
        }

        [Fact]
        private void LineTo_WithoutMoveAndSetColor_LineWithoutColorIsDrawnFromZero()
        {
            const int endX = 10;
            const int endY = 15;
            var sw = new StringWriter();
            var adapter = new ClassAdapter(sw);
            var expected = $"<draw>\r\n  <line fromX=0 fromY=0 toX={endX} toY={endY}>\r\n" +
                           "    <color r=0 g=0 b=0 a=1/>\r\n  </line>\r\n</draw>\r\n";

            adapter.BeginDraw();
            adapter.LineTo(endX, endY);
            adapter.EndDraw();

            Assert.Equal(expected, sw.ToString());
        }

        [Fact]
        private void LineTo_WithoutCalledBeginDraw_ThrowException()
        {
            const int endX = 10;
            const int endY = 15;
            var sw = new StringWriter();
            var adapter = new ClassAdapter(sw);

            Assert.Throws<Exception>(() => adapter.LineTo(endX, endY));
        }


        [Fact]
        private void BeginDraw_BeginDrawCalled_StartDrawing()
        {
            var sw = new StringWriter();
            var adapter = new ClassAdapter(sw);
            const string expected = "<draw>\r\n";

            adapter.BeginDraw();

            Assert.Equal(expected, sw.ToString());
        }

        [Fact]
        private void BeginDraw_BeginDrawAlreadyCalled_ThrowException()
        {
            var sw = new StringWriter();
            var adapter = new ClassAdapter(sw);

            adapter.BeginDraw();

            Assert.Throws<Exception>(() => adapter.BeginDraw());
        }

        [Fact]
        private void EndDraw_WithoutBeginDraw_ThrowException()
        {
            var sw = new StringWriter();
            var adapter = new ClassAdapter(sw);

            Assert.Throws<Exception>(() => adapter.EndDraw());
        }
    }
}
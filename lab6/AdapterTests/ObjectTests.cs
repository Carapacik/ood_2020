using System;
using System.IO;
using Adapter;
using Adapter.ModernGraphicsLib;
using Xunit;

namespace AdapterTests
{
    public class ObjectTests
    {
        [Fact]
        private void LineTo_WithMoveAndWithSetColor_LineWithColorIsDrawn()
        {
            const int fromX = 10;
            const int fromY = 15;
            const int toX = 15;
            const int toY = 70;
            var sw = new StringWriter();
            var renderer = new ModernGraphicsRenderer(sw);
            var adapter = new ObjectAdapter(renderer);
            var expected = $"<draw>\r\n  <line fromX={fromX} fromY={fromY} toX={toX} toY={toY}>\r\n" +
                           "    <color r=0,02745098 g=0,5647059 b=0,8039216 a=1/>\r\n  </line>\r\n</draw>\r\n";

            renderer.BeginDraw();
            adapter.SetColor(0x0790CD);
            adapter.MoveTo(fromX, fromY);
            adapter.LineTo(toX, toY);
            renderer.EndDraw();

            Assert.Equal(expected, sw.ToString());
        }

        [Fact]
        private void LineTo_WithoutMoveAndWithoutSetColor_LineWithoutColorIsDrawnFromZero()
        {
            const int endX = 10;
            const int endY = 15;
            var sw = new StringWriter();
            var renderer = new ModernGraphicsRenderer(sw);
            var adapter = new ObjectAdapter(renderer);
            var expected = $"<draw>\r\n  <line fromX=0 fromY=0 toX={endX} toY={endY}>\r\n" +
                           "    <color r=0 g=0 b=0 a=1/>\r\n  </line>\r\n</draw>\r\n";

            renderer.BeginDraw();
            adapter.LineTo(endX, endY);
            renderer.EndDraw();

            Assert.Equal(expected, sw.ToString());
        }

        [Fact]
        private void LineTo_WithoutBeginDraw_ThrowException()
        {
            const int endX = 10;
            const int endY = 15;
            var sw = new StringWriter();
            var renderer = new ModernGraphicsRenderer(sw);
            var adapter = new ObjectAdapter(renderer);

            Assert.Throws<Exception>(() => adapter.LineTo(endX, endY));
        }
    }
}
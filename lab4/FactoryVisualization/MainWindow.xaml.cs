using System;
using System.IO;
using Factory;

namespace FactoryVisualization
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            Drawing();
        }

        private void Drawing()
        {
            var designer = new Designer(new ShapeFactory());
            var canvas = new Canvas((System.Windows.Controls.Canvas) FindName("MainCanvas"));
            var painter = new Painter();
            var inputDraft = designer.CreateDraft(new StreamReader("../../../input.txt"));

            painter.DrawPicture(inputDraft, canvas);

            Console.WriteLine("Enter commands to draw shapes. Use templates:");
            Console.WriteLine("\tregularPolygon <color> <center(X, Y)> <radius> <vertexCount>");
            Console.WriteLine("\ttriangle <color> <vertex1(X, Y)> <vertex2(X, Y)> <vertex3(X, Y)>");
            Console.WriteLine("\trectangle <color> <leftTop(X, Y)> <rightBottom(X, Y)>");
            Console.WriteLine("\tellipse <color> <center(X, Y)> <horizontalRadius> <verticalRadius>");

            var draft = designer.CreateDraft(Console.In);
            painter.DrawPicture(draft, canvas);
        }
    }
}
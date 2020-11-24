using Composite;
using Composite.Shapes;

namespace CompositeVisualization
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
            var canvas = new Canvas((System.Windows.Controls.Canvas) FindName("MainCanvas"));
            var slide = new Slide(800, 600, 0x8023d95f);

            const uint windowOutlineColor = 0xFF834500;
            const uint windowFillColor = 0xFF8CE7E7;
            const uint windowThickness = 2;
            var window1 = new Ellipse(new Point(125, 325), 25, 30);
            var window2 = new Rectangle(new Point(150, 300), 60, 50);
            window1.OutlineStyle.Color = windowOutlineColor;
            window1.OutlineStyle.Thickness = windowThickness;
            window1.FillStyle.Color = windowFillColor;
            window2.OutlineStyle.Color = windowOutlineColor;
            window2.OutlineStyle.Thickness = windowThickness;
            window2.FillStyle.Color = windowFillColor;

            var windowsGroup = new ShapeGroup();
            windowsGroup.InsertShape(window1);
            windowsGroup.InsertShape(window2);

            var facade = new Rectangle(new Point(80, 250), 170, 140);
            facade.OutlineStyle.Color = 0xFF000000;
            facade.OutlineStyle.Thickness = 2;
            facade.FillStyle.Color = 0xDD990000;

            var roof = new Triangle(new Point(60, 250), new Point(270, 250),
                new Point(165, 200));
            roof.FillStyle.Color = 0xF00606AC;
            roof.OutlineStyle.Color = 0xFF8CE7E7;
            roof.OutlineStyle.Thickness = 3;

            var houseGroup = new ShapeGroup();
            houseGroup.InsertShape(windowsGroup);
            houseGroup.InsertShape(facade);
            houseGroup.InsertShape(roof);

            var groupFrame = houseGroup.GetFrame();
            houseGroup.SetFrame(new Rect(new Point(10, 100), groupFrame.Width, groupFrame.Height));

            slide.InsertShape(houseGroup);
            slide.Draw(canvas);

            houseGroup.SetFrame(new Rect(new Point(500, 10), 100, 90));
            houseGroup.FillStyle.Color = 0xFF8B4513;
            houseGroup.OutlineStyle.Color = 0xAAF0BE74;
            houseGroup.OutlineStyle.Thickness = 3;

            slide.InsertShape(houseGroup);
            slide.Draw(canvas);
        }
    }
}
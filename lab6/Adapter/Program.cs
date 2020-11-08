using System;

namespace Adapter
{
    internal static class Program
    {
        private static void Main()
        {
            Console.WriteLine("Should we use new API (y)?");
            var userInput = Console.ReadLine();
            if (userInput != null && userInput.ToLower() == "y")
            {
                App.PaintPictureOnModernGraphicsRendererObject();
                Console.WriteLine();
                App.PaintPictureOnModernGraphicsRendererClass();
            }
            else
            {
                App.PaintPictureOnCanvas();
            }
        }
    }
}
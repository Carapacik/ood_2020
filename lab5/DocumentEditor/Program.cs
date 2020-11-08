using System;

namespace DocumentEditor
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("Enter a command. For more info enter 'help'");
            var editor = new DocumentEditor(Console.Out, Console.In);
            editor.Start();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace SimUDuckFP.Behaviors
{
    public class QuackBehavior
    {
        public static void Quack()
        {
            Console.WriteLine("Quack Quack!");
        }

        public static void Squeak()
        {
            Console.WriteLine("Squeek!");
        }

        public static void NoQuackBehavior() { }
    }
}

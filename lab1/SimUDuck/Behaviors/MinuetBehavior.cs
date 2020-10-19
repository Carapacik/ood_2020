using System;

namespace SimUDuck.Behaviors
{
    internal class MinuetBehavior : IDanceBehavior
    {
        public void Dance()
        {
            Console.WriteLine("I'm dancing minuet!");
        }
    }
}
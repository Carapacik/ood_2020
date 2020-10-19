using System;

namespace SimUDuck.Behaviors
{
    internal class WaltzBehavior : IDanceBehavior
    {
        public void Dance()
        {
            Console.WriteLine("I'm dancing waltz!");
        }
    }
}
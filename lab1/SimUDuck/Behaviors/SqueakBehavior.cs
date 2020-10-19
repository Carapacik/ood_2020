using System;

namespace SimUDuck.Behaviors
{
    public class SqueakBehavior : IQuackBehavior
    {
        public void Quack()
        {
            Console.WriteLine("Squeak!!!");
        }
    }
}
using System;

namespace SimUDuck.QuackBehaviors
{
    public class SqueakBehavior : IQuackBehavior
    {
        public void Quack()
        {
            Console.WriteLine("Squeek!!!");
        }
    }
}

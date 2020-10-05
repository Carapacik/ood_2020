using System;

namespace SimUDuck.QuackBehaviors
{
    public class QuackBehavior : IQuackBehavior
    {
        public void Quack()
        {
            Console.WriteLine("Quack Quack!!!");
        }
    }
}

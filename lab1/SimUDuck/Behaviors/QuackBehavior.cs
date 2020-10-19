using System;

namespace SimUDuck.Behaviors
{
    public class QuackBehavior : IQuackBehavior
    {
        public void Quack()
        {
            Console.WriteLine("Quack Quack!!!");
        }
    }
}
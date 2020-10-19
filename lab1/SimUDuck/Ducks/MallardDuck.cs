using System;
using SimUDuck.Behaviors;

namespace SimUDuck.Ducks
{
    internal class MallardDuck : Duck
    {
        public MallardDuck() : base(new FlyWithWings(), new QuackBehavior(), new WaltzBehavior())
        {
        }

        public override void Display()
        {
            Console.WriteLine("I'm mallard duck!");
        }
    }
}
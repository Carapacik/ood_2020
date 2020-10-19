using System;
using SimUDuck.Behaviors;

namespace SimUDuck.Ducks
{
    internal class DecoyDuck : Duck
    {
        public DecoyDuck() : base(new FlyNoWay(), new NoQuackBehavior(), new NoDanceBehavior())
        {
        }

        public override void Display()
        {
            Console.WriteLine("I'm decoy duck!");
        }
    }
}
using System;
using SimUDuck.Behaviors;

namespace SimUDuck.Ducks
{
    internal class RubberDuck : Duck
    {
        public RubberDuck() : base(new FlyNoWay(), new SqueakBehavior(), new NoDanceBehavior())
        {
        }

        public override void Display()
        {
            Console.WriteLine("I'm rubber duck!");
        }
    }
}
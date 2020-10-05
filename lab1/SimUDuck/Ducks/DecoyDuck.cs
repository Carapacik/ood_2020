using System;
using SimUDuck.DanceBehavior;
using SimUDuck.FlyBehavior;
using SimUDuck.QuackBehaviors;

namespace SimUDuck.Ducks
{
    class DecoyDuck : Duck
    {
        public DecoyDuck() : base(new FlyNoWay(), new NoQuackBehavior(), new NoDanceBehavior())
        { }

        public override void Display()
        {
            Console.WriteLine("I'm decoy duck!");
        }
    }
}

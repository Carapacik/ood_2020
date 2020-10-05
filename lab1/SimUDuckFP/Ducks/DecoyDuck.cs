using System;
using SimUDuckFP.Behaviors;

namespace SimUDuckFP.Ducks
{
    class DecoyDuck : Duck
    {
        public DecoyDuck() : base(FlyBehavior.FlyNoWay, QuackBehavior.NoQuackBehavior, DanceBehavior.NoDanceBehavior) { }

        public override void Display()
        {
            Console.WriteLine("I'm decoy duck!");
        }
    }
}

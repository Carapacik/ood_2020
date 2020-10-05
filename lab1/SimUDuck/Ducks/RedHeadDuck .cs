using System;
using SimUDuck.DanceBehavior;
using SimUDuck.FlyBehavior;
using SimUDuck.QuackBehaviors;

namespace SimUDuck.Ducks
{
    class RedheadDuck : Duck
    {
        public RedheadDuck() : base(new FlyWithWings(), new QuackBehavior(), new MinuetBehavior()) { }

        public override void Display()
        {
            Console.WriteLine("I'm redhead duck!");
        }
    }
}
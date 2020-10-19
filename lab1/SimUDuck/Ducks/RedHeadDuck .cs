using System;
using SimUDuck.Behaviors;

namespace SimUDuck.Ducks
{
    internal class RedheadDuck : Duck
    {
        public RedheadDuck() : base(new FlyWithWings(), new QuackBehavior(), new MinuetBehavior())
        {
        }

        public override void Display()
        {
            Console.WriteLine("I'm redhead duck!");
        }
    }
}
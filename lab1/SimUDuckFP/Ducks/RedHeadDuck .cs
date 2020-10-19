using System;
using SimUDuckFP.Behaviors;

namespace SimUDuckFP.Ducks
{
    internal class RedheadDuck : Duck
    {
        public RedheadDuck() : base(FlyBehavior.FlyWithWings(), QuackBehavior.Quack, DanceBehavior.MinuetBehavior)
        {
        }

        public override void Display()
        {
            Console.WriteLine("I'm redhead duck!");
        }
    }
}
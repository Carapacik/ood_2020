using System;
using SimUDuck.Behaviors;

namespace SimUDuck.Ducks
{
    internal class ModelDuck : Duck
    {
        public ModelDuck() : base(new FlyNoWay(), new QuackBehavior(), new NoDanceBehavior())
        {
        }

        public override void Display()
        {
            Console.WriteLine("I'm model duck!");
        }
    }
}
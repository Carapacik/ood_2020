using System;
using SimUDuck.DanceBehavior;
using SimUDuck.FlyBehavior;
using SimUDuck.QuackBehaviors;

namespace SimUDuck.Ducks
{
    class ModelDuck : Duck
    {
        public ModelDuck() : base(new FlyNoWay(), new QuackBehavior(), new NoDanceBehavior()) { }

        public override void Display()
        {
            Console.WriteLine("I'm model duck!");
        }
    }
}

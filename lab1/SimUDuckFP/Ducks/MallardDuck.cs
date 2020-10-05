using System;
using SimUDuckFP.Behaviors;

namespace SimUDuckFP.Ducks
{
    class MallardDuck : Duck
    {
        public MallardDuck() : base(FlyBehavior.FlyWithWings(), QuackBehavior.Quack, DanceBehavior.WaltzBehavior) { }

        public override void Display()
        {
            Console.WriteLine("I'm mallard duck!");
        }
    }
}

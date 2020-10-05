using System;
using SimUDuck.DanceBehavior;
using SimUDuck.FlyBehavior;
using SimUDuck.QuackBehaviors;

namespace SimUDuck.Ducks
{
    abstract class Duck
    {
        private readonly IDanceBehavior _danceBehavior;
        private IFlyBehavior _flyBehavior;
        private readonly IQuackBehavior _quackBehavior;

        public Duck(IFlyBehavior flyBehavior, IQuackBehavior quackBehavior, IDanceBehavior danceBehavior)
        {
            _danceBehavior = danceBehavior;
            _flyBehavior = flyBehavior;
            _quackBehavior = quackBehavior;
        }

        public void Dance()
        {
            _danceBehavior.Dance();
        }

        public void Fly()
        {
            _flyBehavior.Fly();
        }

        public void Quack()
        {
            _quackBehavior.Quack();
        }

        public void Swim()
        {
            Console.WriteLine("I'm swimming!");
        }

        public void SetFlyBehavior(IFlyBehavior flyBehavior)
        {
            _flyBehavior = flyBehavior;
        }

        public virtual void Display() { }
    }
}

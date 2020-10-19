using System;

namespace SimUDuckFP.Ducks
{
    internal abstract class Duck
    {
        private readonly Action _danceBehavior;
        private Action _flyBehavior;
        private readonly Action _quackBehavior;

        protected Duck(Action flyBehavior, Action quackBehavior, Action danceBehavior)
        {
            _danceBehavior = danceBehavior;
            _flyBehavior = flyBehavior;
            _quackBehavior = quackBehavior;
        }

        public void Dance()
        {
            _danceBehavior();
        }

        public void Fly()
        {
            _flyBehavior();
        }

        public void Quack()
        {
            _quackBehavior();
        }

        public void Swim()
        {
            Console.WriteLine("I'm swimming!");
        }

        public void SetFlyBehavior(Action flyBehavior)
        {
            _flyBehavior = flyBehavior;
        }

        public virtual void Display()
        {
        }
    }
}
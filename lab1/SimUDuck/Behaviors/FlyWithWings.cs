using System;

namespace SimUDuck.Behaviors
{
    internal class FlyWithWings : IFlyBehavior
    {
        private int _flightCounter;

        public void Fly()
        {
            Console.WriteLine($"I'm flying with wings! It's a flight number {++_flightCounter}!");
        }
    }
}
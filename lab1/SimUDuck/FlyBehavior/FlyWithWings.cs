using System;

namespace SimUDuck.FlyBehavior
{
    class FlyWithWings : IFlyBehavior
    {
        private int _flightCounter = 0;
        public void Fly()
        {
            Console.WriteLine($"I'm flying with wings! It's a flight number {++_flightCounter}!");
        }
    }
}

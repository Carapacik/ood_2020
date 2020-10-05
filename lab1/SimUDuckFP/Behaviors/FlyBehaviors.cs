using System;

namespace SimUDuckFP.Behaviors
{
    class FlyBehavior
    {
        public static Action FlyWithWings()
        {
            int flightCount = 0;
            void Fly()
            {
                Console.WriteLine($"I'm flying with wings! It's a flight number {++flightCount}!");
            };

            return Fly;
        }

        public static void FlyNoWay() { }
    }
}

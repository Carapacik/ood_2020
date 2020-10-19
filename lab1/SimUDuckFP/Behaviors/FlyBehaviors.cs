using System;

namespace SimUDuckFP.Behaviors
{
    internal static class FlyBehavior
    {
        public static Action FlyWithWings()
        {
            var flightCount = 0;

            void Fly()
            {
                Console.WriteLine($"I'm flying with wings! It's a flight number {++flightCount}!");
            }

            ;

            return Fly;
        }

        public static void FlyNoWay()
        {
        }
    }
}
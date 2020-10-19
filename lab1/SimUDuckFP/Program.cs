using System;
using SimUDuckFP.Behaviors;
using SimUDuckFP.Ducks;

namespace SimUDuckFP
{
    internal static class Program
    {
        private static void DrawDuck(Duck duck)
        {
            duck.Display();
        }

        private static void PlayWithDuck(Duck duck)
        {
            DrawDuck(duck);
            duck.Quack();
            duck.Fly();
            duck.Dance();
            Console.WriteLine();
        }

        private static void Main()
        {
            var mallardDuck = new MallardDuck();
            PlayWithDuck(mallardDuck);
            var redheadDuck = new RedheadDuck();
            PlayWithDuck(redheadDuck);
            var rubberDuck = new RubberDuck();
            PlayWithDuck(rubberDuck);
            var decoyDuck = new DecoyDuck();
            PlayWithDuck(decoyDuck);
            var modelDuck = new ModelDuck();
            PlayWithDuck(modelDuck);

            modelDuck.SetFlyBehavior(FlyBehavior.FlyWithWings());
            PlayWithDuck(modelDuck);
            PlayWithDuck(modelDuck);
            modelDuck.SetFlyBehavior(FlyBehavior.FlyNoWay);
            PlayWithDuck(modelDuck);
            modelDuck.SetFlyBehavior(FlyBehavior.FlyWithWings());
            PlayWithDuck(modelDuck);
        }
    }
}
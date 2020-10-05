using System;
using SimUDuckFP.Ducks;
using SimUDuckFP.Behaviors;

namespace SimUDuck
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

        private static void Main(string[] args)
        {
            MallardDuck mallardDuck = new MallardDuck();
            PlayWithDuck(mallardDuck);
            RedheadDuck readheadDuck = new RedheadDuck();
            PlayWithDuck(readheadDuck);
            RubberDuck rubberDuck = new RubberDuck();
            PlayWithDuck(rubberDuck);
            DecoyDuck decoyDuck = new DecoyDuck();
            PlayWithDuck(decoyDuck);
            ModelDuck modelDuck = new ModelDuck();
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
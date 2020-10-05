using System;
using SimUDuck.Ducks;
using SimUDuck.FlyBehavior;

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
            duck.Fly();
            duck.Dance();
            duck.Quack();
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

            modelDuck.SetFlyBehavior(new FlyWithWings());
            PlayWithDuck(modelDuck);
            PlayWithDuck(modelDuck);
            modelDuck.SetFlyBehavior(new FlyNoWay());
            PlayWithDuck(modelDuck);
            modelDuck.SetFlyBehavior(new FlyWithWings());
            PlayWithDuck(modelDuck);
        }
    }
}
using System;
using SimUDuck.Behaviors;
using SimUDuck.Ducks;

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
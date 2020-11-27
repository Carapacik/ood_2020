using System;
using MultiGumBallMachine.StateGumBallMachine;

namespace MultiGumBallMachine
{
    internal static class Program
    {
        private static void Main()
        {
            Console.WriteLine("Enter type for GumBall machine: 0 for Naive, 1 for State");
            int type;

            while (!(int.TryParse(Console.ReadLine(), out type) && (type == 1 || type == 0)))
                Console.WriteLine("Wrong input number. Type 0 for Naive, 1 for 1 for State");

            Console.WriteLine("Enter number of balls for GumBall machine");
            uint numBalls;
            while (!uint.TryParse(Console.ReadLine(), out numBalls)) Console.WriteLine("Wrong input number");

            switch (type)
            {
                case 0:
                {
                    TestNaiveGumballMachine(numBalls);
                    break;
                }
                case 1:
                {
                    TestStateGumballMachine(numBalls);
                    break;
                }
            }
        }

        private static void TestStateGumballMachine(uint ballCount)
        {
            var m = new GumBallMachineStd(ballCount);
            Console.WriteLine("Enter a command. For more info enter 'help'");
            var controller = new GumBallMachineController(Console.Out, Console.In, m);
            controller.Start();
        }

        private static void TestNaiveGumballMachine(uint ballCount)
        {
            var m = new NaiveGumBallMachine.NaiveGumBallMachine(ballCount);
            Console.WriteLine("Enter a command. For more info enter 'help'");
            var controller = new GumBallMachineController(Console.Out, Console.In, m);
            controller.Start();
        }
    }
}
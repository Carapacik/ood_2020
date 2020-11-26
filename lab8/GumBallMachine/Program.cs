using System;

namespace GumBallMachine
{
    internal static class Program
    {
        private static void TestGumballMachine(IGumBallMachine m)
        {
            Console.WriteLine(m.ToString());

            m.InsertQuarter();
            m.TurnCrank();

            Console.WriteLine();
            Console.WriteLine(m.ToString());

            m.InsertQuarter();
            m.EjectQuarter();
            m.TurnCrank();

            Console.WriteLine();
            Console.WriteLine(m.ToString());

            m.InsertQuarter();
            m.TurnCrank();
            m.InsertQuarter();
            m.TurnCrank();
            m.EjectQuarter();

            Console.WriteLine();
            Console.WriteLine(m.ToString());

            m.InsertQuarter();
            m.InsertQuarter();
            m.TurnCrank();
            m.InsertQuarter();
            m.TurnCrank();
            m.InsertQuarter();
            m.TurnCrank();

            Console.WriteLine();
            Console.WriteLine(m.ToString());
        }

        private static void Main()
        {
            var m = new GumBallMachine(5);
            TestGumballMachine(m);
        }
    }
}
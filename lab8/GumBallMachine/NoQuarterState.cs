using System;

namespace GumBallMachine
{
    public class NoQuarterState : IState
    {
        private readonly IGumBallMachine _gumBallMachine;

        public NoQuarterState(IGumBallMachine gumBallMachine)
        {
            _gumBallMachine = gumBallMachine;
        }

        public void Dispense()
        {
            Console.WriteLine("You need to pay first");
        }

        public void EjectQuarter()
        {
            Console.WriteLine("You haven't inserted a quarter");
        }

        public void InsertQuarter()
        {
            Console.WriteLine("You inserted a quarter");
            _gumBallMachine.SetHasQuarterState();
        }

        public void TurnCrank()
        {
            Console.WriteLine("You turned but there's no quarter");
        }

        public override string ToString()
        {
            return "waiting for quarter";
        }
    }
}
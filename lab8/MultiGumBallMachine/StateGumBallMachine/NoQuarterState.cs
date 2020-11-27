using System;

namespace MultiGumBallMachine.StateGumBallMachine
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
            _gumBallMachine.AddQuarter();
            _gumBallMachine.SetHasQuarterState();
        }

        public void TurnCrank()
        {
            Console.WriteLine("You turned but there's no quarter");
        }

        public void Refill(uint ballCount)
        {
            _gumBallMachine.RefillBalls(ballCount);
        }

        public override string ToString()
        {
            return "waiting for quarter";
        }
    }
}
using System;

namespace MultiGumBallMachine.StateGumBallMachine
{
    public class HasQuarterState : IState
    {
        private const int MaxQuarterCount = 5;
        private readonly IGumBallMachine _gumBallMachine;

        public HasQuarterState(IGumBallMachine gumBallMachine)
        {
            _gumBallMachine = gumBallMachine;
        }

        public void Dispense()
        {
            Console.WriteLine("No gumball dispensed");
        }

        public void EjectQuarter()
        {
            _gumBallMachine.ReturnQuarters();
            _gumBallMachine.SetNoQuarterState();
        }

        public void InsertQuarter()
        {
            _gumBallMachine.AddQuarter();
            if (_gumBallMachine.QuarterCount == MaxQuarterCount) _gumBallMachine.SetMaxQuarterState();
        }

        public void TurnCrank()
        {
            Console.WriteLine("You turned...");
            _gumBallMachine.SetSoldState();
        }

        public void Refill(uint ballCount)
        {
            _gumBallMachine.RefillBalls(ballCount);
        }

        public override string ToString()
        {
            return "waiting for turn of crank";
        }
    }
}
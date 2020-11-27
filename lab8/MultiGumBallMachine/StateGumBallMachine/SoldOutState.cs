using System;

namespace MultiGumBallMachine.StateGumBallMachine
{
    public class SoldOutState : IState
    {
        private readonly IGumBallMachine _gumBallMachine;

        public SoldOutState(IGumBallMachine gumBallMachine)
        {
            _gumBallMachine = gumBallMachine;
        }

        public void Dispense()
        {
            Console.WriteLine("No gumball dispensed");
        }

        public void EjectQuarter()
        {
            if (_gumBallMachine.QuarterCount > 0)
                _gumBallMachine.ReturnQuarters();
            else
                Console.WriteLine("You can't eject, you haven't inserted a quarter yet");
        }

        public void InsertQuarter()
        {
            Console.WriteLine("You can't insert a quarter, the machine is sold out");
        }

        public void TurnCrank()
        {
            Console.WriteLine("You turned but there's no gumballs");
        }

        public void Refill(uint ballCount)
        {
            _gumBallMachine.RefillBalls(ballCount);
            if (_gumBallMachine.QuarterCount == 0)
                _gumBallMachine.SetNoQuarterState();
            else
                _gumBallMachine.SetHasQuarterState();
        }

        public override string ToString()
        {
            return "sold out";
        }
    }
}
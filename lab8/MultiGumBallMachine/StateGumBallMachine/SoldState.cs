using System;

namespace MultiGumBallMachine.StateGumBallMachine
{
    public class SoldState : IState
    {
        private readonly IGumBallMachine _gumBallMachine;

        public SoldState(IGumBallMachine gumBallMachine)
        {
            _gumBallMachine = gumBallMachine;
        }

        public void Dispense()
        {
            _gumBallMachine.ReleaseBall();
            if (_gumBallMachine.BallCount == 0)
            {
                Console.WriteLine("Oops, out of gumballs");
                _gumBallMachine.SetSoldOutState();
            }
            else if (_gumBallMachine.QuarterCount > 0)
            {
                _gumBallMachine.SetHasQuarterState();
            }
            else
            {
                _gumBallMachine.SetNoQuarterState();
            }
        }

        public void EjectQuarter()
        {
            Console.WriteLine("Sorry you already turned the crank");
        }

        public void InsertQuarter()
        {
            Console.WriteLine("Please wait, we're already giving you a gumball");
        }

        public void TurnCrank()
        {
            Console.WriteLine("Turning twice doesn't get you another gumball");
        }

        public void Refill(uint ballCount)
        {
            Console.WriteLine("Can't refill gumballs when machine is giving you a gumball");
        }

        public override string ToString()
        {
            return "delivering a gumball";
        }
    }
}
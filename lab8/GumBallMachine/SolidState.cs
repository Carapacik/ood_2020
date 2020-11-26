using System;

namespace GumBallMachine
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
            if (_gumBallMachine.GetBallCount() == 0)
            {
                Console.WriteLine("Oops, out of gumballs");
                _gumBallMachine.SetSoldOutState();
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

        public override string ToString()
        {
            return "delivering a gumball";
        }
    }
}
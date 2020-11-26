using System;

namespace GumBallMachine
{
    public class HasQuarterState : IState
    {
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
            Console.WriteLine("Quarter returned");
            _gumBallMachine.SetNoQuarterState();
        }

        public void InsertQuarter()
        {
            Console.WriteLine("You can't insert another quarter");
        }

        public void TurnCrank()
        {
            Console.WriteLine("You turned...");
            _gumBallMachine.SetSoldState();
        }

        public override string ToString()
        {
            return "waiting for turn of crank";
        }
    }
}
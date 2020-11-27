using System;

namespace MultiGumBallMachine.StateGumBallMachine
{
    public class MaxQuarterState : IState
    {
        private readonly IGumBallMachine _gumBallMachine;

        public MaxQuarterState(IGumBallMachine gumBallMachine)
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
            Console.WriteLine("You can't insert another quarter. Max quarters quantity is 5");
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
            return "at the max quarters quantity, waiting for turn of crank";
        }
    }
}
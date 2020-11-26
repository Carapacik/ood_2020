using System;

namespace GumBallMachine
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

        public override string ToString()
        {
            return "sold out";
        }
    }
}
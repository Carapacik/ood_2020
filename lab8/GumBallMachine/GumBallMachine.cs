using System;

namespace GumBallMachine
{
    public class GumBallMachine : IGumBallMachine
    {
        private readonly HasQuarterState _hasQuarterState;
        private readonly NoQuarterState _noQuarterState;
        private readonly SoldOutState _soldOutState;
        private readonly SoldState _soldState;
        private IState _state;

        public GumBallMachine(uint ballCount)
        {
            _soldState = new SoldState(this);
            _soldOutState = new SoldOutState(this);
            _noQuarterState = new NoQuarterState(this);
            _hasQuarterState = new HasQuarterState(this);
            BallCount = ballCount;
            _state = BallCount > 0 ? _noQuarterState : (IState) _soldOutState;
        }

        public uint BallCount { get; private set; }


        public void ReleaseBall()
        {
            if (BallCount == 0) return;
            Console.WriteLine("A gumball comes rolling out the slot...");
            --BallCount;
        }

        public void SetHasQuarterState()
        {
            _state = _hasQuarterState;
        }

        public void SetNoQuarterState()
        {
            _state = _noQuarterState;
        }

        public void SetSoldOutState()
        {
            _state = _soldOutState;
        }

        public void SetSoldState()
        {
            _state = _soldState;
        }

        public void EjectQuarter()
        {
            _state.EjectQuarter();
        }

        public void InsertQuarter()
        {
            _state.InsertQuarter();
        }

        public void TurnCrank()
        {
            _state.TurnCrank();
            _state.Dispense();
        }

        public override string ToString()
        {
            return
                $"Gumball Machine \r\nInventory: {BallCount} gumball{(BallCount != 1 ? "s" : "")}\r\nMachine is {_state}\r\n";
        }
    }
}
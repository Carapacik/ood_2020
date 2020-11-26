using System;

namespace GumBallMachine
{
    public class GumBallMachine : IGumBallMachine
    {
        private readonly HasQuarterState _hasQuarterState;
        private readonly NoQuarterState _noQuarterState;
        private readonly SoldOutState _soldOutState;
        private readonly SoldState _soldState;
        private uint _count;
        private IState _state;

        public GumBallMachine(uint numBalls)
        {
            _soldState = new SoldState(this);
            _soldOutState = new SoldOutState(this);
            _noQuarterState = new NoQuarterState(this);
            _hasQuarterState = new HasQuarterState(this);
            _count = numBalls;
            _state = _count > 0 ? _noQuarterState : (IState) _soldOutState;
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

        public uint GetBallCount()
        {
            return _count;
        }

        public void ReleaseBall()
        {
            if (_count != 0)
            {
                Console.WriteLine("A gumball comes rolling out the slot...");
                --_count;
            }
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

        public override string ToString()
        {
            return
                $"Gumball Machine \r\nInventory: {_count} gumball{(_count != 1 ? "s" : "")}\r\nMachine is {_state}\r\n";
            ;
        }
    }
}
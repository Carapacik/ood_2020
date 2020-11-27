using System;

namespace MultiGumBallMachine.StateGumBallMachine
{
    public class GumBallMachine : IGumBallMachine
    {
        private readonly HasQuarterState _hasQuarterState;
        private readonly MaxQuarterState _maxQuarterState;
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
            _maxQuarterState = new MaxQuarterState(this);
            BallCount = ballCount;
            _state = BallCount > 0 ? _noQuarterState : (IState) _soldOutState;
        }

        public uint BallCount { get; private set; }
        public uint QuarterCount { get; set; }

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

        public void ReleaseBall()
        {
            if (BallCount == 0) return;
            Console.WriteLine("A gumball comes rolling out the slot...");
            --BallCount;
            --QuarterCount;
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

        public void SetMaxQuarterState()
        {
            _state = _maxQuarterState;
        }

        public void AddQuarter()
        {
            QuarterCount++;
            Console.WriteLine($"You inserted a quarter. Quarters count: {QuarterCount}");
        }

        public void ReturnQuarters()
        {
            Console.WriteLine($"Quarter{(QuarterCount > 1 ? "s" : "")} returned");
            QuarterCount = 0;
        }

        public void Refill(uint ballCount)
        {
            if (ballCount > 0)
                _state.Refill(ballCount);
            else
                Console.WriteLine("Cannot refill with no balls");
        }

        public void RefillBalls(uint ballCount)
        {
            BallCount += ballCount;
            Console.WriteLine($"Gumballs refilled. Gumballs count: {BallCount}");
        }

        public override string ToString()
        {
            return $"State Gumball Machine \r\nInventory: {BallCount} gumball{(BallCount != 1 ? "s" : "")}, "
                   + $"{QuarterCount} quarter{(QuarterCount != 1 ? "s" : "")}\r\nMachine is {_state}\r\n";
        }
    }
}
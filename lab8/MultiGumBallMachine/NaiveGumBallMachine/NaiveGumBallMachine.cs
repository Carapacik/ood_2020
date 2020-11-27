using System;
using MultiGumBallMachine.StateGumBallMachine;

namespace MultiGumBallMachine.NaiveGumBallMachine
{
    public class NaiveGumBallMachine : IGumBallMachineStd
    {
        private const int MaxQuarterCount = 5;
        private uint _ballCount;
        private uint _quarterCount;
        private State _state;

        public NaiveGumBallMachine(uint ballCount)
        {
            _ballCount = ballCount;
            _state = ballCount > 0 ? State.NoQuarter : State.SoldOut;
        }

        public void InsertQuarter()
        {
            switch (_state)
            {
                case State.SoldOut:
                    Console.WriteLine("You can't insert a quarter, the machine is sold out");
                    break;
                case State.NoQuarter:
                    AddQuarter();
                    _state = State.HasQuarter;
                    break;
                case State.HasQuarter:
                    AddQuarter();
                    break;
                case State.Sold:
                    Console.WriteLine("Please wait, we're already giving you a gumball");
                    break;
            }
        }

        public void EjectQuarter()
        {
            switch (_state)
            {
                case State.HasQuarter:
                    ReturnQuarters();
                    _state = State.NoQuarter;
                    break;
                case State.NoQuarter:
                    Console.WriteLine("You haven't inserted a quarter");
                    break;
                case State.Sold:
                    Console.WriteLine("Sorry you already turned the crank");
                    break;
                case State.SoldOut:
                    if (_quarterCount > 0)
                        ReturnQuarters();
                    else
                        Console.WriteLine("You can't eject, you haven't inserted a quarter yet");
                    break;
            }
        }

        public void TurnCrank()
        {
            switch (_state)
            {
                case State.SoldOut:
                    Console.WriteLine("You turned but there's no gumballs");
                    break;
                case State.NoQuarter:
                    Console.WriteLine("You turned but there's no quarter");
                    break;
                case State.HasQuarter:
                    Console.WriteLine("You turned...");
                    _state = State.Sold;
                    Dispense();
                    break;
                case State.Sold:
                    Console.WriteLine("Turning twice doesn't get you another gumball");
                    break;
            }
        }

        public void Refill(uint ballCount)
        {
            if (ballCount > 0)
            {
                _ballCount += ballCount;
                _state = _quarterCount > 0 ? State.HasQuarter : State.NoQuarter;
                Console.WriteLine($"Gumballs refilled. Gumballs count: {_ballCount}");
            }
            else
            {
                Console.WriteLine("Cannot refill with no balls");
            }
        }

        private void AddQuarter()
        {
            if (_quarterCount < MaxQuarterCount)
            {
                _quarterCount++;
                Console.WriteLine($"You inserted a quarter. Quarters count: {_quarterCount}");
            }
            else
            {
                Console.WriteLine("You can't insert another quarter. Max quarters quantity is 5");
            }
        }

        private void ReturnQuarters()
        {
            Console.WriteLine($"Quarter{(_quarterCount > 1 ? "s" : "")} returned");
            _quarterCount = 0;
        }

        private void ReleaseBall()
        {
            if (_ballCount != 0)
            {
                Console.WriteLine("A gumball comes rolling out the slot...");
                --_ballCount;
                --_quarterCount;
            }
        }


        private void Dispense()
        {
            switch (_state)
            {
                case State.Sold:
                    ReleaseBall();
                    if (_ballCount == 0)
                    {
                        Console.WriteLine("Oops, out of gumballs");
                        _state = State.SoldOut;
                    }
                    else if (_quarterCount > 0)
                    {
                        _state = State.HasQuarter;
                    }
                    else
                    {
                        _state = State.NoQuarter;
                    }

                    break;
                case State.NoQuarter:
                    Console.WriteLine("You need to pay first");
                    break;
                case State.SoldOut:
                case State.HasQuarter:
                    Console.WriteLine("No gumball dispensed");
                    break;
            }
        }

        public override string ToString()
        {
            var state = _state switch
            {
                State.SoldOut => "sold out",
                State.NoQuarter => "waiting for quarter",
                State.HasQuarter => "waiting for turn of crank",
                _ => "delivering a gumball"
            };

            return
                $"Naive Gumball Machine \r\nInventory: {_ballCount} gumball{(_ballCount != 1 ? "s" : "")}, {_quarterCount} "
                + $"quarter{(_quarterCount != 1 ? "s" : "")}\r\nMachine is {state}\r\n";
        }

        private enum State
        {
            SoldOut,
            NoQuarter,
            HasQuarter,
            Sold
        }
    }
}
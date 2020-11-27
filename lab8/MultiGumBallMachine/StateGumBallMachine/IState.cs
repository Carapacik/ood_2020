namespace MultiGumBallMachine.StateGumBallMachine
{
    public interface IState
    {
        void InsertQuarter();
        void EjectQuarter();
        void TurnCrank();
        void Dispense();
        void Refill(uint ballCount);
    }
}
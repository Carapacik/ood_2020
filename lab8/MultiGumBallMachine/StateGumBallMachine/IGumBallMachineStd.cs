namespace MultiGumBallMachine.StateGumBallMachine
{
    public interface IGumBallMachineStd
    {
        void EjectQuarter();
        void InsertQuarter();
        void TurnCrank();
        void Refill(uint ballCount);
    }
}
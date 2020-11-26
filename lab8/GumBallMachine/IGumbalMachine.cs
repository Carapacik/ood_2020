namespace GumBallMachine
{
    public interface IGumBallMachine
    {
        void InsertQuarter();
        void TurnCrank();
        void EjectQuarter();
        void ReleaseBall();
        uint GetBallCount();
        void SetSoldState();
        void SetSoldOutState();
        void SetHasQuarterState();
        void SetNoQuarterState();
    }
}
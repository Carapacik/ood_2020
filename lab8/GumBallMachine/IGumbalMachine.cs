namespace GumBallMachine
{
    public interface IGumBallMachine : IGumBallMachineStd
    {
        uint BallCount { get; }
        void ReleaseBall();
        void SetSoldState();
        void SetSoldOutState();
        void SetHasQuarterState();
        void SetNoQuarterState();
    }
}
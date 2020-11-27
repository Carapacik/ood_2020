namespace MultiGumBallMachine.StateGumBallMachine
{
    public interface IGumBallMachine : IGumBallMachineStd
    {
        uint BallCount { get; }
        uint QuarterCount { get; set; }
        void ReleaseBall();
        void SetSoldOutState();
        void SetNoQuarterState();
        void SetSoldState();
        void SetHasQuarterState();
        void SetMaxQuarterState();
        void AddQuarter();
        void ReturnQuarters();
        void RefillBalls(uint ballCount);
    }
}
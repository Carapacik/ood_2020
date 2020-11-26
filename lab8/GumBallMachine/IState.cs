namespace GumBallMachine
{
    public interface IState
    {
        void InsertQuarter();
        void TurnCrank();
        void EjectQuarter();
        void Dispense();
        string ToString();
    }
}
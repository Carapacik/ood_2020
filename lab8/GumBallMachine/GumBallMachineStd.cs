namespace GumBallMachine
{
    public class GumBallMachineStd : IGumBallMachineStd
    {
        private readonly IGumBallMachine _gumBallMachine;

        public GumBallMachineStd(uint ballCount)
        {
            _gumBallMachine = new GumBallMachine(ballCount);
        }

        public void EjectQuarter()
        {
            _gumBallMachine.EjectQuarter();
        }

        public void InsertQuarter()
        {
            _gumBallMachine.InsertQuarter();
        }

        public void TurnCrank()
        {
            _gumBallMachine.TurnCrank();
        }

        public override string ToString()
        {
            return _gumBallMachine.ToString();
        }
    }
}
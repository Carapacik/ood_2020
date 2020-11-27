namespace MultiGumBallMachine.StateGumBallMachine
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

        public void Refill(uint ballCount)
        {
            _gumBallMachine.Refill(ballCount);
        }

        public override string ToString()
        {
            return _gumBallMachine.ToString();
        }
    }
}
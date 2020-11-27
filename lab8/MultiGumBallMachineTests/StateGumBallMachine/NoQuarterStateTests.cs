using Xunit;

namespace MultiGumBallMachineTests.StateGumBallMachine
{
    public class NoQuarterStateTests
    {
        [Fact]
        public void InsertQuarter_ShouldChangeStateOfMachineOnHasQuarter()
        {
            var m = new MultiGumBallMachine.StateGumBallMachine.GumBallMachine(3);
            Assert.Equal(Extensions.GetStateGumBallMachineString(3, 0, "waiting for quarter"), m.ToString());

            m.InsertQuarter();
            Assert.Equal(Extensions.GetStateGumBallMachineString(3, 1, "waiting for turn of crank"), m.ToString());
        }

        [Fact]
        public void EjectQuarter_NoQuartersInMachine_ShouldNotChangeStateOfMachine()
        {
            var m = new MultiGumBallMachine.StateGumBallMachine.GumBallMachine(3);

            m.EjectQuarter();
            Assert.Equal(Extensions.GetStateGumBallMachineString(3, 0, "waiting for quarter"), m.ToString());
        }

        [Fact]
        public void TurnCrank_ShouldNotChangeStateOfMachine()
        {
            var m = new MultiGumBallMachine.StateGumBallMachine.GumBallMachine(3);

            m.TurnCrank();
            Assert.Equal(Extensions.GetStateGumBallMachineString(3, 0, "waiting for quarter"), m.ToString());
        }

        [Fact]
        public void Refill_ShouldChangeStateOfMachine()
        {
            var m = new MultiGumBallMachine.StateGumBallMachine.GumBallMachine(4);
            Assert.Equal(Extensions.GetStateGumBallMachineString(4, 0, "waiting for quarter"), m.ToString());

            m.Refill(6);
            Assert.Equal(Extensions.GetStateGumBallMachineString(10, 0, "waiting for quarter"), m.ToString());
        }
    }
}
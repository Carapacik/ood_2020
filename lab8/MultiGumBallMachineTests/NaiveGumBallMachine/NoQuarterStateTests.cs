using Xunit;

namespace MultiGumBallMachineTests.NaiveGumBallMachine
{
    public class NoQuarterStateTests
    {
        [Fact]
        public void InsertQuarter_ShouldChangeStateOfMachineOnHasQuarter()
        {
            var m = new MultiGumBallMachine.NaiveGumBallMachine.NaiveGumBallMachine(3);
            Assert.Equal(Extensions.GetNaiveGumBallMachineString(3, 0, "waiting for quarter"), m.ToString());

            m.InsertQuarter();
            Assert.Equal(Extensions.GetNaiveGumBallMachineString(3, 1, "waiting for turn of crank"), m.ToString());
        }

        [Fact]
        public void EjectQuarter_NoQuartersInMachine_ShouldNotChangeStateOfMachine()
        {
            var m = new MultiGumBallMachine.NaiveGumBallMachine.NaiveGumBallMachine(3);

            m.EjectQuarter();
            Assert.Equal(Extensions.GetNaiveGumBallMachineString(3, 0, "waiting for quarter"), m.ToString());
        }

        [Fact]
        public void TurnCrank_ShouldNotChangeStateOfMachine()
        {
            var m = new MultiGumBallMachine.NaiveGumBallMachine.NaiveGumBallMachine(3);

            m.TurnCrank();
            Assert.Equal(Extensions.GetNaiveGumBallMachineString(3, 0, "waiting for quarter"), m.ToString());
        }
    }
}
using Xunit;

namespace MultiGumBallMachineTests.StateGumBallMachine
{
    public class SoldOutStateTests
    {
        [Fact]
        public void InsertQuarter_ShouldNotChangeStateOfMachineAndNotIncreaseQuartersCount()
        {
            var m = new MultiGumBallMachine.StateGumBallMachine.GumBallMachine(0);

            m.InsertQuarter();
            Assert.Equal(Extensions.GetStateGumBallMachineString(0, 0, "sold out"), m.ToString());
        }

        [Fact]
        public void EjectQuarter_QuartersInMachine_ShouldNotChangeStateOfMachineAndEjectAllQuarters()
        {
            var m = new MultiGumBallMachine.StateGumBallMachine.GumBallMachine(0);
            Assert.Equal(Extensions.GetStateGumBallMachineString(0, 0, "sold out"), m.ToString());

            m.QuarterCount = 2;
            Assert.Equal(Extensions.GetStateGumBallMachineString(0, 2, "sold out"), m.ToString());
            m.EjectQuarter();
            Assert.Equal(Extensions.GetStateGumBallMachineString(0, 0, "sold out"), m.ToString());
        }

        [Fact]
        public void TurnCrank_ShouldNotChangeStateOfMachine()
        {
            var m = new MultiGumBallMachine.StateGumBallMachine.GumBallMachine(0);

            m.TurnCrank();
            Assert.Equal(Extensions.GetStateGumBallMachineString(0, 0, "sold out"), m.ToString());
        }

        [Fact]
        public void Refill_WithoutQuarters_ShouldChangeStateOfMachine()
        {
            var m = new MultiGumBallMachine.StateGumBallMachine.GumBallMachine(0);
            Assert.Equal(Extensions.GetStateGumBallMachineString(0, 0, "sold out"), m.ToString());

            m.Refill(5);
            Assert.Equal(Extensions.GetStateGumBallMachineString(5, 0, "waiting for quarter"), m.ToString());
        }

        [Fact]
        public void Refill_WithFewQuarters_ShouldChangeStateOfMachine()
        {
            var m = new MultiGumBallMachine.StateGumBallMachine.GumBallMachine(0) {QuarterCount = 5};
            Assert.Equal(Extensions.GetStateGumBallMachineString(0, 5, "sold out"), m.ToString());

            m.Refill(5);
            Assert.Equal(Extensions.GetStateGumBallMachineString(5, 5, "waiting for turn of crank"), m.ToString());
        }
    }
}
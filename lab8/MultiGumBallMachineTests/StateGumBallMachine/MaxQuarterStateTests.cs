using Xunit;

namespace MultiGumBallMachineTests.StateGumBallMachine
{
    public class MaxQuarterStateTests
    {
        [Fact]
        public void InsertQuarter_ShouldNotChangeStateOfMachine()
        {
            var m = new MultiGumBallMachine.StateGumBallMachine.GumBallMachine(3);
            m.InsertQuarter();
            m.InsertQuarter();
            m.InsertQuarter();
            m.InsertQuarter();
            m.InsertQuarter();
            Assert.Equal(
                Extensions.GetStateGumBallMachineString(3, 5,
                    "at the max quarters quantity, waiting for turn of crank"), m.ToString());

            m.InsertQuarter();
            Assert.Equal(
                Extensions.GetStateGumBallMachineString(3, 5,
                    "at the max quarters quantity, waiting for turn of crank"),
                m.ToString());
        }

        [Fact]
        public void EjectQuarter_QuartersInMachine_ShouldNotChangeStateOfMachineOnNoQuarterAndEjectAllQuarters()
        {
            var m = new MultiGumBallMachine.StateGumBallMachine.GumBallMachine(3);
            m.InsertQuarter();
            m.InsertQuarter();
            m.InsertQuarter();
            m.InsertQuarter();
            m.InsertQuarter();

            m.EjectQuarter();
            Assert.Equal(Extensions.GetStateGumBallMachineString(3, 0, "waiting for quarter"), m.ToString());
        }

        [Fact]
        public void TurnCrank_OneBallInMachine_ShouldNotChangeStateOfMachine()
        {
            var m = new MultiGumBallMachine.StateGumBallMachine.GumBallMachine(1);
            m.InsertQuarter();
            m.InsertQuarter();
            m.InsertQuarter();
            m.InsertQuarter();
            m.InsertQuarter();

            m.TurnCrank();
            Assert.Equal(Extensions.GetStateGumBallMachineString(0, 4, "sold out"), m.ToString());
        }

        [Fact]
        public void TurnCrank_FewBallsInMachine_ShouldNotChangeStateOfMachine()
        {
            var m = new MultiGumBallMachine.StateGumBallMachine.GumBallMachine(3);
            m.InsertQuarter();
            m.InsertQuarter();
            m.InsertQuarter();
            m.InsertQuarter();
            m.InsertQuarter();

            m.TurnCrank();
            Assert.Equal(Extensions.GetStateGumBallMachineString(2, 4, "waiting for turn of crank"), m.ToString());
        }

        [Fact]
        public void Refill_ShouldNotChangeStateOfMachine()
        {
            var m = new MultiGumBallMachine.StateGumBallMachine.GumBallMachine(3);
            m.InsertQuarter();
            m.InsertQuarter();
            m.InsertQuarter();
            m.InsertQuarter();
            m.InsertQuarter();
            Assert.Equal(
                Extensions.GetStateGumBallMachineString(3, 5,
                    "at the max quarters quantity, waiting for turn of crank"), m.ToString());

            m.Refill(5);
            Assert.Equal(
                Extensions.GetStateGumBallMachineString(8, 5,
                    "at the max quarters quantity, waiting for turn of crank"), m.ToString());
        }
    }
}
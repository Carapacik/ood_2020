using Xunit;

namespace MultiGumBallMachineTests.NaiveGumBallMachine
{
    public class MaxQuarterStateTests
    {
        [Fact]
        public void InsertQuarter_ShouldNotChangeStateOfMachine()
        {
            var m = new MultiGumBallMachine.NaiveGumBallMachine.NaiveGumBallMachine(3);
            m.InsertQuarter();
            m.InsertQuarter();
            m.InsertQuarter();
            m.InsertQuarter();
            m.InsertQuarter();
            Assert.Equal(Extensions.GetNaiveGumBallMachineString(3, 5, "waiting for turn of crank"), m.ToString());

            m.InsertQuarter();
            Assert.Equal(
                Extensions.GetNaiveGumBallMachineString(3, 5, "waiting for turn of crank"),
                m.ToString());
        }

        [Fact]
        public void EjectQuarter_QuartersInMachine_ShouldNotChangeStateOfMachineOnNoQuarterAndEjectAllQuarters()
        {
            var m = new MultiGumBallMachine.NaiveGumBallMachine.NaiveGumBallMachine(3);
            m.InsertQuarter();
            m.InsertQuarter();
            m.InsertQuarter();
            m.InsertQuarter();
            m.InsertQuarter();

            m.EjectQuarter();
            Assert.Equal(Extensions.GetNaiveGumBallMachineString(3, 0, "waiting for quarter"), m.ToString());
        }

        [Fact]
        public void TurnCrank_OneBallInMachine_ShouldNotChangeStateOfMachine()
        {
            var m = new MultiGumBallMachine.NaiveGumBallMachine.NaiveGumBallMachine(1);
            m.InsertQuarter();
            m.InsertQuarter();
            m.InsertQuarter();
            m.InsertQuarter();
            m.InsertQuarter();

            m.TurnCrank();
            Assert.Equal(Extensions.GetNaiveGumBallMachineString(0, 4, "sold out"), m.ToString());
        }

        [Fact]
        public void TurnCrank_FewBallsInMachine_ShouldNotChangeStateOfMachine()
        {
            var m = new MultiGumBallMachine.NaiveGumBallMachine.NaiveGumBallMachine(3);
            m.InsertQuarter();
            m.InsertQuarter();
            m.InsertQuarter();
            m.InsertQuarter();
            m.InsertQuarter();

            m.TurnCrank();
            Assert.Equal(Extensions.GetNaiveGumBallMachineString(2, 4, "waiting for turn of crank"), m.ToString());
        }
    }
}
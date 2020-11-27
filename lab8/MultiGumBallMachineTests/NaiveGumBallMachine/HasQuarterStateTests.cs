using Xunit;

namespace MultiGumBallMachineTests.NaiveGumBallMachine
{
    public class HasQuarterStateTests
    {
        [Fact]
        public void InsertQuarter_ShouldNotChangeStateOfMachineAndIncreaseQuartersCount()
        {
            var m = new MultiGumBallMachine.NaiveGumBallMachine.NaiveGumBallMachine(1);
            m.InsertQuarter();
            Assert.Equal(Extensions.GetNaiveGumBallMachineString(1, 1, "waiting for turn of crank"), m.ToString());

            m.InsertQuarter();
            Assert.Equal(Extensions.GetNaiveGumBallMachineString(1, 2, "waiting for turn of crank"), m.ToString());
        }

        [Fact]
        public void EjectQuarter_ShouldChangeStateOfMachineOnNoQuarterStateAndEjectAllQuarters()
        {
            var m = new MultiGumBallMachine.NaiveGumBallMachine.NaiveGumBallMachine(1);
            m.InsertQuarter();

            m.EjectQuarter();
            Assert.Equal(Extensions.GetNaiveGumBallMachineString(1, 0, "waiting for quarter"), m.ToString());
        }

        [Fact]
        public void TurnCrank_OneBallInMachine_ShouldChangeStateOfMachineOnSoldOutAndDecreaseBallCount()
        {
            var m = new MultiGumBallMachine.NaiveGumBallMachine.NaiveGumBallMachine(1);
            m.InsertQuarter();

            m.TurnCrank();
            Assert.Equal(Extensions.GetNaiveGumBallMachineString(0, 0, "sold out"), m.ToString());
        }

        [Fact]
        public void TurnCrank_FewBallInMachine_ShouldChangeStateOfMachineOnSoldOutAndDecreaseBallCount()
        {
            var m = new MultiGumBallMachine.NaiveGumBallMachine.NaiveGumBallMachine(3);
            m.InsertQuarter();

            m.TurnCrank();
            Assert.Equal(Extensions.GetNaiveGumBallMachineString(2, 0, "waiting for quarter"), m.ToString());
        }

        [Fact]
        public void TurnCrank_FewBallsInMachine_ShouldChangeStateOfMachineOnHasQuarterAndDecreaseBallCount()
        {
            var m = new MultiGumBallMachine.NaiveGumBallMachine.NaiveGumBallMachine(2);
            m.InsertQuarter();

            m.InsertQuarter();
            m.TurnCrank();
            Assert.Equal(Extensions.GetNaiveGumBallMachineString(1, 1, "waiting for turn of crank"), m.ToString());
        }
    }
}
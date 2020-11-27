using Xunit;

namespace MultiGumBallMachineTests.NaiveGumBallMachine
{
    public class SoldOutStateTests
    {
        [Fact]
        public void InsertQuarter_ShouldNotChangeStateOfMachineAndNotIncreaseQuartersCount()
        {
            var m = new MultiGumBallMachine.NaiveGumBallMachine.NaiveGumBallMachine(0);

            m.InsertQuarter();
            Assert.Equal(Extensions.GetNaiveGumBallMachineString(0, 0, "sold out"), m.ToString());
        }

        [Fact]
        public void TurnCrank_ShouldNotChangeStateOfMachine()
        {
            var m = new MultiGumBallMachine.NaiveGumBallMachine.NaiveGumBallMachine(0);

            m.TurnCrank();
            Assert.Equal(Extensions.GetNaiveGumBallMachineString(0, 0, "sold out"), m.ToString());
        }
    }
}
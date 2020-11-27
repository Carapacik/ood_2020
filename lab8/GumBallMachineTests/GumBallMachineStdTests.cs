using GumBallMachine;
using Xunit;

namespace GumBallMachineTests
{
    public class GumBallMachineStdTests
    {
        private static string GetGumBallMachineString(uint count, string state)
        {
            return $"Gumball Machine \r\nInventory: {count} gumball{(count != 1 ? "s" : "")}\r\nMachine is {state}\r\n";
        }

        [Fact]
        public void GumBallMachineStd_ShouldCreate()
        {
            var m = new GumBallMachineStd(5);
            Assert.Equal(GetGumBallMachineString(5, "waiting for quarter"), m.ToString());
        }

        [Fact]
        public void EjectQuarter_WithFewBalls_ShouldEjectQuarter()
        {
            var m = new GumBallMachineStd(5);
            m.EjectQuarter();
            Assert.Equal(GetGumBallMachineString(5, "waiting for quarter"), m.ToString());
        }

        [Fact]
        public void InsertQuarter_ShouldInsertQuarter()
        {
            var m = new GumBallMachineStd(5);
            m.InsertQuarter();
            Assert.Equal(GetGumBallMachineString(5, "waiting for turn of crank"), m.ToString());
        }

        [Fact]
        public void TurnCrank_InsertQuarter_ShouldTurnCrank()
        {
            var m = new GumBallMachineStd(5);
            m.InsertQuarter();
            m.TurnCrank();
            Assert.Equal(GetGumBallMachineString(4, "waiting for quarter"), m.ToString());
        }
    }
}
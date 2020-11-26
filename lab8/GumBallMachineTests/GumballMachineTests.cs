using Xunit;

namespace GumBallMachineTests
{
    public class GumballMachineTests
    {
        private static string GetGumBallMachineString(uint count, string state)
        {
            return $"Gumball Machine \r\nInventory: {count} gumball{(count != 1 ? "s" : "")}\r\nMachine is {state}\r\n";
        }

        [Fact]
        public void GumballMachine_WithBalls_ShouldHaveNoQuarterState()
        {
            var m = new GumBallMachine.GumBallMachine(5);
            Assert.Equal(GetGumBallMachineString(5, "waiting for quarter"), m.ToString());
        }

        [Fact]
        public void GumballMachine_WithoutBalls_ShouldHaveSoldOutState()
        {
            var m = new GumBallMachine.GumBallMachine(0);
            Assert.Equal(GetGumBallMachineString(0, "sold out"), m.ToString());
        }

        [Fact]
        public void ReleaseBall_WithBalls_ShouldReleaseOneBall()
        {
            var m = new GumBallMachine.GumBallMachine(4);
            m.ReleaseBall();
            Assert.Equal((uint) 3, m.GetBallCount());
        }

        [Fact]
        public void ReleaseBall_WithoutBalls_ShouldNotReleaseBall()
        {
            var m = new GumBallMachine.GumBallMachine(0);
            m.ReleaseBall();
            Assert.Equal((uint) 0, m.GetBallCount());
        }

        [Fact]
        public void GetBallCount_FewBalls_ShouldReturnBallCount()
        {
            var m = new GumBallMachine.GumBallMachine(5);
            Assert.Equal((uint) 5, m.GetBallCount());
        }

        [Fact]
        public void SetSoldState_ShouldSetSoldState()
        {
            var m = new GumBallMachine.GumBallMachine(5);
            m.SetSoldState();
            Assert.Equal(GetGumBallMachineString(5, "delivering a gumball"), m.ToString());
        }

        [Fact]
        public void SetSoldOutState_ShouldSetSoldOutState()
        {
            var m = new GumBallMachine.GumBallMachine(5);
            m.SetSoldOutState();
            Assert.Equal(GetGumBallMachineString(5, "sold out"), m.ToString());
        }

        [Fact]
        public void SetHasQuarterState_ShouldSetHasQuarterState()
        {
            var m = new GumBallMachine.GumBallMachine(5);
            m.SetHasQuarterState();
            Assert.Equal(GetGumBallMachineString(5, "waiting for turn of crank"), m.ToString());
        }

        [Fact]
        public void SetNoQuarterState_ShouldSetNoQuarterState()
        {
            var m = new GumBallMachine.GumBallMachine(5);
            m.SetNoQuarterState();
            Assert.Equal(GetGumBallMachineString(5, "waiting for quarter"), m.ToString());
        }

        [Fact]
        public void InsertQuarter_SoldOutState_ShouldNotChangeState()
        {
            var m = new GumBallMachine.GumBallMachine(0);
            m.InsertQuarter();
            Assert.Equal((uint) 0, m.GetBallCount());
            Assert.Equal(GetGumBallMachineString(0, "sold out"), m.ToString());
        }

        [Fact]
        public void InsertQuarter_NoQuarterState_ShouldChangeStateToHasQuarterState()
        {
            var m = new GumBallMachine.GumBallMachine(5);
            m.InsertQuarter();
            Assert.Equal((uint) 5, m.GetBallCount());
            Assert.Equal(GetGumBallMachineString(5, "waiting for turn of crank"), m.ToString());
        }

        [Fact]
        public void InsertQuarter_HasQuarterState_ShouldNotChangeState()
        {
            var m = new GumBallMachine.GumBallMachine(5);
            m.InsertQuarter();
            m.InsertQuarter();
            Assert.Equal((uint) 5, m.GetBallCount());
            Assert.Equal(GetGumBallMachineString(5, "waiting for turn of crank"), m.ToString());
        }

        [Fact]
        public void TurnCrank_SoldOutState_ShouldNotChangeState()
        {
            var m = new GumBallMachine.GumBallMachine(0);
            m.TurnCrank();
            Assert.Equal((uint) 0, m.GetBallCount());
            Assert.Equal(GetGumBallMachineString(0, "sold out"), m.ToString());
        }

        [Fact]
        public void TurnCrank_NoQuarterState_ShouldNotChangeState()
        {
            var m = new GumBallMachine.GumBallMachine(5);
            m.TurnCrank();
            Assert.Equal((uint) 5, m.GetBallCount());
            Assert.Equal(GetGumBallMachineString(5, "waiting for quarter"), m.ToString());
        }

        [Fact]
        public void TurnCrank_WithOneBallInHasQuarterState_ShouldChangeGMStateToSoldOutState()
        {
            var m = new GumBallMachine.GumBallMachine(1);
            m.InsertQuarter();
            m.TurnCrank();
            Assert.Equal((uint) 0, m.GetBallCount());
            Assert.Equal(GetGumBallMachineString(0, "sold out"), m.ToString());
        }

        [Fact]
        public void TurnCrank_WithFewBallsInHasQuarterState_ShouldChangeStateToNoQuarterState()
        {
            var m = new GumBallMachine.GumBallMachine(2);
            m.InsertQuarter();
            m.TurnCrank();
            Assert.Equal((uint) 1, m.GetBallCount());
            Assert.Equal(GetGumBallMachineString(1, "waiting for quarter"), m.ToString());
        }

        [Fact]
        public void EjectQuarter_SoldOutState_ShouldNotChangeState()
        {
            var m = new GumBallMachine.GumBallMachine(0);
            m.EjectQuarter();
            Assert.Equal((uint) 0, m.GetBallCount());
            Assert.Equal(GetGumBallMachineString(0, "sold out"), m.ToString());
        }

        [Fact]
        public void EjectQuarter_NoQuarterState_ShouldNotChangeState()
        {
            var m = new GumBallMachine.GumBallMachine(5);
            m.EjectQuarter();
            Assert.Equal((uint) 5, m.GetBallCount());
            Assert.Equal(GetGumBallMachineString(5, "waiting for quarter"), m.ToString());
        }

        [Fact]
        public void EjectQuarter_HasQuarterState_ShouldChangeStateToNoQuarterState()
        {
            var m = new GumBallMachine.GumBallMachine(1);
            m.InsertQuarter();
            m.EjectQuarter();
            Assert.Equal((uint) 1, m.GetBallCount());
            Assert.Equal(GetGumBallMachineString(1, "waiting for quarter"), m.ToString());
        }
    }
}
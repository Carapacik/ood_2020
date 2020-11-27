using Xunit;

namespace MultiGumBallMachineTests
{
    public class GumBallMachineStdTests
    {
        [Fact]
        public void Refill_WithFewBalls_ShouldRefill()
        {
            var m = new MultiGumBallMachine.StateGumBallMachine.GumBallMachine(5);
            m.Refill(4);
            Assert.Equal(Extensions.GetStateGumBallMachineString(9, 0, "waiting for quarter"), m.ToString());
        }
    }
}
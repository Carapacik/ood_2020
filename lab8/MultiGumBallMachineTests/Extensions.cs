namespace MultiGumBallMachineTests
{
    public static class Extensions
    {
        public static string GetStateGumBallMachineString(uint ballCount, uint quarterCount, string state)
        {
            return
                $"State Gumball Machine \r\nInventory: {ballCount} gumball{(ballCount != 1 ? "s" : "")}, {quarterCount} "
                + $"quarter{(quarterCount != 1 ? "s" : "")}\r\nMachine is {state}\r\n";
        }

        public static string GetNaiveGumBallMachineString(uint ballCount, uint quarterCount, string state)
        {
            return
                $"Naive Gumball Machine \r\nInventory: {ballCount} gumball{(ballCount != 1 ? "s" : "")}, {quarterCount} "
                + $"quarter{(quarterCount != 1 ? "s" : "")}\r\nMachine is {state}\r\n";
        }
    }
}
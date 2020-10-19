namespace Coffee
{
    public enum CoffeeSize
    {
        Standard,
        Double
    }

    public class Coffee : Beverage
    {
        public Coffee(string description = "Coffee") : base(description)
        {
        }

        public override double GetCost()
        {
            return 60;
        }
    }
}
namespace Coffee
{

    public class Cappuccino : Coffee
    {
        private readonly CoffeeSize _cappuccinoSize;

        public Cappuccino(CoffeeSize cappuccinoSize = CoffeeSize.Standard) : base(
            $"{cappuccinoSize} Cappuccino")
        {
            _cappuccinoSize = cappuccinoSize;
        }

        public override double GetCost()
        {
            return _cappuccinoSize == CoffeeSize.Standard ? 80 : 120;
        }
    }
}
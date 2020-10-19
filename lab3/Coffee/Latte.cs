namespace Coffee
{

    public class Latte : Coffee
    {
        private readonly CoffeeSize _latteSize;

        public Latte(CoffeeSize latteSize) : base($"{latteSize.ToString()} Latte")
        {
            _latteSize = latteSize;
        }

        public override double GetCost()
        {
            return _latteSize == CoffeeSize.Standard ? 90 : 130;
        }
    }
}
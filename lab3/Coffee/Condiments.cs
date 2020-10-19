namespace Coffee
{
    public abstract class CondimentDecorator : IBeverage
    {
        private readonly IBeverage _beverage;

        public string GetDescription()
        {
            return _beverage.GetDescription() + ", " + GetCondimentDescription();
        }

        public double GetCost()
        {
            return _beverage.GetCost() + GetCondimentCost();
        }

        protected CondimentDecorator(IBeverage beverage)
        {
            _beverage = beverage;
        }

        protected abstract double GetCondimentCost();

        protected abstract string GetCondimentDescription();
    }

    public class Cinnamon : CondimentDecorator
    {
        public Cinnamon(IBeverage beverage) : base(beverage)
        {
        }

        protected override double GetCondimentCost()
        {
            return 20;
        }

        protected override string GetCondimentDescription()
        {
            return "Cinnamon";
        }
    }

    public class Lemon : CondimentDecorator
    {
        private readonly uint _quantity;

        public Lemon(IBeverage beverage, uint quantity = 1) : base(beverage)
        {
            _quantity = quantity;
        }

        protected override double GetCondimentCost()
        {
            return 10 * _quantity;
        }

        protected override string GetCondimentDescription()
        {
            return "Lemon x " + _quantity;
        }
    }

    public enum IceCubeType
    {
        Dry,
        Water
    }

    public class IceCubes : CondimentDecorator
    {
        private readonly uint _quantity;
        private readonly IceCubeType _cubeType;

        public IceCubes(IBeverage beverage, uint quantity, IceCubeType cubeType) : base(beverage)
        {
            _quantity = quantity;
            _cubeType = cubeType;
        }

        protected override double GetCondimentCost()
        {
            return (_cubeType == IceCubeType.Dry ? 10 : 5) * _quantity;
        }

        protected override string GetCondimentDescription()
        {
            return $"{_cubeType.ToString()} ice cubes x {_quantity}";
        }
    }

    public enum SyrupType
    {
        Chocolate,
        Maple
    }

    public class Syrup : CondimentDecorator
    {
        private readonly SyrupType _syrupType;

        public Syrup(IBeverage beverage, SyrupType syrupType) : base(beverage)
        {
            _syrupType = syrupType;
        }

        protected override double GetCondimentCost()
        {
            return 15;
        }

        protected override string GetCondimentDescription()
        {
            return $"{(_syrupType == SyrupType.Chocolate ? "Chocolate" : "Maple")} syrup";
        }
    }

    public class ChocolateCrumbs : CondimentDecorator
    {
        private readonly uint _mass;

        public ChocolateCrumbs(IBeverage beverage, uint mass) : base(beverage)
        {
            _mass = mass;
        }

        protected override double GetCondimentCost()
        {
            return 2 * _mass;
        }

        protected override string GetCondimentDescription()
        {
            return $"Chocolate crumbs {_mass} g";
        }
    }

    public class CoconutFlakes : CondimentDecorator
    {
        private readonly uint _mass;

        public CoconutFlakes(IBeverage beverage, uint mass) : base(beverage)
        {
            _mass = mass;
        }

        protected override double GetCondimentCost()
        {
            return _mass;
        }

        protected override string GetCondimentDescription()
        {
            return $"Coconut flakes {_mass} g";
        }
    }

    public class Cream : CondimentDecorator
    {
        public Cream(IBeverage beverage) : base(beverage)
        {
        }

        protected override double GetCondimentCost()
        {
            return 25;
        }

        protected override string GetCondimentDescription()
        {
            return "Cream";
        }
    }

    public class Chocolate : CondimentDecorator
    {
        private readonly uint _quantity;

        public Chocolate(IBeverage beverage, uint quantity) : base(beverage)
        {
            if (quantity > 5)
                quantity = 5;

            _quantity = quantity;
        }

        protected override double GetCondimentCost()
        {
            return 10 * _quantity;
        }

        protected override string GetCondimentDescription()
        {
            return $"Chocolate {_quantity} slices";
        }
    }

    public enum LiquorType
    {
        Nut,
        Chocolate
    }

    public class Liquor : CondimentDecorator
    {
        private readonly LiquorType _liquorType;

        public Liquor(IBeverage beverage, LiquorType liquorType) : base(beverage)
        {
            _liquorType = liquorType;
        }

        protected override double GetCondimentCost()
        {
            return 50;
        }

        protected override string GetCondimentDescription()
        {
            return $"{_liquorType.ToString()} Liquor";
        }
    }
}
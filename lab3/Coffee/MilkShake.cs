using System;

namespace Coffee
{
    public enum MilkShakeSize
    {
        Small,
        Medium,
        Large
    }

    public class MilkShake : Beverage
    {
        private readonly MilkShakeSize _milkShakeSize;

        public MilkShake(MilkShakeSize milkShakeSize) : base(milkShakeSize + " " + "MilkShake")
        {
            _milkShakeSize = milkShakeSize;
        }

        public override double GetCost()
        {
            return _milkShakeSize switch
            {
                MilkShakeSize.Small => 50,
                MilkShakeSize.Medium => 60,
                MilkShakeSize.Large => 80,
                _ => throw new Exception("Incorrect MilkShake size")
            };
        }
    }
}
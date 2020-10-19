namespace Coffee
{
    public enum TeaType
    {
        Black,
        Green,
        White,
        Herbal
    }

    public class Tea : Beverage
    {
        public Tea(TeaType teaType) : base($"{teaType.ToString()} Tea")
        {
        }

        public override double GetCost()
        {
            return 30;
        }
    }
}
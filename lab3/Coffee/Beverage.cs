using System;

namespace Coffee
{
    public class Beverage : IBeverage
    {
        private readonly string _description;

        protected Beverage(string description)
        {
            _description = description;
        }

        public virtual double Cost => throw new NotImplementedException();

        public virtual double GetCost()
        {
            throw new NotImplementedException();
        }

        public string GetDescription()
        {
            return _description;
        }
    }
}
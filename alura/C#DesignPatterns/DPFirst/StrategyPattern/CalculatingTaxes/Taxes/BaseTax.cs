using System;

namespace DPFirst.StrategyPattern.CalculatingTaxes.Taxes
{
    abstract class BaseTax : ITax
    {
        public string Name { get => this.ToString() ; }

        public abstract double Calculate(Budget budget);

        public override string ToString()
        {
            return this.GetType().Name;
        }
    }
}
namespace DPFirst.StrategyPattern.CalculatingTaxes.Taxes{
    class Iccc : BaseTax
    {
        public override double Calculate(Budget budget)
        {
            var taxRate = (budget.Value < 1000) ? 0.05 
                        : (budget.Value <3000) ? 0.07 
                        : 0.08;

            return budget * taxRate;
        }

        public override string ToString()
        {
            return this.GetType().Name;
        }
    }
}
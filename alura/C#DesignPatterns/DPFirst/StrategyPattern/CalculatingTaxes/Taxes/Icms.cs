namespace DPFirst.StrategyPattern.CalculatingTaxes.Taxes{
    class Icms : BaseTax
    {
        public override double Calculate(Budget budget)
        {
            return budget * 0.1;
        }

    }
}
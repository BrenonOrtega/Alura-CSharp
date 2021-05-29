namespace DPFirst.StrategyPattern.CalculatingTaxes.Taxes{
    class Iss : BaseTax
    {
        public override double Calculate(Budget budget)
        {
            return budget * 0.05;
        }

    }
}
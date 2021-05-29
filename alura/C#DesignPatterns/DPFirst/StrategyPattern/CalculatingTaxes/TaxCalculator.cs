using DPFirst.StrategyPattern.CalculatingTaxes.Taxes;

namespace DPFirst.StrategyPattern.CalculatingTaxes
{
    class TaxCalculator
    {
        public double Calculate(Budget budget, ITax tax)
        {
            var totalTax = tax.Calculate(budget);
            budget.TaxValue += totalTax;
            return totalTax;
        }
    }
}
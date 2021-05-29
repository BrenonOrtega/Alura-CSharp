namespace DPFirst.StrategyPattern.CalculatingTaxes.Taxes
{
    interface ITax
    {
        string Name { get; }
        double Calculate(Budget budget); 
    }
}
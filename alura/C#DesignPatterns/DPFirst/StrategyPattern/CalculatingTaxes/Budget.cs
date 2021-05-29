namespace DPFirst.StrategyPattern.CalculatingTaxes
{
    class Budget
    {
        public string Id { get; }
        public double Value { get; }

        public double TaxValue { get; set;}
        
        public Budget(string id, double value) {
            Id = id;
            Value = value;  
        }

        public static double operator +(Budget budget, double value) {
            return budget.Value + value;
        }

        public static double operator *(Budget budget, double value) {
            return budget.Value * value;
        }

    }
}
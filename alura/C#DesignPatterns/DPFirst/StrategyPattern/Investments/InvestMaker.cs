using DPFirst.StrategyPattern.Investments.Interfaces;

namespace DPFirst.StrategyPattern.Investments
{
    class InvestMaker 
    {
        public double TaxPercentage { get=> 0.25; }
        public double Invest(BankAccount account, IInvestment investment)
        {
            var profit = account.Balance * investment.ProfitRate;
            var taxAmount = profit * TaxPercentage;
            var revenue = profit - taxAmount;
            account.Balance += revenue;

            System.Console.WriteLine($"Profit:{profit}");
            System.Console.WriteLine($"Tax amount:{taxAmount}");
            System.Console.WriteLine($"revenue:{revenue}");
            System.Console.WriteLine($"New balance:{account.Balance}");
            System.Console.WriteLine();
            return revenue;
        }


    }
}
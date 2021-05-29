using System;
using DPFirst.StrategyPattern.Investments.Interfaces;

namespace DPFirst.StrategyPattern.Investments.InvestmentTypes
{
    public class HighRiskInvestment : IRiskedInvestment
    {
        public double ProfitRate => GetProfitPercentage();

        public double GetProfitPercentage()
        {
            var odd = new Random().Next(101);
            return odd > 50  ? 0.006 
                :  odd < 20 ? 0.05 
                :  0.03 ;
        }

    }

}
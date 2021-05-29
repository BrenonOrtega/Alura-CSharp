using System;
using DPFirst.StrategyPattern.Investments.Interfaces;

namespace DPFirst.StrategyPattern.Investments.InvestmentTypes
{
    class ModerateInvestment : IRiskedInvestment
    {
        public double ProfitRate { get => GetProfitPercentage();  }

        public double GetProfitPercentage()
        {
            var odd = new Random().Next(101);
            return odd > 50 ? 0.025 : 0.07;

        }

    }

}
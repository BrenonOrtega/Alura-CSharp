using System;
using DPFirst.StrategyPattern.Investments.Interfaces;
namespace DPFirst.StrategyPattern.Investments.InvestmentTypes

{
    class ConservativeInvestment : IInvestment
    {
        public double ProfitRate => 0.08;
    }

}
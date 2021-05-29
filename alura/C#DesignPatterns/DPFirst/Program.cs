using System;
using DPFirst.ChainOfResponsibilityPattern;
using DPFirst.StrategyPattern;


namespace DPFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Strategy Pattern Examples
            if("strategy".Equals(args?.GetValue(0)??""))
                Strategy.Run(args);
            #endregion

            if("cor".Equals(args?.GetValue(0)??""))
                ChainOfResponsibility.Run(args);
        }
    }
}

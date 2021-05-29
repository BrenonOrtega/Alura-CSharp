using System.Collections.Generic;
using System.Linq;
using DPFirst.StrategyPattern.Investments;
using DPFirst.StrategyPattern.CalculatingTaxes;
using DPFirst.StrategyPattern.CalculatingTaxes.Taxes;
using DPFirst.StrategyPattern.Investments.InvestmentTypes;

namespace DPFirst.StrategyPattern
{
    public class Strategy
    {
        internal static void Run(string[] args)
        {
            if("base".Equals(args?.GetValue(1)??"")) 
                RunBase(args);
            else if("iccc".Equals(args?.GetValue(1)??"")) 
                RunIccc(args);
            else RunInvestments(args);
        }

        internal static void RunBase(string[] args)
        {
            System.Console.WriteLine("Running base");
            Icms icms = new ();
            Iss iss = new ();
            Cofins cofins = new ();

            Budget car = new Budget("car", 10000);
            Budget cellphone = new Budget("cellphone", 1000);
            Budget notebook = new Budget("notebook", 3000);

            ICollection<Budget> budgetSet = new HashSet<Budget> {car, cellphone, notebook};
            IList<ITax> taxList = new List<ITax> { icms, iss, cofins };

            TaxCalculator taxCalculator = new();

            foreach (var budget in budgetSet)
            {
                foreach (var tax in taxList)
                {
                    var taxvalue = taxCalculator.Calculate(budget, tax);
                    System.Console.WriteLine($"Adding {tax.Name} - Value: {taxvalue} to {budget.Id}");
                }
                System.Console.WriteLine(budget.Id  + " total tax: " + budget.TaxValue);
                System.Console.WriteLine();
            }
        }

        internal static void RunIccc(string[] args)
        {
            System.Console.WriteLine("Running ICCC");

            ITax iccc = new Iccc();
            var taxcalc = new TaxCalculator();
            var car = new Budget("car", 25000);
            var phone = new Budget("cell", 850);
            var pc = new Budget("pc", 2700);

            taxcalc.Calculate(car, iccc);
            System.Console.WriteLine(car.Id  + " total tax: " + car.TaxValue);

            taxcalc.Calculate(phone, iccc);
            System.Console.WriteLine(phone.Id  + " total tax: " + phone.TaxValue);

            taxcalc.Calculate(pc, iccc);
            System.Console.WriteLine(pc.Id  + " total tax: " + pc.TaxValue); 

        }

        static void RunInvestments(string[] args)
        {
            System.Console.WriteLine("Running Investment");

            InvestMaker invester = new();
            BankAccount acc1 = new(100);

            HighRiskInvestment highrisk = new();
            ModerateInvestment moderate = new();
            ConservativeInvestment conserv = new();

            System.Console.WriteLine("initial Balance: "+ acc1.Balance);
            foreach(var i in Enumerable.Range(1, 15))
            {
                if(i % 3 == 0) invester.Invest(acc1, highrisk);
                else if(i % 2 == 0) invester.Invest(acc1, moderate);
                else invester.Invest(acc1, conserv);

                acc1.Balance=100;
            }
        }
    }
}
using System.Collections.Generic;
using dpfirst.ChainResponsibilityPattern.Discounts;
using DPFirst.ChainResponsibilityPattern.Discounts;
using DPFirst.ChainResponsibilityPattern.WebBankCoR;
using DPFirst.ChainResponsibilityPattern.WebBankCoR.Handler;
using DPFirst.ChainResponsibilityPattern.WebBankCoR.Requests;

namespace DPFirst.ChainOfResponsibilityPattern
{
    public class ChainOfResponsibility
    {
        internal static void Run(string[] args)
        {

            RunWebBank(args);
        }

        static void RunBase(string[] args)
        {
            var item = new Item("car", 25000);
            var item2 = new Item("cell", 300);
            var item3 = new Item("notebook", 1200);
            var item4 = new Item("shoe", 120);
            var item5 = new Item("sneaker", 120);

            IDiscount fiveItemDiscount = new FiveItemDiscount();
            IDiscount threeHundredDiscount = new ThreeHundredDiscount();
            IDiscount pairDiscount = new PairDiscount(item, item2);
            
            var discCalculator = new DiscountCalculator();
            discCalculator.AddDiscount(threeHundredDiscount);
            discCalculator.AddDiscount(fiveItemDiscount);
            discCalculator.AddDiscount(pairDiscount);

            List<Item> items = new(){item, item2, item3, item4, item5};
        
            var discount = discCalculator.GetDiscount(items);
            System.Console.WriteLine($"discount: {discount}");
        }

        static void RunWebBank(string[] args)
        {
            var acc1 = new Account() {Name="bryan", Balance=2000};
            var acc2 = new Account() {Name="Lan", Balance=3000};
            var acc3 = new Account() {Name="Brenon", Balance=4000};
            var acc4 = new Account() {Name="Alan Bruno", Balance=5000};

            CsvHandler csvHandler = new(null);
            XMLHandler xmlHandler = new(csvHandler);
            PercentageHandler percentageHandler = new(xmlHandler);

            var response = percentageHandler.Execute((RequestTypes) 2 , acc3);

            // response = ho.HandleRequest(RequestTypes.Percentage, acc1);
            System.Console.WriteLine(response);
        }
    }
}
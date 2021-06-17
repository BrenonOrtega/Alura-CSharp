using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DictInterface;
using Microsoft.VisualBasic;

namespace DictInterface.Rules
{
    public static class RuleFactory 
    {
        public static Dictionary<string, Func<IRule>> regras = new Dictionary<string, Func<IRule>> ()
        {
            {nameof(SumRule).Replace("Rule", String.Empty), () => new SumRule()},
            {nameof(SubtractRule).Replace("Rule", String.Empty),  () => new SubtractRule()},
            {nameof(RepeatRule).Replace("Rule", String.Empty),  () => new RepeatRule()},
            {nameof(VariousRule).Replace("Rule", String.Empty),  () => new VariousRule()}

        };
        

        public static IRule Create(string requestedProduct) 
        {
            int a = 3 ;
            double b;
            decimal c;
            long d;
            Func<IRule> execRuleCreation = regras.GetValueOrDefault(requestedProduct);
            return execRuleCreation?.Invoke();
        } 
    }

    public class SumRule : IRule
    {
        public object ApplyRule()
        {
            return "Hey I Sum";
        }
    }

    class SubtractRule : IRule
    {   
        public object ApplyRule()
        {
            return "Hey I Subtract";
        }
    }

    class VariousRule : IRule
    {   
        public object ApplyRule()
        {
            return "Various";
        }
    }

    class RepeatRule : IRule
    {   
        public object ApplyRule()
        {   
            var str = new StringBuilder();
            str.Append("Hey I'm");
            foreach(var i in Enumerable.Range(0,10))
                str.Append("Repeating!");
            return str.ToString();
        }
    }

}




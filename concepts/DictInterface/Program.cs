using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using DictInterface.Rules;

namespace DictInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            object ruleobject = RuleFactory.Create("Sum");

            IRule rule = ruleobject as IRule;

            System.Console.WriteLine(rule.ApplyRule());

            rule = RuleFactory.Create("Subtract");

            System.Console.WriteLine(rule.ApplyRule());

            rule = RuleFactory.Create("Sum");

            System.Console.WriteLine(rule.ApplyRule());

            rule = RuleFactory.Create("Subtract");

            System.Console.WriteLine(rule.ApplyRule());
            rule = RuleFactory.Create("Various");

            System.Console.WriteLine(rule.ApplyRule());
            rule = RuleFactory.Create("Repeat");

            System.Console.WriteLine(rule.ApplyRule());

        }
    }

}

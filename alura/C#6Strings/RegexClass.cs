using System.Text.RegularExpressions;

namespace CSharp6Strings
{
    public class RegexClass
    {
        void aula()
        {
            var phrase = "Hello, my name is Brenon, you can call me at 945934443";
            var phrase2 = "Hello, my name is Brenon, you can call me at +551194593-4443";
            var pattern = @"[+]*[0-9]{0,2}[0-9]{0,2}[0-9]{4,5}-?[0-9]{4}";
            
            var test = Regex.Match(phrase, pattern).Value;
            var match = Regex.Match(phrase2, pattern).Value;
            System.Console.WriteLine(test);
            System.Console.WriteLine(match);
        }
    }
}
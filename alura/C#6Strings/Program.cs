using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Configuration;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
namespace CSharp6Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //URLStringArgsExtractor.Run();

            String url = "?moedaOrigem=real&moedaDestino=dolar&valor=1500";
            URLStringArgsExtractor extractor = new (url);

            RegexClass.Aula();
        }

    }
}
 
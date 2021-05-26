using System;
using System.ComponentModel.DataAnnotations;

namespace CSharp6Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //URLStringArgsExtractor.Run();
            String url = "?moedaOrigem=real&moedaDestino=dolar&valor=1500";
            URLStringArgsExtractor extractor = new (url);

            

        }
    }
}

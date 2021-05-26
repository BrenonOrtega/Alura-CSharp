using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CSharp6Strings
{
    public class URLStringArgsExtractor
    {
        public string Url { get; set; }
        
        public string Param { get; set; }
        public string Arg  { get; set; }
        public static void Run() {
            //Cada caractér possuí um indíce (0 based).
            //p a g i n a ? a r g u  m  e  n  t  o  s
            //0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16

            string url = "pagina?moedaOrigem=dolar";

            var argumentos = url.Substring(url.IndexOf("?") + 1);
            System.Console.WriteLine(argumentos);
        }

        public URLStringArgsExtractor(string url)
        {
            Url = String.IsNullOrEmpty(url).Equals(false)
                ? url : throw new ArgumentNullException(nameof(url)) ;
            
            var index = url.LastIndexOf("&");
            var finalIndex = url.LastIndexOf("=");
            var Param_Value = url.Substring(index + 1);
            Param = url.Substring(url.IndexOf(Param_Value), finalIndex - index);
            Arg = GetValor(Param_Value);

            System.Console.WriteLine(Param);
            System.Console.WriteLine(Arg);
        }

        private string GetValor(string urlArgs) { 
            var arg = urlArgs.Substring(urlArgs.IndexOf("=") + 1);
            return arg;
        }

       
    }
}
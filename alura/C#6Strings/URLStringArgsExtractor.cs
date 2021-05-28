using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CSharp6Strings
{
    public class URLStringArgsExtractor
    {
        public string Url { get; set; }
        
        private const string _separator = "&";
        private readonly string _argumentos;
        public HashSet<string> Args { get; private set; } = new HashSet<string>();
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
            
            int indexQuestionMark = url.IndexOf("?");

            _argumentos = url.Substring(indexQuestionMark + 1);
            Args.Add(GetValue("moedaOrigem"));
            Args.Add(GetValue("MOEDADESTINO"));
            Args.Add(GetValue("Valor"));
 
            System.Console.WriteLine(_argumentos);
            foreach (var item in Args)
                System.Console.WriteLine(item);
        }

        private string GetValue(string paramName) { 
            string parameter = paramName + "=";
            int parameterIndex = _argumentos.ToUpper().IndexOf(parameter.ToUpper());

            string value = _argumentos.Substring(parameterIndex + parameter.Length);
            int indexSeparator = value.IndexOf(_separator);

            if(indexSeparator > 0) {
                value = value.Remove(indexSeparator);
            }

            return value;
        }

       
    }
}
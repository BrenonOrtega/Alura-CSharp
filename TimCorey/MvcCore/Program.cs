using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MvcCore
{
/*    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
 */

using System;
using System.Collections.Generic;
using System.Linq;
/* 
class Program {
 
  static void Main(string[] args){
  
    // IMPLEMENTE A SOLUÇÃO
    string[] stringTartarugas = Console.ReadLine().Split();
    List<int> tartarugas = new List<int>();

        foreach(string tartaruga in stringTartarugas)
        {
            tartarugas.Add(int.Parse(tartaruga));
        }

    if (tartarugas.Max() > 1 )
        System.Console.WriteLine(1);
    else if(tartarugas.Max() > 10 )
        System.Console.WriteLine(2);
    else if(tartarugas.Max() > 20 )
        System.Console.WriteLine(3);
    
    }
  }

} */

    class Program 
    {
        // IMPLEMENTE A SOLUÇÃO
        static void Main(string[] args)
        {
            List<string[]> stringArrayTartarugas = new List<string[]>();
            List<string> stringTartarugas = new List<string>();
            List<int> tartarugas = new List<int>();
            int i = 0; 
            string teste = "10";

            while(teste == "10")
            {
                teste = "";
                teste = Console.ReadLine();
                stringArrayTartarugas.Add(Console.ReadLine().Split());
                i++;
            }

            for(var k=0; k<i; k++)
            {
                foreach (var arrayTartaruga in stringArrayTartarugas)
                {
                    for(int j=0; j < arrayTartaruga.Length; i++)
                        stringTartarugas.Add(arrayTartaruga[j]);
                }

                foreach (var tartaruga in stringTartarugas)
                {
                    tartarugas.Add(int.Parse(tartaruga));
                
                    if (tartarugas.Max() < 10 )
                        System.Console.WriteLine(1);
                    else if(tartarugas.Max() >= 10 && tartarugas.Max() <20 )
                        System.Console.WriteLine(2);
                    else if(tartarugas.Max() >= 20 )
                        System.Console.WriteLine(3);
                }
            }
        }
    }
}
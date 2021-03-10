using System;

namespace proj1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            double var1 = 15.5f;
            int var2 = 1;


            Double saida1 = var1 + var2;
            string saida2 = Convert.ToString(12);



            Console.WriteLine("{0} - {1}", saida1, saida2);
            Console.WriteLine("Agora são {0}", DateTime.Now);
        }
    }
}

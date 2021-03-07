using System;

namespace proj3
{
    class Program
    {
        static void Main(string[] args)
        {
            for(int i =0; i<=15; i++){
                for (int j = 0; j<=i; j ++) Console.Write("*");
                Console.WriteLine();
            }

            int numero = 1;
            Multiplos3(numero);

            void Multiplos3(int numero) {
                for (int i = 0; i<=numero; i +=3)Console.WriteLine(i);
            }

            int Fatorial(int fatorial){
                int teste = 1;
                for (int i = fatorial; i > 0; i--) teste *= i;
                return teste;
            }

            Console.WriteLine(Fatorial(4));
            

        }  
    }
}

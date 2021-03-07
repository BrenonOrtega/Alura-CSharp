using System;

namespace proj2 
{
    class Program 
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Oi mamãe");

            var a = new Foo("bar", 4);
            Console.WriteLine(a.BarBaz + a.Bar + a.Baz + a.Inteiro);

            double salario = 4665.0;
            double imposto = GetIR(salario);

            double GetIR(double salario){ 
                double imposto;

                if (1787.87 > salario) {
                    imposto = 0;       
                } else if((1900 <= salario) && (salario <=2800.00)) {
                    imposto = 142.80;
                } else if((2800.01 < salario) && (salario <=3751.00)){ 
                    imposto = 354.80;
                } else if((3751.01 <= salario) && (salario <= 4664)) {
                    imposto = 636.13;
                } else {
                    imposto = 869.36;
                }
                return imposto;
            }
            Console.WriteLine("João recebe {0:C2} e deverá pagar de imposto {1:c2}", salario, imposto);
        } 
    }
}




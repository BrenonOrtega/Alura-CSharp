using System;

namespace teste
{
    class Program
    {
        static void Main(string[] args)
        {
            int a=1;
            int b =3;
            int c= 5;

            while (b!=a && c<20)
            {
                if (a> c) c-=2;
                else {
                    c+=2;
                    if(a+b<c)
                    {
                        a=b-a;
                        b+=2;
                    }
                }
                System.Console.WriteLine("a"+a);
                System.Console.WriteLine("b"+b);
                System.Console.WriteLine("c"+c);
            }
        }
    }
}

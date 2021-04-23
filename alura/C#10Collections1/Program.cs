using System;

namespace C_10Collections1
{
    class Program
    {
        static void Main(string[] args)
        {
            string primeiraAula = "Olá, está é a primeira aula.";
            string modelandoAula = "Modelando Arrays na aula!";
            string ListsAula = "Criando Lists na aula!";

            string[] aulas = new string[]{
                primeiraAula, modelandoAula, ListsAula
            };

            foreach (string aula in aulas)
            {
                System.Console.WriteLine(aula);    
            }
        }
    }
}

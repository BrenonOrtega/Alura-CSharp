using System;
using System.Collections.Generic;
using System.Linq;

namespace Aulas.Lists
{
    public static class AulasList
    {
        public static void run(){
            string aulaArrays = "Primeira aula foi sobre Arrays";
            string aulaArrays2 = "Segunda aula foi sobre Arrays";
            string aulaLists = "Primeira aula sobre Lists";
            string aulaLists2 = "Segunda aula sobre Lists";
            string aulaDicts = "Primeira aula sobre dicts";
            string aulaDicts2 = "Segunda aula sobre dicts";
            
            
            List<string> aulas = new List<string> 
            {
                aulaArrays,aulaArrays2,
                aulaLists, aulaLists2,
                aulaDicts, aulaDicts2
            };

            aulas.ForEach(aula =>
            { 
                System.Console.WriteLine(aula);
                aula += "teste";
            });

            System.Console.WriteLine($"A primeira aula é: { aulas.First() } com Linq");
            System.Console.WriteLine($"A segunda aula é { aulas[0] } com indexação.\n");

            System.Console.WriteLine($"A ultima aula é: { aulas.Last() } com Linq");
            System.Console.WriteLine($"A ultima aula é { aulas[aulas.Count - 1] } com indexação e Count\n");
           

            System.Console.WriteLine("Operações com Listas");
            System.Console.WriteLine($"A primeira Aula que fala de dicts é { aulas.FirstOrDefault( aula => aula.Contains("teste")) } ");
            
            aulas.GetRange(1,3).ForEach(aula => {
                System.Console.WriteLine(aula);
            });
            
        }
    }
}
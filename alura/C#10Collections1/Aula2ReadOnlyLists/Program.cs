using System;
using System.Collections.Generic;
using LibCurso.Data;

namespace Aula2ReadOnlyLists
{
    class Program
    {
        static void Main(string[] args)
        {
            Curso cursoCollections = new("C# Collections", "Marcelo Oliveira");
            cursoCollections.AddAula( new("aula introdutoria collections", 25));
            cursoCollections.AddAula( new("Aula Arrays", 15));
            cursoCollections.AddAula( new("null", 10));
            cursoCollections.AddAula( new("Aulas Lists apenas leitura", 13));

            System.Console.WriteLine(cursoCollections);
            PrintAll(cursoCollections.Aulas);
        }
        static void PrintAll(IList<Aula> aulas) 
        {
            foreach(var aula in aulas) Console.WriteLine(aula);
        }
    }
}

using System;
using System.Collections.Generic;
using LibCurso.Data;

namespace Aula2ReadOnlyLists
{
    class Program
    {
        static void Main(string[] args)
        {
        #region Criando um curso e adicionando uma aula
            Curso cursoCollections = new("C# Collections", "Marcelo Oliveira");
            cursoCollections.AddAula( new("criando uma aula", 30));

            System.Console.WriteLine(cursoCollections);
            PrintAll(cursoCollections.Aulas);
        #endregion

        #region Adicionando mais aulas    
            cursoCollections.AddAula( new("Modelando com coleções", 13));
            cursoCollections.AddAula( new("aula introdutoria collections", 25));
            PrintAll(cursoCollections.Aulas);

            //Isso não funciona.
            //cursoCollections.Aulas.Sort();
        #endregion

        #region copiando a ReadOnlyCollection para uma nova lista
            List<Aula> copiaAulas = new List<Aula>(cursoCollections.Aulas);
            System.Console.WriteLine(nameof(copiaAulas)+":");
            PrintAll(copiaAulas);
        #endregion

        #region ordenando por duracao
            /* copiaAulas.Sort((aulaInicial, aulaFinal) => {
                System.Console.WriteLine($"{nameof(aulaInicial)}: {aulaInicial}, {nameof(aulaFinal)}: {aulaFinal}");
                return aulaInicial.Duracao.CompareTo(aulaFinal.Duracao);
            }); */
        #endregion
        
        #region aulas ordenadas por nome
            copiaAulas.Sort();
            System.Console.WriteLine(nameof(copiaAulas) + " sorted:");
            PrintAll(copiaAulas);
        #endregion

        #region Tempo Total da Aula
            System.Console.WriteLine($"O tempo total das aulas é {cursoCollections.DuracaoTotal} mins");
            System.Console.WriteLine(cursoCollections);

        #endregion
        }
        static void PrintAll(IList<Aula> aulas) 
        {
            foreach(var aula in aulas) Console.WriteLine(aula);
        }
    }
}

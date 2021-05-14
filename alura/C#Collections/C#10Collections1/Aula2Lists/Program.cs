using System;
using System.Collections.Generic;
using System.Linq;
using LibCurso.Data;

namespace Aula2Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            var aulaIntro = new Aula("Trabalhando com arrays", 20);
            var aulaLists = new Aula("Trabalhando com lists", 17);
            var aulaSets = new Aula("Trabalhando com sets e hash sets", 15);
            var aulaDicts = new Aula("Trabalhando com dicts", 25);
            List<Aula> aulas = new() {
                aulaIntro, aulaLists, aulaSets 
            };

            aulas.Add( new("Docker e Docker Compose",20) );

            foreach(var aula in aulas){
                System.Console.WriteLine(aula);
                System.Console.WriteLine(aulas[0]==aula);
                System.Console.WriteLine(aulas[1]==aula);
                System.Console.WriteLine(aulas[2]==aula);
                
            }

            #region Sort Decrescente
            aulas.Sort((aula, outraAula) => outraAula.Duracao.CompareTo(aula.Duracao));
            foreach(var aula in aulas){
                System.Console.WriteLine(aula);

            }
            #endregion

            #region Sort Crescente
            aulas.Sort((aula, outraAula) =>  aula.Duracao.CompareTo(outraAula.Duracao));
            foreach(var aula in aulas){
                System.Console.WriteLine(aula);

            }
            #endregion

            #region Immutable Collection 
            /*System.Console.WriteLine(aulas.TrueForAll(aula => aula.Duracao >= 20));
            var immutableAulas = aulas.AsReadOnly();

            foreach (var aula in immutableAulas) {
                System.Console.WriteLine(aula);
            }

            foreach (var aula in immutableAulas) {
                System.Console.WriteLine(aula);
            } */
            #endregion 
        }
    }
}

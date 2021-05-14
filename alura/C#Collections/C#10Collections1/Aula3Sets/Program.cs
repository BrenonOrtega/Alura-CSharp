using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using LibCurso.Data;

namespace Aula3Sets
{
    class Program
    {
        static void Main(string[] args)
        {
            //Sets - Conjuntos
            //Se comportam da mesma maneira que os sets do python
            //1 - Não permitem duplicidade de items 
            //2 - Os elementos não possuem ordenação específica.

        #region Declarando Sets de Alunos
            ISet<string> alunos = new HashSet<string>();

            alunos.Add("Lanzinho Bruninho");
            alunos.Add("Isabella Costa");
            alunos.Add("Paulo Silveira");

            System.Console.WriteLine(string.Join(",", alunos));
        #endregion

        #region Testando a Ordenação dos Hashsets
            alunos.Remove("Lanzinho Bruninho");
            alunos.Add("Teste Lanzinho");
            System.Console.WriteLine(string.Join(",", alunos));

        #endregion

        #region Instanciando 3 alunos e os registrando no curso
            Aluno aluno1 = new("Brenon", "Ortega", 12);
            Aluno aluno2 = new("Lanzinho", "Bruno", 15);
            Aluno aluno3 = new("Natalia", "Silva", 13);

            //Matriculando os alunos no curso.
            Curso csharpCollections = new("C# Collections pt1", "Marcelo Oliveira");
            csharpCollections.Matricular(aluno1);
            csharpCollections.Matricular(aluno2);
            csharpCollections.Matricular(aluno3);

            foreach (var aluno in csharpCollections.Alunos)
            {
                System.Console.WriteLine(aluno);
            }
        #endregion

        #region Método isMatriculado verificando se um aluno está ou não matriculado.
            //Criamos o método IsMatriculado para verificar se a instancia
            //de aluno
            System.Console.WriteLine(csharpCollections.IsMatriculado(aluno1));
            System.Console.WriteLine(csharpCollections.IsMatriculado(new Aluno("Tixa", "Souza", 12)));
        #endregion

        #region Sobrescrevendo Equals() e GetHashCode() de aluno e curso() 
            var a = new Aluno("Tixa", "Souza", 12);
            var b = new Aluno("Tixa", "Souza", 12);
            System.Console.WriteLine($"Hash A é igual Hash B? { a.GetHashCode() == b.GetHashCode() }");
            System.Console.WriteLine($"Aluno A é igual aluno B com Equals? {a.Equals(b)}");

            //Testando criar um curso novo
            var curso = new Curso(csharpCollections.Nome, csharpCollections.Instrutor);
            foreach (var aula in csharpCollections.Aulas) { curso.AddAula(aula); }

            System.Console.WriteLine($"a cópia do curso é igual ao curso? {curso.Equals(csharpCollections)}");
            System.Console.WriteLine($"a cópia do curso é igual ao curso? {curso.GetHashCode() == (csharpCollections.GetHashCode())}");
        #endregion
        
        #region Acessando os valores do HashSet
            ///<Summary>Necessário utilizar LINQ para buscar dados em hashsets
            ///visto que os mesmos não possuem ordenação. 
            ///</Summary>
            var alunoBuscadoLinq = csharpCollections.Alunos.FirstOrDefault(aluno => aluno.Nome.Equals("Brenon"));
            System.Console.WriteLine(alunoBuscadoLinq);
            alunoBuscadoLinq = csharpCollections.Alunos.Last();
            System.Console.WriteLine(alunoBuscadoLinq);

        #endregion
        }
    }
}

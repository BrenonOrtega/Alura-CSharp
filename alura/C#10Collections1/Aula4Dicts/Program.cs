using System;
using System.Runtime.Remoting;
using LibCurso.Data;

namespace Aula4Dicts
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno aluno1 = new("Brenon", "Ortega", 12);
            Aluno aluno2 = new("Lanzinho", "Bruno", 15);
            Aluno aluno3 = new("Natalia", "Silva", 13);

            Curso collections = new(nome:"C# Collections", instrutor: "Marcelo Oliveira");

            collections.Matricular(aluno1);
            collections.Matricular(aluno2);
            collections.Matricular(aluno3);

            System.Console.WriteLine("Alunos Matriculados");
            foreach (var aluno in collections.Alunos)
            {    
                System.Console.WriteLine(aluno);
                System.Console.WriteLine();
            }

            Aluno alunoTeste = new("Brenon", "Orte", 12);
            System.Console.WriteLine("Aluno Matriculado?" + collections.IsMatriculado(alunoTeste));
            System.Console.WriteLine(collections.BuscaMatricula(alunoTeste.Matricula));
            System.Console.WriteLine();

            Aluno outroBrenon = new("Brenon", "Costa", 12);
            collections.AlteraAluno(outroBrenon);
            System.Console.WriteLine(collections.BuscaMatricula(12));
            System.Console.WriteLine();
            
            System.Console.WriteLine("verificando o hashSet");
            foreach (var aluno in collections.Alunos)
            {
                System.Console.WriteLine(aluno);
                System.Console.WriteLine();
            }

        }
    }
}

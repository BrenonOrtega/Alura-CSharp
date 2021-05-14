using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace LibCurso.Data
{
    public class Aluno
    {        
        private string nome;
        private string sobrenome;
        private int matricula;

        public Aluno(string nome, string sobrenome, int matricula)
        {
            this.nome = nome ?? throw GenerateArgumentException(nameof(Nome));
            this.sobrenome = sobrenome ?? throw GenerateArgumentException(nameof(Sobrenome));
            this.matricula = matricula > 0 ?  matricula : throw GenerateArgumentException(nameof(Matricula));
        }

        public string Nome
        {
            get => nome;
            set => nome = value;
        }   
        
        public string Sobrenome
        {
            get => sobrenome;
            set => sobrenome = value;
        }
        
        public int Matricula
        {
            get => matricula ;
            set => matricula  = value;
        }

         private ArgumentException GenerateArgumentException(string parametro) 
        {
            return new ArgumentException($"Parametro {parametro} inválido.", parametro);
        }

        public override string ToString() => $"Aluno:{Nome} {Sobrenome} - Matricula: {Matricula}";
        
        public override int GetHashCode() => Nome.GetHashCode() + Sobrenome.GetHashCode();

        public override bool Equals(object obj)
        {
            return obj is Aluno aluno &&
                   nome == aluno.nome &&
                   sobrenome == aluno.sobrenome &&
                   matricula == aluno.matricula &&
                   Nome == aluno.Nome &&
                   Sobrenome == aluno.Sobrenome &&
                   Matricula == aluno.Matricula;
        }
    }
}
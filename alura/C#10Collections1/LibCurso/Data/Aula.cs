using System;
namespace LibCurso.Data
{
    public class Aula : IComparable
    {
        public string Titulo { get; private set; }
        public int Duracao { get; private set; }

        public Aula(string titulo, int duracao)
        {
            this.Titulo = titulo ?? throw new ArgumentException("titulo invalido", nameof(Titulo));
            this.Duracao = duracao > 0 ? duracao : throw new ArgumentException("duracao invalida", nameof(Duracao));
        }
        public Aula()
        { 
        }

        public override string ToString()
        {
            return $"Aula: {this.Titulo} Duração: {this.Duracao}";
        }

        public int CompareTo(object obj)
        {
            Aula that = obj as Aula;
            return this.Titulo.ToLower().CompareTo(that.Titulo.ToLower());
        }
    }
}
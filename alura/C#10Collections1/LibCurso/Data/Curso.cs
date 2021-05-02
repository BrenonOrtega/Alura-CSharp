using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace LibCurso.Data
{
    public class Curso
    {
        private string _nome;
        private string _instrutor;
        private IList<Aula> _aulas;

        public Curso(string nome, string instrutor)
        {
            _nome = nome;
            _instrutor = instrutor;
            _aulas = new List<Aula>();
        }

        public void AddAula(Aula aula)
        {
            _aulas.Add(aula);
        }

        public string Nome
        {
        get { return _nome; }
        set { _nome = value; }
        }

        public string Instrutor
        {
            get { return _instrutor; }
            set { _instrutor = value; }
        }
        public IList<Aula> Aulas 
        { 
            get => new ReadOnlyCollection<Aula>(_aulas);
        }
    }
}
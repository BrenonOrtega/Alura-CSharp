using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;

namespace LibCurso.Data
{
    public class Curso
    {
        private string _nome;
        private string _instrutor;
        private IList<Aula> _aulas;
        private ISet<Aluno> _alunos;
        private IDictionary<int,Aluno> _dictAlunos = new Dictionary<int, Aluno>();

        public Curso(string nome, string instrutor) {
            _nome = nome;
            _instrutor = instrutor;
            _aulas = new List<Aula>();
            _alunos= new HashSet<Aluno>();
        }

    #region Properties
        public string Nome 
        {
            get => _nome; 
            set => _nome = value; 
        }

        public string Instrutor 
        {
            get => _instrutor;
            set => _instrutor = value;
        }
        public IList<Aula> Aulas { get => new ReadOnlyCollection<Aula>(_aulas); }

        public IList<Aluno> Alunos { get => new ReadOnlyCollection<Aluno>(_alunos.ToList()); } 

    #endregion
    
    #region Métodos
        //Usando Linq
        public int DuracaoTotal { get => _aulas.Sum(aula => aula.Duracao); }
        public void AddAula(Aula aula) => _aulas.Add(aula);
        public void Matricular(Aluno aluno) {
            _alunos.Add(aluno);
            _dictAlunos.Add(aluno.Matricula, aluno);
        }
        public bool IsMatriculado(Aluno aluno) => _dictAlunos.ContainsKey(aluno.Matricula);

        public Aluno BuscaMatricula(int numeroMatricula) {
            #region funciona porém pode ser melhor com dicts
            /* foreach (var aluno in Alunos)
            {
                if (aluno.Matricula == numeroMatricula)
                    return aluno;
            }
            throw new KeyNotFoundException("Matricula não encontrada:" + numeroMatricula); */
            #endregion

            _dictAlunos.TryGetValue(numeroMatricula, out Aluno aluno);
            return aluno;
        }
        
    #endregion
        
    #region Overrides
        public override string ToString() => $"Curso: {Nome} - Instrutor:{Instrutor} - Aulas {string.Join(",", _aulas)}";

        public override int GetHashCode() => Nome.GetHashCode() + Instrutor.GetHashCode();

        public override bool Equals(object obj)  {
           return obj is Curso curso && curso.Nome.Equals(this.Nome) && curso.Instrutor.Equals(this.Instrutor); 
        }
    #endregion
    
    }
}
namespace ByteBank.data.Funcionarios
{
    public class Diretor : Funcionario, IAutenticavel
    {
        public string Senha { get; set; }
        public int Renda { get; set; }

        #region construtor
        public Diretor(string cpf, string senha, int renda= 0) : base (cpf, 5000) 
        { 
            Renda = 75000;
            Senha = senha;
        }
        #endregion

        #region Métodos
        public override double GetBonificacao() => Salario;
        public override void AumentarSalário() => Salario += 1.1;
            
        #endregion
       
    }
}
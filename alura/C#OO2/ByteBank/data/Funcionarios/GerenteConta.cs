namespace ByteBank.data.Funcionarios
{

    public class GerenteConta : Funcionario, IAutenticavel
    {
        public string Senha { get ;  set; }
        public GerenteConta(string cpf, string senha) : base(cpf, 4000) {
            Senha = senha;
        }

        public override double GetBonificacao() => Salario * 0.2;
        public override void AumentarSalário() => Salario *= 1.2;

    }
}
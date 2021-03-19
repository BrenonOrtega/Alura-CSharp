namespace ByteBank.data.Funcionarios
{
    public class Diretor : FuncionarioAutenticavel
    {
        public Diretor(string cpf, string senha) : base (cpf, 5000, senha) {    }
        public override double GetBonificacao() => Salario;
        public override void AumentarSalario() => Salario += 1.1;

    }
}
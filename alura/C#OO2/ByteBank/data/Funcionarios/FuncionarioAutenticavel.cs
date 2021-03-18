
namespace ByteBank.data.Funcionarios
{
    public abstract class FuncionarioAutenticavel : Funcionario, IAutenticavel
    {
        public string Senha { get; private set; }

        public FuncionarioAutenticavel(string cpf, double salario, string senha, string nome="") : base(cpf, salario, nome)
        {
            Senha = senha;
        }
        public bool Autenticar(string senha)
        {
            return Senha == senha;
        }
    }
}
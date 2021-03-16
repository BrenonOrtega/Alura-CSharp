
namespace ByteBank.Funcionarios{
    public abstract class Funcionario
    {
        public string Nome { get; set; }
        public string CPF { get; private set; }
        public double Salario { get; protected set; }

        public Funcionario(string cpf, double salario, string nome="") {
            Nome = nome;
            CPF = cpf;
            Salario = salario;
        }

        public abstract double GetBonificacao();

        public abstract void AumentarSalário();
      
    }


}
using System.IO;

namespace ByteBank.data.Funcionarios
{

    public class GerenteConta : FuncionarioAutenticavel
    {
        private static double _salario = 4000;
        public GerenteConta(string cpf, string senha) : base(cpf, _salario, senha) {    }

        public override double GetBonificacao() => Salario * 0.2;
        public override void AumentarSalario() => Salario *= 1.2;
    }
}
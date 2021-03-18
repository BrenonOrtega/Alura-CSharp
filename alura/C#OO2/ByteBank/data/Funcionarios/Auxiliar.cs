namespace ByteBank.data.Funcionarios
{
    public class Auxiliar : Funcionario
    {
        private static double _salario = 2000;
        public Auxiliar(string cpf) : base (cpf, _salario){}
        public override void AumentarSalario() => Salario *= 1.1;
        public override double GetBonificacao() => Salario * 0.1;
    }
}
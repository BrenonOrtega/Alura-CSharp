namespace ByteBank.data.Funcionarios{
    public class Desenvolvedor : Funcionario
    {
        private static double _salario = 5000;
        public Desenvolvedor(string cpf) : base (cpf, _salario) { }
        public override double GetBonificacao() => Salario * 0.15;
        public override void AumentarSalario() => Salario += 1.1;
    }
}
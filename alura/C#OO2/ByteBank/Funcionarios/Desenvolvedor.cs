namespace ByteBank.Funcionarios{
    public class Desenvolvedor : Funcionario
    {
        public Desenvolvedor(string cpf) : base (cpf, 5000) { }
        public override double GetBonificacao() => Salario * 0.15;
        public override void AumentarSalário() => Salario += 1.1;
    }
}
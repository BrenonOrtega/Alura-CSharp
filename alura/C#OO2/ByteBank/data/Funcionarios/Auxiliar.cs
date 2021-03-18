namespace ByteBank.data.Funcionarios
{
    public class Auxiliar : Funcionario
    {
        public Auxiliar(string cpf) : base (cpf, 2000){}
        public override void AumentarSalário() => Salario *= 1.1;
        public override double GetBonificacao() => Salario * 0.1;
    }
}
namespace ByteBank.Funcionarios
{
    public class Diretor : Funcionario
    {
        public int Renda { get; set; }
        public Diretor(string cpf, int renda= 0) : base (cpf, 5000) { Renda = 75000;}

        public override double GetBonificacao() => Salario;
        public override void AumentarSalário() => Salario += 1.1;
    }
}
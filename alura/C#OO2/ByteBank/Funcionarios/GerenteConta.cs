namespace ByteBank.Funcionarios
{

    public class GerenteConta : Funcionario
    {
        public GerenteConta(string cpf) : base(cpf, 4000){ }

        public override double GetBonificacao()
        {
            return Salario * 0.2;
        }

        public override void AumentarSalário()
        {
            Salario *= 1.2;
        }
    }
}
namespace ByteBank.Funcionarios
{
    public class Diretor : Funcionario
    {
        public new double GetBonificacao(){
            return Salario;
        }
    }
}
namespace _01_ByteBank
{
  public class ContaCorrente
    {
        public ContaCorrente(string titular, 
                            int numeroAgencia,
                            int numeroConta,
                            double saldoInicial = 0)
        {
            this.titular = titular;
            this.numeroAgencia = numeroAgencia;
            this.numeroConta = numeroConta;
            this.saldo = saldoInicial;
        }

        public string titular { get; set; }
        public int numeroAgencia { get; set; }
        public int numeroConta { get; set; }
        public double saldo { get; set; }
    }
}

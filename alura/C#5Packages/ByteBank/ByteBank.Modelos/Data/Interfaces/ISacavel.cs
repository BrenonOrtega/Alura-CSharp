namespace ByteBank.Modelos.Data.Interfaces
{
    public interface ISacavel
    {
        public void Depositar(double valor);
        public void Transferir (double valor, ISacavel isacavel);
        public void Sacar (double valor);
    }
}
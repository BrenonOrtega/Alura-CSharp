using FileReader;
using _01_ByteBank.Functions;
using _01_ByteBank.data.Exceptions;

namespace _01_ByteBank 
{
    class Program 
    {
        static void Main(string[] args) 
        {
            Cliente Brenon = new Cliente("Brenon", cpf: 45459992800, profissao: "Programador Jr", telefone: 1128348021);
            Cliente Lan = new Cliente(nome:"Lan", cpf: 12345678900, "Chefe Pai", 1545459832);  
            F.LogStars();

            #region  Atribuição de Saldo Negativa
            F.Log("Atribuição de Saldo Negativa");
            try {
                ContaCorrente _contaBrenon = new ContaCorrente(Brenon, 12345, 000001, -35);
            } catch (SaldoInvalidoException e ){
                F.Log(e);
            } catch (OperacaoFinanceiraException e) {
                F.Log(e);            
            }

            #endregion

            #region saque de valor maior que o saldo da conta
            F.Log("Saque de valor maior que saldo da conta");
            ContaCorrente contaBrenon = new ContaCorrente(Brenon, 12345, 000001);
            try {
                contaBrenon.Sacar(1);
            } catch (OperacaoFinanceiraException e) {
                F.Log(e);
            }
            F.LogStars();
            #endregion

            
            #region testando IDisposable

            using (Reader fileReader = new Reader("ContasDoBanco.txt"))
            {
                    fileReader.OpenFile();
                    fileReader.ReadLine();
            }

            #endregion

            #region saque de valor negativo
            F.Log("Saque de valor negativo");
            try {
                contaBrenon.Sacar(-1);
            } catch (OperacaoFinanceiraException e) {
                F.Log(e);
            }
            F.LogStars();
            #endregion 
        }
    }
}
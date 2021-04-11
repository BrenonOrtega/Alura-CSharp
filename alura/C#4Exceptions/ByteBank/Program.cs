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

            F.Log("Atribuição de Saldo Negativa");
            try {
                ContaCorrente _contaBrenon = new ContaCorrente(Brenon, 12345, 000001, -35);
            } catch (SaldoInvalidoException e ){
                F.Log(e);
            } catch (OperacaoFinanceiraException e) {
                F.Log(e);            
            }

            F.Log("Saque de valor maior que saldo da conta");
            ContaCorrente contaBrenon = new ContaCorrente(Brenon, 12345, 000001);
            try {
                contaBrenon.Sacar(1);
            } catch (OperacaoFinanceiraException e) {
                F.Log(e);
            }
            F.LogStars();

            F.Log("Saque de valor negativo");
            try {
                contaBrenon.Sacar(-1);
            } catch (OperacaoFinanceiraException e) {
                F.Log(e);
            }
            F.LogStars();

        }
    }
}
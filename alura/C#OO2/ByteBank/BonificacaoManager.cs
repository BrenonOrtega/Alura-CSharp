using System.Collections.Generic;
using ByteBank.Funcionarios;

namespace ByteBank
{
    public class BonificacaoManager
    {
        public double totalBonificacao {get; private set;}

        public void Registrar(params Funcionario[] funcionarios){
            foreach (var funcionario in funcionarios) {
                totalBonificacao += funcionario.GetBonificacao();
            }    
        }

        public double GetTotalBonificacoes() => totalBonificacao;
    }
}
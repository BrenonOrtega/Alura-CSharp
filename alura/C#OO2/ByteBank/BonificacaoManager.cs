using System.Collections.Generic;
using ByteBank.Funcionarios;

namespace ByteBank
{
    public class BonificacaoManager
    {
        private double _totalBonificacao;

        public void Registrar(IEnumerable<> funcionarios){
            foreach (var funcionario in funcionarios) {
                _totalBonificacao += funcionario.GetBonificacao();
            }    
        }

        public double GetTotalBonificacoes() => _totalBonificacao;
    }
}
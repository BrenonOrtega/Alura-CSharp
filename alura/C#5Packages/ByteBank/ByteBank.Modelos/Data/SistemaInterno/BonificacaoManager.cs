using ByteBank.Modelos.Data.Funcionarios;

namespace ByteBank.Modelos.Data.SistemaInterno {
    public class BonificacaoManager {
        public double totalBonificacao {get; private set;}

        public void Registrar(params Funcionario[] funcionarios) {
            foreach (var funcionario in funcionarios) {
                totalBonificacao += funcionario.GetBonificacao();
            }    
        }
        public double GetTotalBonificacoes() => totalBonificacao;
    }
}
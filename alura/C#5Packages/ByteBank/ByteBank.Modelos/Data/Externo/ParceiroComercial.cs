using ByteBank.Modelos.Data.Interfaces;

namespace ByteBank.Modelos.Data.Externo
{
    public class ParceiroComercial : IAutenticavel {
        public string Nome{get; set;}
        public string Senha { get; private set; }
        public ParceiroComercial (string nome, string senha) {
            Nome = nome;
            Senha = senha;
        }

        public bool Autenticar(string senha) {
            return Senha == senha;
        }
    }   
}
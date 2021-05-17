using System;
using ByteBank.Modelos.Data.Interfaces;

namespace ByteBank.Modelos.Data.SistemaInterno
{
    public class SistemaInterno
    {
        public void Logar(IAutenticavel funcionario, string senha)
        {
            bool isAutenticado = funcionario.Autenticar(senha);
            string msg = isAutenticado? "Usuário autenticado!" : "Senha Incorreta";
            Console.WriteLine(msg);
        }
    }
}
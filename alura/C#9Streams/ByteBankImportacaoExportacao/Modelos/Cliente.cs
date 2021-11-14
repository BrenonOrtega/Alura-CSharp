using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBankImportacaoExportacao
{
    public class Cliente
    {
        public Cliente(string nome)
        {
            Nome = nome;
        }

        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Profissao { get; set; }
    }
}

using System;

namespace ByteBank.Modelos.Data 
{
  public class Cliente 
  {
      public Cliente(string nome, long cpf, string profissao, int telefone=0){
        this.Nome = nome; 
        this.CPF = cpf;
        this.Profissao = profissao;
        this.Telefone = telefone;
      }

      public string Nome { get; set; }
      public long CPF { get; set; }
      public string Profissao { get; set; }
      public int Telefone { get; set; }
  }
}

using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.IO;


namespace Entity.models
{
    public class CarrosDbContext : DbContext {
        public DbSet<Carro> Carros{ get; set; }
        public DbSet<Fabricante> Fabricantes {  get; set; }

        string path = Path.GetDirectoryName(Directory.GetCurrentDirectory());
        protected override void OnConfiguring(DbContextOptionsBuilder options) {
            options.UseSqlite(@$"Data Source={path}\entity\Database\Automotive.db");
        }
    }
    
    public class Carro {
        public int CarroId { get; set; }
        public string Modelo { get; set; }
        public string Motor { get; set; }
        public double Cilindrada { get; set; }
        public decimal Preco { get; set; }
        public string Placa { get; set; }
        public int FabricanteId {get; set;}
        public Fabricante Fabricante {get; set;}

    }

    public class Fabricante {
        public Fabricante (string nome, int anoFundacao, string sede) {
            Nome =   nome;
            AnoFundacao = anoFundacao;
            Sede = sede;
        }
        public int FabricanteId { get; set; }
        public string Nome { get ; set ;}
        public int AnoFundacao { get; set; }
        public string Sede {get; set;}
        public List<Carro> Carros {get;} = new List<Carro>();

    }
}
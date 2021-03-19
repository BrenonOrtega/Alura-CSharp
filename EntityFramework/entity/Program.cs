using System;
using System.Collections.Generic;
using System.Linq;
using Entity.models;

namespace entity
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var db = new CarrosDbContext())
            {
                 //Creating a car
                Fabricante fabricante = new Fabricante {    AnoFundacao = 1912,
                                                            Nome = "Ford",
                                                            Sede = "Michigan"
                                                        };

                Carro carro = new Carro {   Modelo = "Escort", 
                                            Motor = "Zetec 1.8",
                                            Cilindrada = 1800,
                                            Preco = 6000.00m,
                                            Placa = "CNA-4078"
                                        };
                
                
                if (db.Fabricantes.Any(F => F.Nome != fabricante.Nome))
                {
                    fabricante.Carros.Add(carro);
                    db.Add(fabricante);
                    log(fabricante);
                }
                else {
                    string NomeFabricante = "Ford";
                    carro.Fabricante = db.Fabricantes.Where(F => F.Nome == NomeFabricante).FirstOrDefault();
                    log(carro);
                    db.Add(carro);
                    db.SaveChanges();
                }
                
                List<Fabricante> removidos = db.Fabricantes.Where(f => f.FabricanteId > 1).ToList();
                foreach (var removido in removidos) {
                    db.Remove(removido);
                }
                db.SaveChanges();
                
            }

        }

        static void log(object msg) => Console.WriteLine(msg);
    }
}

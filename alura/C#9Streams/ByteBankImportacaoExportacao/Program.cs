using ByteBankImportacaoExportacao.Modelos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBankImportacaoExportacao
{
    partial class Program
    {
        static async Task Main(string[] args)
        {
            if (CheckExercise(args, "first-exercise"))
                await WorkingWithStreamsAndBuffers(args);

            if (CheckExercise(args, "second-exercise"))
                await WorkingWithStreamReader(args);
                
            if (CheckExercise(args, "third-exercise"))
                await CreatingAccountsFromStream(args);
                
        }

        private static async Task CreatingAccountsFromStream(string[] args)
        {
            using var fs = new FileStream(_fileAddress, FileMode.Open);
            using var reader = new StreamReader(fs);

            do { 
                var fileLine = await reader.ReadLineAsync();
                var account = fileLine.ToContaCorrente(' ');
                System.Console.WriteLine(account);
            } while (reader.EndOfStream is false);
        }
        private static bool CheckExercise(string[] args, string exerciseName = "first exercise") => exerciseName.ToLower().Equals(args?[0]);
    }

    static class Extensions
    {
        public static ContaCorrente ToContaCorrente(this string fileLine, char separator) 
        {
            try
            {
                var splitted = fileLine.Split(separator);
                var agencia = int.Parse(splitted[0]);
                var numero = int.Parse(splitted[1]);
                var saldo = double.Parse(splitted[2]);
                var nome = splitted[3];
                return new ContaCorrente(agencia, numero, saldo, new Cliente(nome));
            } 
            catch 
            {
                return new ContaCorrente(0, 0, 0 , new Cliente(""));
            }

        }
    }
}

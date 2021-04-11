using System;
using System.IO;

namespace FileReader
{
    public class Reader : IDisposable
    {
        public string NomeArquivo { get; }
        public Reader(string nomeArquivo) {
            NomeArquivo = nomeArquivo;
        }

        public void OpenFile() => Console.WriteLine("Abri o arquivo");
        public string ReadLine() { 
            Console.WriteLine("Lendo uma linha");
            throw new IOException("Deu ruim meu querido.");
            return "Linha do arquivo";
        }

        public void CloseFile() => Console.WriteLine("Fechei o arquivo.");

        public void Dispose() => CloseFile();
    }
}
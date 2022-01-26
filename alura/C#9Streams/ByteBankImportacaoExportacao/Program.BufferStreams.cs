using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ByteBankImportacaoExportacao
{
    partial class Program
    {
        static string _fileName = "contas.txt";
        static string _fileAddress = Path.Join("Database", _fileName);
        static byte[] _buffer = new byte[1024];

        static async Task WorkingWithStreamsAndBuffers(string[] args)
        {
            var readByte = -1;
            using (var stream = new FileStream(_fileAddress, FileMode.Open))
            {
                do
                {
                    readByte = await stream.ReadAsync(_buffer, 0, _buffer.Length);
                    Process(_buffer, readByte);
                } while (readByte != 0);
            }
            Console.ReadLine();
        }

        private static async Task WorkingWithStreamReader(string[] args)
        {
            using var fileStream = new FileStream(_fileAddress, FileMode.Open);
            using var streamReader = new StreamReader(fileStream);

            do
            {
                var line = await streamReader.ReadLineAsync();

                System.Console.WriteLine(line);
            } while (streamReader.EndOfStream is false);
        }

        private static async Task CreatingAccountsFromStream(string[] args)
        {
            using var fs = new FileStream(_fileAddress, FileMode.Open);
            using var reader = new StreamReader(fs);

            do
            {
                var fileLine = await reader.ReadLineAsync();
                var account = fileLine.ToContaCorrente(' ');
                System.Console.WriteLine(account);
            } while (reader.EndOfStream is false);
        }

        static void Process(byte[] buffer, int readBytes)
        {
            var utf8 = new UTF8Encoding();
            var @string = utf8.GetString(buffer, 0, readBytes);

            System.Console.WriteLine(@string);
        }
    }
}
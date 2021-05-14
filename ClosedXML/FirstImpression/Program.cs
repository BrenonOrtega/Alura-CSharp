using System;
using System.ComponentModel.DataAnnotations;
using ClosedXML;
using ClosedXML.Excel;
using Deedle;
using System.Linq;
using Deedle.Internal;
using System.Collections.Generic;

namespace FirstImpression
{
    class Program
    {
        static void Main(string[] args)
        {
            var wb = new XLWorkbook();
            var ws = wb.AddWorksheet("Bank Churners");
            var df = Frame.ReadCsv("./resources/BankChurners.csv");

            var headers = df.ColumnKeys.ToList();
            var headersCount = headers.Count() - 1;

            var wsHeaders = ws.Row(1);

            foreach (var column in Enumerable.Range(1, headers.Count() - 1))
            {
                var value = wsHeaders.Cell(column).Value = headers[column];
                System.Console.WriteLine(value);
            }

            var headersName = new List<string>();
            wsHeaders.Cells(1, headersCount).ToList().ForEach( x => {
                headersName.Add(x.GetValue<string>());
            });

            System.Console.WriteLine(String.Join("", headersName));
            
            wb.SaveAs("teste1.xlsx");
            //df.Print();


        }
    }
}

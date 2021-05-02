using System;
using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Drawing;
using OfficeOpenXml.Table.PivotTable;
using System.Diagnostics;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Style;

namespace ExcelDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            LicenseContext license = LicenseContext.NonCommercial;
            ExcelPackage.LicenseContext = license;

            var file = new FileInfo(@"C:\Users\Bryan\Desktop\ExcelDemo.xlsx");
            var people = GetSetupData();

            await SaveExcelFile(people, file);
        }

        private static async Task SaveExcelFile(List<PersonModel> people, FileInfo file)
        {
            DeleteIfExists(file);

            using var package = new ExcelPackage(file);
            var ws = package.Workbook.Worksheets.Add("InitialReport");
            ws.Cells.Style.Font.Size = 17;
            ws.Cells.Style.Font.Color.SetColor(Color.DarkBlue);

            ws.Row(1).Style.Fill.PatternType = ExcelFillStyle.Solid;
            ws.Row(1).Style.Fill.BackgroundColor.SetColor(Color.LightGreen);

            var borderStyle = ExcelBorderStyle.Thin;
            ws.Row(1).Style.Border.BorderAround(borderStyle);
            ws.Row(1).Style.Border.Left.Style=(borderStyle);
            ws.Row(1).Style.Border.Right.Style=(borderStyle);

            var range = ws.Cells["A1:c1"].LoadFromCollection(Collection:people, PrintHeaders:true);
            range.AutoFitColumns();

            await package.SaveAsync();
            try {
                Process.Start("Explorer.exe", file.FullName);
            } catch (Exception e) {
                System.Console.WriteLine(e.Message);
            }
        }

        private static void DeleteIfExists(FileInfo file)
        {
            if (file.Exists) 
                file.Delete();
        }

        static List<PersonModel> GetSetupData() 
        {   
            List<PersonModel> data = new() {
                new() {Id = 1, FirstName="Bryan", LastName= "Ortega", Age=23},
                new() {Id = 1, FirstName="Lan", LastName= "Bruno", Age=27},
                new() {Id = 1, FirstName="Matheus", LastName= "Francis", Age=22}
            };
            return data;
        }
    }
}

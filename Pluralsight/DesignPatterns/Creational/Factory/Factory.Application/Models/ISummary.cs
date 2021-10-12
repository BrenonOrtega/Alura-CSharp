namespace Factory.Application.Models
{
    public interface ISummary
    {
        string GetSummary();
    }

    public class CsvSummary : ISummary
    {
        public string GetSummary() => "csv,s,2,q";
    }

    public class FileSummary : ISummary
    {
        public string GetSummary() => "C://A-Random-Fold-In-Disk/A-Random-File-Name.txt";
    }
}
using System.Linq;
using System.Text.Json;

namespace Factory.Application.Models
{
    public interface ISummary
    {
        string Stringify(string formattedTotal);

        string GetSummary();
    }

    public abstract class SummaryBase : ISummary
    {
        private readonly Order _order;

        public abstract string GetSummary();

        public SummaryBase(Order order)
        {
            _order = order;
        }

        public virtual string Stringify(string formattedTotal) => 
            JsonSerializer.Serialize(new
            {
                Order = new { _order.OriginCountry, SubTotal = _order.SubTotal.ToString("C2"), Total = formattedTotal },
                Items = _order.Items.Select(x => new { x.item, x.price, x.quantity }),
            },
             new JsonSerializerOptions { WriteIndented = true });
    }

    public class CsvSummary : SummaryBase, ISummary
    {
        public CsvSummary(Order order) : base(order) {  }

        public override string GetSummary() => "csv,s,2,q";
    }

    public class FileSummary : SummaryBase
    {
        public FileSummary(Order order) : base(order) {  }

        public override string GetSummary() => "C://A-Random-Fold-In-Disk/A-Random-File-Name.txt";
    }
}
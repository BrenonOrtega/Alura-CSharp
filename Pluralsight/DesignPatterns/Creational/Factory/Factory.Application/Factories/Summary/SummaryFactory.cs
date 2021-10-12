using Factory.Application.Models;

namespace Factory.Application.Factories.Summary
{
    public abstract class SummaryFactory
    {
        protected abstract ISummary CreateSummary(Order order);

        public ISummary GetSummary(Order order) => CreateSummary(order);
    }

    public class CsvSummaryFactory : SummaryFactory
    {
        protected override ISummary CreateSummary(Order order)
        {
            return new CsvSummary(order);
        }
    }

    public class FileSummaryFactory : SummaryFactory
    {
        protected override ISummary CreateSummary(Order order)
        {
            return new FileSummary(order);
        }
    }
}
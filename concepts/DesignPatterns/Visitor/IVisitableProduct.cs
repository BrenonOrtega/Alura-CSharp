namespace Visitor
{
    public interface IVisitableProduct : IVisitable
    {
        public decimal Amount { get; set; }
    }
}
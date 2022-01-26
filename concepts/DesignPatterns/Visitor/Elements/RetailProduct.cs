namespace Visitor.Elements
{
    public class RetailProduct : IVisitableProduct
    {
        public decimal Amount { get; set; }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
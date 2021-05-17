namespace CatalogApp.Business.Interfaces
{
    public interface IReadingList
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Category { get; set; }
    }
}
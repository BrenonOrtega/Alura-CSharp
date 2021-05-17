using System.Collections.Generic;
using CatalogApp.Business;

namespace CatalogApp.Database.Repository.Interfaces
{
    public interface IBookRepository
    {
        public IList<Book> GetAll(int? first=0, int? last=20);
        public Book FindOne(int id);
        public IEnumerable<Book> FindByTitle(string title);

        public void Update(Book updatedBook);

        public void Delete(int id);
    }
}
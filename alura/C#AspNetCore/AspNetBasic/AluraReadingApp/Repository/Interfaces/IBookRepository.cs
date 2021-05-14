using System.Collections.Generic;
using AluraReadingApp.Business;

namespace AluraReadingApp.Repository.Interfaces
{
    public interface IBookRepository
    {
        public IEnumerable<Book> GetAll();
        public Book FindOne(int id);
        public Book FindByTitle(string title);

        public void Update(Book updatedBook);

        public void Delete(int id);
    }
}
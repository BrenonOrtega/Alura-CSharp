using System.Collections.Generic;
using System.Linq;
using System.Text;
using CatalogApp.Business.Interfaces;

namespace CatalogApp.Business
{
    public class ReadingList : IReadingList
    {
        public ReadingList() {  }
 
        public ReadingList(int id, string title, string category, params Book[] booksArray)
        {
            Id = id;
            Title = title;
            Category = category;
            books = booksArray.ToList();
            books.ForEach(x => x.List=this);
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Creator { get; set; }
        public List<string> Tags { get; set; }
        private List<Book> books;
        public IEnumerable<Book> Books { get => books; }

        public override string ToString()
        {
            var strbldr = new StringBuilder();
            strbldr.Append(Title);
            strbldr.Append("----------------------");
            books.ForEach(book => strbldr.Append(book));
            return strbldr.ToString();
        }
    }
}
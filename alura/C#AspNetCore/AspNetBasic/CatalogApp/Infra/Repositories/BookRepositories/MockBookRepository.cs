using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using CatalogApp.Business;
using CatalogApp.Database.Repository.Interfaces;

namespace CatalogApp.Database.Repository.BookRepositories
{
    public class MockBookRepository : IBookRepository
    {
         private List<Book> books = new List<Book>() {
            new(){Id=1, Title="Design Patterns", Description="Bible of design patterns", Author="Gang of Four"},
            new(){Id=2, Title="C# tips", Description="Learn C#", Author="a random MVP"},
            new(){Id=3, Title="Automate with Python", Description="Make your life easier with python", Author="Pythonista"},
            new(){Id=4, Title="Clean Code", Description="Best programming practices", Author="Uncle Bob"}
        };
        public void Delete(int id)
        {
            books.Remove( books.First(book => book.Id == id) ?? throw new ArgumentException("Id not Found"));
        }

        public IEnumerable<Book> FindByTitle(string title)
        {
            return books.FindAll(book => book.Title.ToLower().Contains(title.ToLower()));
        }

        public Book FindOne(int id)
        {
            return books.Find(book => book.Id == id);
        }

        public IList<Book> GetAll(int? first=0, int? last=20)
        {
 
            return books.ToImmutableArray();
        } 

        public void Update(Book updatedBook)
        {
            var book = books.First(book => book.Id == updatedBook.Id);
            _ = book is not null? books.Remove(book) : throw new KeyNotFoundException("Id not found");
            
            books.Add(updatedBook);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using CatalogApp.Business;
using CatalogApp.Database.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CatalogApp.Database.Repository.BookRepositories
{
    public class SqliteBookRepository : IBookRepository
    {
        private ReadingAppContext _context;

        public SqliteBookRepository(ReadingAppContext context)
        {
            _context = context;    
        }

        public void Delete(int id)
        {
            Book book = _context.Books.FirstOrDefault(b=>b.Id.Equals(id));
            
            _context.Books.Remove(book ?? throw new ArgumentException("book not found"));
            _context.SaveChanges();
        }

        public IEnumerable<Book> FindByTitle(string title)
        {
            return _context.Books.Where(b => b.Title.Contains(title)).ToList();
        }

        public Book FindOne(int id)
        {
            return _context.Books.FirstOrDefault(b => b.Id.Equals(id));
        }

        public IList<Book> GetAll(int? first=0, int? last=20)
        {
            first = first ?? 0; 
            last = last ?? 20;
            return _context.Books.Where(book => first >= book.Id && book.Id<=last).ToImmutableArray();
        }

        public IEnumerable<Book> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Book updatedBook)
        {
            throw new System.NotImplementedException();
        }
    }
}
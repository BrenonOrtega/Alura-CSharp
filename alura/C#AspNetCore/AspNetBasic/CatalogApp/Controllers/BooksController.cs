
using CatalogApp.Business;
using CatalogApp.Database.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CatalogApp.Controllers
{   
    public class BooksController : Controller
    {
        public IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public string Index() => "That's me trying asp.net core inside Docker with hot reload";
        public List<Book> GetBooks()
        {
            return new List<Book>(_bookRepository.GetAll());
        }

        public Book GetOne([FromRoute]int id)
        {
            return _bookRepository.FindOne(id);
        }

        [HttpGet("/[Controller]/[Action]/{title}")]
        public List<Book> Title(string title)
        {
            _ = title ?? throw new Exception();
            title = title.Replace("-", " ");
            return _bookRepository.FindByTitle(title).ToList();
        }
    }
}

using AluraReadingApp.Business;
using AluraReadingApp.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text.Encodings.Web;

namespace AluraReadingApp.Controllers
{   
    public class ReadingListController : Controller
    {
        public IReadingListRepository _readingListRepository;

        public ReadingListController(IReadingListRepository readingListRepository)
        {
            _readingListRepository = readingListRepository;
        }
        public string Index() => "That's me trying asp.net core";
        public List<ReadingList> GetLists()
        {
            return _readingListRepository.GetAll();
        }

       /*  public Book GetOne([FromRoute]int id)
        {
            return _bookRepository.FindOne(id);
        }

        [HttpGet("/[Controller]/[Action]/{title}")]
        public Book Title(string title)
        {
            _ = title ?? throw new Exception();
            title = title.Replace("-", " ");
            return _bookRepository.FindByTitle(title);
        } */
    }
}
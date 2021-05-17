
using CatalogApp.Business;
using CatalogApp.Database.Repository.Interfaces;
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

       public ReadingList GetOne([FromRoute]string id)
        {
            return _readingListRepository.FindOne(id);
        }

        [HttpGet("/[Controller]/[Action]/{title}")]
        public ReadingList Title(string title)
        {
            _ = title ?? throw new Exception();
            title = title.Replace("-", " ");
            return _readingListRepository.FindByTitle(title);
        } 
    }
}
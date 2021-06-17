using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using EntityAccessData.DataAccess;
using EntityAccessedData.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace EntityASP.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly PeopleContext _db;

        public IndexModel(ILogger<IndexModel> logger, PeopleContext db)
        {
            _logger = logger;
            _db  = db;
        }

        public void OnGet()
        {
            LoadSampleData();
        }

        public void LoadSampleData() {
            if (_db.People.Count() == 0){
                string file = System.IO.File.ReadAllText("..\\SampleDataEntityTuto.json");
                var people = JsonSerializer.Deserialize<List<Person>>(file);
                _db.People.AddRange(people);
                _db.SaveChanges();
            }
        }
    }
}

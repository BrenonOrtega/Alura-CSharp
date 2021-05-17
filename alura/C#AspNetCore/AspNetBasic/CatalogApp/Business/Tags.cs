using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CatalogApp.Business.Interfaces;

namespace CatalogApp.Business
{
    public class Tags
    {
        [Required]
        [MaxLength(25), Key]
        public string Name { get; set; }
        List<Book> books;
        List<IReadingList> lists;


    }
}
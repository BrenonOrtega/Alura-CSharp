using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CatalogApp.Business.Interfaces;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CatalogApp.Business
{
    
    public class Book
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get; set;}
        [MaxLength(40)]
        public string Title { get; set; }
        [MaxLength(125)]
        public string Description { get; set; }
        public DateTime LaunchDate { get; set; }
        [Required, MaxLength(30)]
        public string Author { get; set; }

        [NotMapped]
        private IReadingList list;
        public ReadingList List 
        { 
            get=> (ReadingList)list; 
            set => list = value;
        }

        public override string ToString()
        {
            return $"{nameof(Title)}: {Title} - {nameof(Author)}: {Author}";
        }
    }
}
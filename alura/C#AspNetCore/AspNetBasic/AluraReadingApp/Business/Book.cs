using System;
using AluraReadingApp.Business.Interfaces;

namespace AluraReadingApp.Business
{
    public class Book
    {
        public int Id {get; set;}
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime LaunchDate { get; set; }
        public string Author { get; set; }

        private IReadingList list;
        public IReadingList List { get=>list; set => list = value; }

        public override string ToString()
        {
            return $"{nameof(Title)}: {Title} - {nameof(Author)}: {Author}";
        }
    }
}
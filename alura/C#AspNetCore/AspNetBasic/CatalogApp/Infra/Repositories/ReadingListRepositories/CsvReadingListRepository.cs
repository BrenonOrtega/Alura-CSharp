using System;
using System.Collections.Generic;
using System.IO;
using CatalogApp.Business;
using CatalogApp.Database.Repository.Interfaces;

namespace CatalogApp.Database.Repository.ReadingListRepositories
{
    public class CsvReadingListRepository : IReadingListRepository
    {
        private static readonly string csv = Path.Join(Directory.GetCurrentDirectory(), "../livros.csv");

        List<Book> toReadBooks;
        List<Book> readingBooks;
        List<Book> readBooks;

        public CsvReadingListRepository()
        {
            toReadBooks = new List<Book>();
            readingBooks = new List<Book>();
            readBooks = new List<Book>();

            using (var file = File.OpenText(CsvReadingListRepository.csv))
            {
                while (!file.EndOfStream)
                {
                    var bookLine = file.ReadLine();
                    if (string.IsNullOrEmpty(bookLine))
                        continue;
                
                    var bookInfo = bookLine.Split(';');
                    var book = new Book { Id = Convert.ToInt32(bookInfo[1]), Title = bookInfo[2], Author = bookInfo[3] };

                    switch (bookInfo[0])
                    {
                        case "para-ler":
                            toReadBooks.Add(book);
                            break;
                        case "lendo":
                            readingBooks.Add(book);
                            break;
                        case "lidos":
                            readBooks.Add(book);
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public ReadingList FindByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public ReadingList FindOne(string id)
        {
            throw new NotImplementedException();
        }

        public List<ReadingList> GetAll()
        {
            return new List<ReadingList>(){
                new ReadingList(1, "To Read Books", "To Read Books",  toReadBooks.ToArray()),
                new ReadingList(2, "Reading Books", "Reading Books",  readingBooks.ToArray()),
                new ReadingList(3, "Read Books", "Read Books",  readBooks.ToArray())
            };
        }

        public void Update(string id)
        {
            throw new NotImplementedException();
        }
    }
}
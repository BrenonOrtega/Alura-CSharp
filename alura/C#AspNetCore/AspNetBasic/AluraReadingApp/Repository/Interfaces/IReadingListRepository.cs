using System.Collections.Generic;
using AluraReadingApp.Business;

namespace AluraReadingApp.Repository.Interfaces
{
    public interface IReadingListRepository
    {
        public List<ReadingList> GetAll();

        public ReadingList FindOne(string id);

        public ReadingList FindByTitle(string title);

        public void Update(string id);

        public void Delete(string id);
    }
}
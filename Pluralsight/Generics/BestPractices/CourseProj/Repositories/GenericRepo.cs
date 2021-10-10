using System.Collections.Generic;

namespace BestPractices
{
    class GenericRepo<T> : IRepository<T> where T : new()
    {
        IEnumerable<(string FirstName, string LastName)> GetName()
        {
            yield return ("dick", "grayson");
            yield return ("bruce", "wayne");
            yield return ("Clark", "Kent");
            yield return ("Diana", "prince");
            yield return ("peter", "miranha");
        }
        public GenericRepo(int initialQuantity = 5)
        {
            for (int i = 0; i <= initialQuantity; i++)
            {
                var enumerator = GetName().GetEnumerator();
                var (FirstName, LastName) = enumerator.Current;
                TList.AddLast(new T() { });
            }
        }

        LinkedList<T> TList = new LinkedList<T>();
        public IEnumerable<T> List => GetNext();
        private IEnumerable<T> GetNext()
        {
            foreach (var item in TList)
                yield return item;
        }

        public void Add(T obj) => TList.AddLast(obj);
    }
}
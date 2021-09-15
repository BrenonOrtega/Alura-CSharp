using System;
using ArraysAndCollection.Models.Extensions;

namespace ArraysAndCollection.Models.Shared
{
    public abstract class Repository<T> : IRepository<T>
    {
        protected virtual T[] Data { get; set; }

        public bool Add(T entity)
        {
            if (Data.Length < 0 || Data[^1] is not null)
                Data = new T[Data.Length + 1];

            Data[^1] = entity;
            return true;
        }

        private bool IsDefault(T t) => Data[^1].Equals(default(T));

        public T[] Get(Func<T, bool> filter = null) => Array.FindAll<T>(Data, filter.ToPredicate());

        public T GetSingle(Func<T, bool> filter = null) => Array.Find<T>(Data, filter.ToPredicate());

        private bool GetAll(T arg) => true;

        public bool Remove(Func<T, bool> filter = null)
        {
            var index = Array.FindIndex(Data, filter.ToPredicate());
            Data[index] = default(T);

            Data = Array.FindAll(Data, x => IsDefault(x) is false);
            return true;
        }

        public bool Update(T entity, Func<T, bool> filter = null)
        {
            var actual = Array.Find(Data, filter.ToPredicate());
            actual = entity;
            return true;
        }
    }

}
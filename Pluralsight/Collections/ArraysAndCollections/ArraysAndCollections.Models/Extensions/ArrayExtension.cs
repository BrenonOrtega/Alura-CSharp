using System;

namespace ArraysAndCollections.Models.Extensions
{
    static class ArrayExtension
    {
        public static Predicate<T> ToPredicate<T>(this Func<T, bool> func) => new Predicate<T>(func ?? GetAll);
        private static bool GetAll<T>(T obj) => true;
    }

}
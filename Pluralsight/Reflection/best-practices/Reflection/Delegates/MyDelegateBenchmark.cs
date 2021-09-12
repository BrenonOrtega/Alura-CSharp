using System;
using System.Linq;
using System.Reflection;
using BenchmarkDotNet.Attributes;
using Reflection.Classes;

namespace Reflection.Delegates
{
    public class MydelegateBench
    {
        [Benchmark]
        public void Linq_Single()
        {
            var person = new Person() { Name = "mine" };

            Action<Person, Func<Person, String>> a = (Person person, Func<Person, String> func) =>
            {
                var prop = func(person) ?? "";
                var personType = typeof(Person);

                var properties = personType.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);

                var info = Array.Find(properties, x => Object.ReferenceEquals(x?.GetValue(person), prop));

                var propInfo = properties.First(propertyInfo =>
                {
                    var value = propertyInfo.GetValue(person);
                    return Object.ReferenceEquals(prop, value);
                });

                var newValue = "oh my god";
                propInfo.SetValue(person, newValue);
            };

            var deleg = a;
            Console.Out.WriteLine(person.Name);

            deleg.Invoke(person, x => x.Name);
        }

        [Benchmark]
        public void Array_Find()
        {
            var person = new Person() { Name = "mine" };

            Action<Person, Func<Person, String>> b = (Person person, Func<Person, String> func) =>
            {
                var prop = func(person) ?? "";
                var personType = typeof(Person);

                var properties = personType.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);

                var info = Array.Find(properties, x => Object.ReferenceEquals(x?.GetValue(person), prop));

                var newValue = "oh my god";
                info.SetValue(person, newValue);
            };

            var deleg2 = b;
            Console.Out.WriteLine(person.Name);

            deleg2.Invoke(person, x => x.Name);
        }

        
    }
}
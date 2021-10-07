using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace BestPractices
{
    public class Program
    {
        static async Task Main(string[] args)
        {

            Console.WriteLine("a");
            var person = new Person("hello", "i'm dave", 33);
            Console.WriteLine(person);

            var otherPerson = person with { FirstName = "GoodBye" };
            Console.WriteLine(otherPerson);

            var path = Path.Join(AppContext.BaseDirectory, "..\\..\\..\\file.json");
            var serializedPerson = JsonSerializer.Serialize(person, new JsonSerializerOptions() { WriteIndented = true, });

            Console.WriteLine(person.Greet);

            await File.WriteAllTextAsync(path, serializedPerson);

            IEnumerable<Person> people = GetPeople();

            foreach (var pers in people)
                Console.WriteLine(pers);

            IEnumerable<Person> GetPeople(int quantity = 1000)
            {
                for (var v = 0; v <= quantity; ++v)
                {
                    Console.WriteLine("I've just been born!");
                    yield return new Person($"Person {v}", $"LastName {v}", v);
                }
            }
        }
    }
}
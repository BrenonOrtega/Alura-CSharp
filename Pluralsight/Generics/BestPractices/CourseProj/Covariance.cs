using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestPractices.Variance
{
    public class ReflectionExamples
    {
        public static void Run(string[] args)
        {
            JustGetGenericType();
        }
        private static void JustGetGenericType()
        {
            var repoType = typeof(IRepository<>);
            var stringBuilder = new StringBuilder();
            var processor = new ConcretePersonProcessor();
            var person = new Person("Brenon", "Ortega");
            var engineer = processor.Graduate(person).Result;

            Console.WriteLine(engineer);

            stringBuilder.Append($"Type: { repoType.Name }|".PadRight(10))
                .Append($"| Generic: { repoType.IsGenericType }".PadRight(15))
                .Append($"| Generic definition: { repoType.IsGenericTypeDefinition }".PadRight(15))
                .AppendLine(".")
                .Append($"| IsGenericTypeParameter: { repoType.IsGenericTypeParameter }".PadRight(15))
                .Append($"| IsGenericMethodParameter: { repoType.IsGenericMethodParameter }".PadRight(15));

            Console.WriteLine(stringBuilder);
        }
    }
    interface IProcessor<in TIn, out TOut>
    {
        TOut Graduate(TIn input);
        TOut Process(TIn input);
        TOut Process(string input);
    }
    
    public class ConcretePersonProcessor : IProcessor<Person, Task<Engineer>>
    {
        public Task<Engineer> Graduate(Person input) => Task.FromResult(new Engineer("eletrical", "Brenon", "Ortega", 20));
        public Task<Engineer> Process(Person input) => Task.Run(() => new Engineer("", "", "", 25));
        public Task<Engineer> Process(string input)
        {
            var @string = input.Split();
            return Task.FromResult(new Engineer("Basic", @string.First(), @string.Last(), 25));
        }
    }
}
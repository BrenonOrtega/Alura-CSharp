using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using System.Collections;

namespace BestPractices.tests
{

    public class IEnumerableTests
    {
        [Fact]
        public void YieldingShouldEnumerateData()
        {
            var expected = new List<string> { "a", "b", "c" };

            var enumerator = expected.GetEnumerator();

            var actual = enumerator.Current;
            do
            {
                var next = enumerator.MoveNext() ? enumerator.Current : null;
                System.Console.WriteLine(actual);
                actual = next;
            } while (actual is not null);
        }

        [Fact]
        public async Task IAsyncEnumerable_Works_With_TaskYield()
        {
            var expected = GetStringAsync();

            await foreach(var i in expected)
                System.Console.WriteLine(i);

            expected.Should().NotBeNull();
            expected.Should().BeAssignableTo<IEnumerable>();
        }

        public async IAsyncEnumerable<string> GetStringAsync()
        {
            var i = new HashSet<string>() { "a", "b", "c", "d", "e" };
            foreach(var j in i)
            {
                await Task.Delay(1000);
                yield return j;
            }
        }
    }
} 
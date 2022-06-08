using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }

    public int[] solution(int[] a)
    {
        var list = new List<int>();

        foreach (var number in a)
        {
            if (number > 9)
            {
                var chars = number.ToString()
                    .ToCharArray()
                    .Select(x => (int) Char.GetNumericValue(x));

                list.AddRange(chars);
            }
            else
            {
                list.Add(number);
            }
        }

        var hashset = new HashSet<int>(list);

        var dict = new Dictionary<int, int>();
        var max = 0;

        foreach (var entry in hashset)
        {
            var count = list.Count(x => x == entry);
            if(count > max)
                max = count;
            dict.Add(entry, count);
        }

        var maxOccurrences = dict.Where(x => x.Value == max).Select(x => x.Key);
 
        return maxOccurrences.OrderBy(x => x).ToArray();
    }
}

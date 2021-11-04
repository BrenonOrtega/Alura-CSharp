using System;
using System.Collections.Generic;
using Bridge.Pattern.Ingredients;
using Bridge.Pattern.Recipes;

namespace Bridge.Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var ingredients = new List<Ingredient>()
            {
                new Bacon(), new Cheese(), new Bread(), new Meat()
            };

            var cheesebacon = new Food("Cheesebacon", ingredients);

            System.Console.WriteLine((cheesebacon));
        }
    }
}
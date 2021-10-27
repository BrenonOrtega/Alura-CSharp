using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bridge.Pattern.Ingredients;

namespace Bridge.Pattern.Recipes
{
    public record Hamburger(string Name, ICollection<Ingredient> Ingredients)
    {
        public override string ToString()
        {
            return nameof(Hamburger) + Name + string.Join(',',Ingredients.Select(x => x.Name));
        }
    };
}
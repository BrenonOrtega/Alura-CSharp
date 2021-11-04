using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bridge.Pattern.Ingredients
{
    public abstract record Ingredient(string Name);
    public record Meat() : Ingredient("Meat");

    public record Cheese() : Ingredient("Cheese");

    public record Bacon() : Ingredient("Bacon");

    public record Lettuce() : Ingredient("Lettuce");

    public record Onions() : Ingredient("Onions");

    public record Bread() : Ingredient("Bread");
}
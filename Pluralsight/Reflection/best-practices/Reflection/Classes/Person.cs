using System;
using Reflection.Interfaces;

namespace Reflection.Classes
{
    public class Person : ITalk
    {
        public string Name { get; set; }

        private int age;
        public int  Age { get => age; set => age = value; }

        public Person()
        {
            Console.Out.WriteLine("Instantianting person with default constructor");
        }

        public Person(string name)
        {
            Console.Out.WriteLine("Instantianting named {0} person with parametrized constructor", name);
            Name = name;
        }
                
        private Person(string name, int age)
        {
            Console.Out.WriteLine("Instantianting person named {0}, {1} years old with private constructor", name, age);
            Name = name;
            Age = age;
        }

        public void Talk()
        {
            System.Console.Out.WriteLine($"{nameof(Person)}{nameof(Talk)}(): Gordo idiota.");
        }
    }
}
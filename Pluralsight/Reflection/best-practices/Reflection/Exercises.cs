using System;
using System.Reflection;
using Reflection.Classes;

namespace Reflection
{
    public static class Exercises
    {
        public static void GetPropertyPassedInMethodWithLambdaFunction()
        {
            var person = new Person() { Name = "mine" };

            Action<Person, Func<Person, String>> changeProperty = (Person person, Func<Person, String> func) =>
            {
                var prop = func(person) ?? "";
                var personType = typeof(Person);

                var properties = personType.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);

                var propInfo = Array.Find(properties, x => Object.ReferenceEquals(x?.GetValue(person), prop));

                var newValue = "oh my god";
                propInfo.SetValue(person, newValue);
            };

            Console.Out.WriteLine(person.Name);

            changeProperty(person, x => x.Name);

            Console.Out.WriteLine(person.Name);
        }

        public static void InvokePropertyUsingPropertyName(string[] args)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var alienCtor = assembly.GetType("Reflection.Classes.Alien")?.GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, Type.DefaultBinder, new Type[]{}, null);
            var alien = alienCtor?.Invoke(null);
            
            var type = alien.GetType();
            var setter = type.GetProperty("Name", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.SetProperty);
            setter.SetValue(alien, "Et Bilu");
            
            var etName = type.InvokeMember(
                "Name",
                BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetProperty,
                Type.DefaultBinder,
                alien,
                null,
                null);

            System.Console.Out.WriteLine(etName);
        }
    }
}
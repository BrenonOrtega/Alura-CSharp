using System;
using System.Reflection;
using ArraysAndCollections.Models;
using ArraysAndCollections.Models.Shared;

namespace ArraysAndCollections.Application
{
    public partial class Program
    {
        static void RunExercises(string[] args)
        {
            Explain();

            var assemblies = Array.FindAll(
                Assembly.GetExecutingAssembly().GetTypes(),
                type => IsExercise(type) && ShouldExecute(type, args) 
            );

            BindingFlags ExerciseFlags = BindingFlags.Instance 
                | BindingFlags.DeclaredOnly 
                | BindingFlags.InvokeMethod 
                | BindingFlags.Public
                ;

            Array.ForEach(assemblies, 
                a => a.InvokeMember(
                    name: nameof(IExercise.Run),
                    invokeAttr: ExerciseFlags,
                    binder: null,
                    target: Activator.CreateInstance(a, false),
                    args: new[] { args }
                ));
        }

        private static void Explain()
        {
            System.Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine("-----------------------------------------------------------------");
            System.Console.WriteLine(
                "Even though i've used reflection to instantiate a lot of things.\n" +
                "and practice reflection of course, this warning is important \n\n" +
                "TO RUN EACH MODULE FROM 1 TO 8 YOU SHOULD RUN THIS APP AND PASS AS ARGUMENT\n" +
                "THE WORD \"Module\" + THE DESIRED NUMBER LIKE THE FOLLOWING EXAMPLE:\n" +
                "dotnet run -p ArraysAndCollection.Application Module7");
            System.Console.WriteLine("-----------------------------------------------------------------");
            System.Console.ForegroundColor = ConsoleColor.White;
        }

        static bool ShouldExecute(Type type, string[] args) =>  
            args.Length.Equals(0) || Array.Exists(args, arg => type.Name.Equals(arg));
            
        static bool IsExercise(Type type) => type.IsAssignableTo(typeof(IExercise));
    }
}
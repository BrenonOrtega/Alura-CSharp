using System;
using System.Reflection;
using ArraysAndCollection.Models;

namespace ArraysAndCollections.Application
{
    public partial class Program
    {
        static void RunExercises(string[] args)
        {
            var assemblies = Array.FindAll(Assembly.GetExecutingAssembly().GetTypes(), type => IsExercise(type));
            if (Array.Exists(args, x => x.Equals("all")) || args.Length == 0)
                Array.ForEach(assemblies, a =>
                {
                    a.InvokeMember(nameof(IExercise.Run),
                        BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.InvokeMethod | BindingFlags.Public,
                        null,
                        Activator.CreateInstance(a, false),
                        new[] { args });
                });

            else
                Array.ForEach(args, x =>
                {
                    try
                    {
                        //var type = Array.Find(assemblies, a => a.Name.Equals(x));
                        //var method = type.GetMethod("Run", BindingFlags.Static | BindingFlags.InvokeMethod);
                        //type.InvokeMember("Run", BindingFlags.Static | BindingFlags.IgnoreReturn | BindingFlags.IgnoreCase | BindingFlags.DeclaredOnly, Type.DefaultBinder, null, args);
                        //var methods = type.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.InvokeMethod);
                        //Array.Find(methods, m => m.Name == "Run")?.Invoke(null, new[]{ args } );

                        var type = Array.Find(assemblies, a => IsExercise(a) && a.Name.Equals(x));
                        var runnable = Activator.CreateInstance(type, true) as IExercise;
                        runnable.Run(args);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                });
        }

        static bool IsExercise(Type type) => type.IsAssignableTo(typeof(IExercise));
    }
}
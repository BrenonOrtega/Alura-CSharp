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
        static bool ShouldExecute(Type type, string[] args) =>  
            args.Length.Equals(0) || Array.Exists(args, arg => type.Name.Equals(arg));
            
        static bool IsExercise(Type type) => type.IsAssignableTo(typeof(IExercise));
    }
}
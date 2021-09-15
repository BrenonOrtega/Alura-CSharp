using System;
using System.Linq;
using flags = System.Reflection.BindingFlags;

namespace ArraysAndCollections.Application
{
    public static class Extensions
    {
        public static void Log(this object caller, params object[] args)  
        {
            var method = typeof(Console).GetMethod(
                nameof(Console.WriteLine),
                flags.Public | flags.Static,
                Type.DefaultBinder, 
                System.Reflection.CallingConventions.Any,
                args.Select(x => x.GetType()).ToArray(), 
                null
            );

            method?.Invoke(null, args);
        }
    }
}
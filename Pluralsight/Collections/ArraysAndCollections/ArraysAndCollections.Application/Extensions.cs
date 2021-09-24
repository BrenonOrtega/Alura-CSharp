using System;
using System.IO;
using System.Linq;
using flags = System.Reflection.BindingFlags;

namespace ArraysAndCollections.Application
{
    public static class Extensions
    {
        private static StringWriter _stringWritter = new StringWriter();

        public static void Log(this object caller, params object[] args)  
        {
            var method = typeof(Console).GetMethod(
                name: nameof(Console.WriteLine),
                bindingAttr: flags.Public | flags.Static,
                binder: Type.DefaultBinder, 
                callConvention: System.Reflection.CallingConventions.Any,
                types: args.Select(x => x.GetType()).ToArray(), 
                modifiers: null
            );

            method?.Invoke(null, args);
        }

        private static void AppendToReadme(System.Reflection.MethodInfo method, object[] args)
        {
            Console.SetOut(_stringWritter);
            method.Invoke(null, args);
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
            Console.SetIn(new StreamReader(Console.OpenStandardInput()));
        }

        public static void WriteToReadme(string path=null)
        {
            var filePath = path ?? Path.Join(AppContext.BaseDirectory, "../../../readme.md");
            _stringWritter.Close();
            File.WriteAllText(filePath, _stringWritter.ToString());
        }
    }
}
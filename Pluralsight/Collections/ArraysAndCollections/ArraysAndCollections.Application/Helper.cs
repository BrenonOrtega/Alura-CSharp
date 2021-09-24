using System;
using System.Collections;
using System.Collections.Generic;

namespace ArraysAndCollections.Application
{
    public class Helper
    {
        
        public static void PrintWithSpacesAndBars(ConsoleColor color, params object[] messages)
        {
            System.Console.WriteLine();
            PrintWithBars(color, messages);
            System.Console.WriteLine();
        }

        public static void PrintWithBars(ConsoleColor color, params object[] messages)
        {
            Console.ForegroundColor = color;

            System.Console.WriteLine("----------------------------------------------------------------");

            PresentData(messages);

            System.Console.WriteLine("----------------------------------------------------------------");

            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void PresentData(params object[] messages) => Array.ForEach(messages, 
            message =>
            {
                if (IsEnumerable(message))
                    foreach (var item in message as IEnumerable<object>)
                        PresentData(item);
                else
                    System.Console.WriteLine(message);
            });
            
        static bool IsEnumerable(object obj) => typeof(IEnumerable).IsAssignableFrom(obj?.GetType())
            && !typeof(String).Equals(obj?.GetType());
    }
}
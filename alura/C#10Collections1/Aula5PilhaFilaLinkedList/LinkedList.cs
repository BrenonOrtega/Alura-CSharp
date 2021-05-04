using System.Collections.Generic;
using System.Linq;
using System;

namespace Aula5PilhaFilaLinkedList
{
    public class AulaLinkedList{
        static int numChamadas;
        static LinkedList<string> linkedList = new();
        public static void run(){
            System.Console.WriteLine("LinkedLists - Listas Ligadas");
            var d1 = linkedList.AddFirst("sexta-feira");
            printLL();

            var d2 = linkedList.AddFirst("Domingo");
            printLL();

            var d3 =linkedList.AddBefore(d1, "terça-Feira");
            printLL();

            printLL(d1.List);

            var d4 = linkedList.AddLast("Sabado");
            printLL();

            var d5 = linkedList.AddAfter(d2, "segunda-feira");
            printLL();

            var d6 = linkedList.AddBefore(d1, "Quinta-Feira");
            printLL();

            var d7 = linkedList.AddAfter(d3, "Quarta-Feira");
            printLL();
            
            System.Console.WriteLine(d4.Previous.Previous.Next.Previous.Value);
        }

        static void printLL(LinkedList<string> list=null) {
            list = list ?? linkedList;
            System.Console.WriteLine("Chamada Número:" + numChamadas++);
            foreach (var item in list)  
            {
                System.Console.WriteLine(item);
            }
            System.Console.WriteLine();
        }
    }
}
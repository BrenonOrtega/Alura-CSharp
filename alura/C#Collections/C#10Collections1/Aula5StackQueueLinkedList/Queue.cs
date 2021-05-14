using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Aula5StackQueueLinkedList
{
    public class AulaQueue
    {
        static Queue<string> toll = new();
        public static void run()
        {
            enqueue("Celtinha");
            enqueue("Ford ka - Bo NE CA");
            enqueue("Veronão relíquia");
            enqueue("BMW 320i");
            dequeue();
            dequeue();
            peekPayingCar();
            dequeue();
            dequeue();
            dequeue();
            peekPayingCar();

        }

        static void enqueue(string car){
            toll.Enqueue(car);
            System.Console.WriteLine($"Entered the queue: {car}");
            printQueue();
        }

        static void dequeue(){
            if (toll.Any()){
                var car = toll.Dequeue();
                System.Console.WriteLine($"Exited the queue: {car}");     
            }
            printQueue();
        }

        static void peekPayingCar()
        {
            if ( toll.Any() ){
                var car = toll.Peek();
                System.Console.WriteLine($"Car Paying the toll fee: {car}");
            }
            printQueue();
        }


        static void printQueue(){
            System.Console.WriteLine("Cars at the toll");
            foreach (var item in toll)
            {
                System.Console.WriteLine(item);
            }
            System.Console.WriteLine();
        }
    }
}
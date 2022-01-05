using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using StackExchange.Redis;

namespace RedisPubAndSub
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //await SubscribingAndPublishingToRedisAsync();

        }

        private static async Task SubscribingAndPublishingToRedisAsync()
        {
            var redis = ConnectionMultiplexer.Connect("localhost:6379");
            var playmobilQueue = "playmobil-status-consult";

            var sub = redis.GetSubscriber();

            await sub.SubscribeAsync(playmobilQueue, (channel, value) =>
            {
                var paybillId = (string)value;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Received message to the subscribed playmobil queue:{0}.", playmobilQueue);
                Console.WriteLine("Message ID: {0}", paybillId);
                Console.ForegroundColor = ConsoleColor.White;
                System.Console.WriteLine();
            });

            var pub = redis.GetSubscriber();

            var tasks = new Task[10];

            for (int i = 0; i < 10; i++)
            {
                tasks[i] = Task.Run(() =>
                {
                    PublishAndLog(playmobilQueue, pub);
                });
            }

            await Task.WhenAll(tasks);

            while (true)
            {
                await Task.Delay(500);
                PublishAndLog(playmobilQueue, pub);
            }
        }

        private static void PublishAndLog(string playmobilQueue, ISubscriber pub)
        {
            var publishedMessageId = Guid.NewGuid().ToString();
            pub.PublishAsync(playmobilQueue, publishedMessageId);
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine("Publishing message with Id {0}\n", publishedMessageId);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
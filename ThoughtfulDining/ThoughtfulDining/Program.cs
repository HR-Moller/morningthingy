

using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;

namespace ThoughtfulDining
{
    public class Program
    {
        static bool proceed = true;

        public static void Main(string[] args)
        {
            List<Chopstick> chopsticks = new List<Chopstick>();

            Chopstick cs1 = new(1);
            chopsticks.Add(cs1);
            Chopstick cs2 = new(2);
            chopsticks.Add(cs2);
            Chopstick cs3 = new(3);
            chopsticks.Add(cs3);
            Chopstick cs4 = new(4);
            chopsticks.Add(cs4);
            Chopstick cs5 = new(5);
            chopsticks.Add(cs5);

            List<Philosopher> philosophers = new List<Philosopher>();

            Philosopher p1 = new("Archimedes", cs1, cs2);
            philosophers.Add(p1);
            Philosopher p2 = new("Aristotle", cs2, cs3);
            philosophers.Add(p2);
            Philosopher p3 = new("Confucius", cs3, cs4);
            philosophers.Add(p3);
            Philosopher p4 = new("Descartes", cs4, cs5);
            philosophers.Add(p4);
            Philosopher p5 = new("Kant", cs5, cs1);
            philosophers.Add(p5);

            Thread t1 = new(() => p1.Dine());
            Thread t2 = new(() => p2.Dine());
            Thread t3 = new(() => p3.Dine());
            Thread t4 = new(() => p4.Dine());
            Thread t5 = new(() => p5.Dine());
            t1.Start();
            Thread.Sleep(10);
            t2.Start();
            Thread.Sleep(10);
            t3.Start();
            Thread.Sleep(10);
            t4.Start();
            Thread.Sleep(10);
            t5.Start();
            Thread.Sleep(10);

            do
            {
                if (Console.ReadKey().Key == ConsoleKey.Escape) 
                {
                    proceed = false;

                    foreach (var p in philosophers)
                    {
                        p.Proceed = false;
                    }

                    Console.WriteLine("Waiting for the last to finish their meal");

                    int freeChopsticks = 0;

                    Thread.Sleep(8000);

                    do
                    {
                        freeChopsticks = 0;
                        foreach (var c in chopsticks)
                        {
                            if (c.IsFree)
                            {
                                freeChopsticks++;
                            }
                        }
                    }
                    while (freeChopsticks < 5);

                    

                    foreach (var p in philosophers)
                    {
                        Console.WriteLine($"{p.Name} has consumed a toal of {p.Meals} meals");
                    }
                }
            }
            while (proceed);
        }
    }
}

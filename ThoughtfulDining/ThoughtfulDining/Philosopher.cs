using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThoughtfulDining
{
    public class Philosopher
    {
        public string? Name { get; set; }
        public int Meals { get; set; }
        public bool Proceed { get; set; }

        public Chopstick Left { get; set; }
        public Chopstick Right { get; set; }

        public Philosopher (string name, Chopstick left, Chopstick right)
        {
            Name = name;
            Left = left;
            Right = right;
            Proceed = true;
        }

        public void Dine()
        {
            do
            {
                if (TryEat())
                {
                    Meals++;
                    Console.WriteLine($"{Name} is done eating");
                    Console.WriteLine($"{Name} is now sleeping");
                    //Console.WriteLine($"{Name} has consumed a total of {Meals} meals");
                    Sleep();
                    Console.WriteLine($"{Name} is now awake and trying to eat");
                }
            }
            while (Proceed);
            Console.WriteLine($"{Name} has finished eating");
        }

        public bool TryEat()
        {
            Monitor.Enter(this);
            if (Left.IsFree && Right.IsFree)
            {
                //Monitor.Enter(Right);
                Left.IsFree = false;
                Right.IsFree = false;
                Console.WriteLine($"{Name} is now eating");
                Thread.Sleep(5000);
                Left.IsFree = true;
                Right.IsFree = true;
                Monitor.Exit(this);
                //Monitor.Exit(Right);

                return true;
            }

            return false;
        }

        public void Sleep()
        {
            Thread.Sleep(3000);
        }
    }
}

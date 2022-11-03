namespace PhilosophersStone
{
    public class Program
    {
        public static object cs1 = new object();
        public static object cs2 = new object();
        public static object cs3 = new object();
        public static object cs4 = new object();
        public static object cs5 = new object();

        public static Thread phil1 = new Thread(new ThreadStart(Eat));
        public static Thread phil2 = new Thread(new ThreadStart(Eat));
        public static Thread phil3 = new Thread(new ThreadStart(Eat));
        public static Thread phil4 = new Thread(new ThreadStart(Eat));
        public static Thread phil5 = new Thread(new ThreadStart(Eat));

        public static void Main(string[] args)
        {
            phil1.Name = "phil1";
            phil2.Name = "phil2";
            phil3.Name = "phil3";
            phil4.Name = "phil4";
            phil5.Name = "phil5";


            phil1.Start();
            phil2.Start();
            phil3.Start();
            phil4.Start();
            phil5.Start();

            phil1.Join();
            phil2.Join();
            phil3.Join();
            phil4.Join();
            phil5.Join();
        }

        public static void Eat()
        {
           for(int i = 0; i < 1; i++)
            {
                if(Thread.CurrentThread.Name == "phil1")
                {
                    lock (cs5)
                    {
                        lock (cs1)
                        {
                            Console.WriteLine("phil1 is eating");
                        }
                    }
                }
                if (Thread.CurrentThread.Name == "phil2")
                {
                    lock (cs1)
                    {
                        lock (cs2)
                        {
                            Console.WriteLine("phil2 is eating");
                        }
                    }
                }
                if (Thread.CurrentThread.Name == "phil3")
                {
                    lock (cs2)
                    {
                        lock (cs3)
                        {
                            Console.WriteLine("phil3 is eating");
                        }
                    }
                }
                if (Thread.CurrentThread.Name == "phil4")
                {
                    lock (cs3)
                    {
                        lock (cs4)
                        {
                            Console.WriteLine("phil4 is eating");
                        }
                    }
                }
                if (Thread.CurrentThread.Name == "phil5")
                {
                    lock (cs4)
                    {
                        lock (cs5)
                        {
                            Console.WriteLine("phil5 is eating");
                        }
                    }
                }
                Console.WriteLine(Thread.CurrentThread.Name + " is sleeping");
                Thread.Sleep(100);
            }

        }
    }
}

using System.Formats.Asn1;
using System.Net.WebSockets;

public class Program
{
    public static List<uint> Primes = new List<uint>();
    public static List<uint> Factors = new List<uint>();
    public static bool proceed = true;


    public static void Main(string[] args)
    {
        Primes.Add(2);
        Thread PrimeGenerator = new Thread(start: () => GetPrimes());
        Thread PrimeFactorHunter = new Thread(start: () => GetPrimeFactor());

        
        PrimeGenerator.Start();
        PrimeFactorHunter.Start();
    }


    public static void GetPrimeFactor()
    {
        
        do
        {
            Console.WriteLine("Insert number to get prime factors:");
            var input = Console.ReadLine();
            List<uint> CopyOfPrimes;
            lock (Primes)
            {
                CopyOfPrimes = Primes;
            }

            lock (CopyOfPrimes)
            {
                if (uint.TryParse(input, out uint i) && !CopyOfPrimes.Contains(i) && i != 1)
                {

                    foreach (var p in CopyOfPrimes)
                    {
                        while (i % p == 0 && i >= p)
                        {
                            Factors.Add(p);
                            i = (i / p);
                        }
                    }

                    foreach (var f in Factors)
                    {
                        if (f == Factors.Last())
                        {
                            Console.WriteLine(f);
                        }
                        else Console.Write($"{f} * ");
                    }
                    Factors.Clear();
                }

                else
                {
                    if (CopyOfPrimes.Contains(i) || i == 1)
                    {
                        Console.WriteLine($"{i} is a prime");
                    }

                    else if (input.Equals("q"))
                    {
                        proceed = false;
                        Console.WriteLine(CopyOfPrimes.Count);
                        Console.WriteLine(CopyOfPrimes.Last());
                    }

                    else
                    {
                        Console.WriteLine("Not a valid number");
                    }
                }

                
            }

            

        } while (proceed);
    }

    public static void GetPrimes()
    {
        uint num = 3;
        do
        {
            lock (Primes)
            {
                if (IsPrime(num)) Primes.Add(num);
            }
            num += 2;

        } while (proceed);
    }
    
    public static bool IsPrime(uint num)
    {
        uint[] basePrimes = { 1, 2, 3, 5, 7 };
        if (num == 0) return false;
        if (basePrimes.Contains(num)) return true;
        if (num%2 == 0) return false;

        var boundary = (int)Math.Floor(Math.Sqrt(num));

        for (uint i = 3; i <= boundary; i += 2)
        {
            if (num % i == 0)
                return false;
        }

        return true;
    }
}

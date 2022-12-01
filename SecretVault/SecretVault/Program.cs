using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SecretVault
{
    public class Program
    {
        public static Vault myVault = new Vault(4321, "HEJ");
        public static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Brute();
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed.TotalSeconds);
            
        }

        public static void Brute()
        {
            string encMes = myVault.EncryptedMessage;
            string decMes = "";

            while (!myVault.IsCorrect(decMes))
            {

            }
        }
    }
}

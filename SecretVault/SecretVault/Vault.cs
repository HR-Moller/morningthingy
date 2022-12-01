using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretVault
{
    public class Vault
    {
        private const int MODULUS = 33;
        private const int MULTIPLIER = 378;
        private const int INCREMENT = 2310;

        private string Message { get; set; }
        private int Seed { get; set; }
        public string EncryptedMessage { get; private set; }

        public Vault(int seed, string message)
        {
            this.Message = message;
            this.Seed = seed;
            this.EncryptedMessage = EncryptString(this.Message);
        }

        public bool IsCorrect(string guess)
        {
            return guess.Equals(Message);
        }

        private string EncryptString(string s)
        {
            string result = "";

            for (int i = 0; i < s.Length; i++)
            {
                result += ScrambleChar(s[i], GetNextPseudoRandomNumber());
            }

            return result;
        }

        private char ScrambleChar(char c, int shiftValue)
        {
            //returns the input value (c), shifted shiftValue times
            //if c = ‘B’ and shiftvalue = 3, ‘E’ is returned
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}";
            List<char> chars = alphabet.ToList();
            int index = chars.FindIndex(cha => cha == c);
            if(index + shiftValue > chars.Count)
            {
                index = (index + shiftValue) - chars.Count;
            }
            else
            {
                index = index + shiftValue;
            }
            return chars[index];
        }

        private int GetNextPseudoRandomNumber()
        {
            //Uses the current seed value and the Linear Congruential Generator formula 
            //to calculate the next pseudo-random number
            //Also sets the Seed variable to this result as the new seed-value
            //to be used in the next calculation.
            Seed = (MULTIPLIER * Seed + INCREMENT) % MODULUS;
            return Seed;
        }
    }
}


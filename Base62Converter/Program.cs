using System;
using System.Collections.Generic;
using System.Linq;

namespace Base62Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            string alphabet = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            List<string> alphabetList = alphabet.Select(character => character.ToString()).ToList();


            Console.WriteLine("Enter number to encode in Base62");
            long x = Int64.Parse(Console.ReadLine());

            List<long> columns = new List<long> {1};

            while (columns.Last() + Math.Pow(62, columns.Count) <= x)
            {
                columns.Add((long) Math.Pow(62, columns.Count));
            }

            List<string> base62 = new List<string>();

            for (int i = columns.Count- 1; i >= 0; i--)
            {
                base62.Add(alphabetList[(int) (x / columns[i])]);
                x -= x / columns[i] * columns[i];
                Console.WriteLine(base62.Last());
            }
        }
    }
}

using System;
using System.Collections.Generic;

namespace Yield
{
    class Program
    {
        static Random ran = new Random();

        static IEnumerable<int> GetRandomNumbers(int count)
        {
            List<int> ints = new List<int>();
            for (int i = 0; i < count; i++)
                ints.Add(ran.Next()); 
            return ints;
        }

        static void Main(string[] args)
        {
            foreach (var item in GetRandomNumbers(10))
                Console.WriteLine(item);
        }
    }
}

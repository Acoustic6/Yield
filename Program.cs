using System;
using System.Collections.Generic;

namespace Yield
{
    class Program
    {
        static Random ran = new Random();

        static IEnumerable<int> GetRandomNumbers(int count)
        {
            for (int i = 0; i < count; i++)
                yield return ran.Next();
        }

        static void Main(string[] args)
        {
            foreach (var item in GetRandomNumbers(10))
                Console.WriteLine(item);
        }
    }
}

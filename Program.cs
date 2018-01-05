using System;
using System.Collections;
using System.Collections.Generic;

namespace Yield
{
    class Program
    {
        static Random ran = new Random();

        static IEnumerable<int> GetRandomNumbers(int count)
        {
            GetRandomNumbersClass grn = new GetRandomNumbersClass(count);
            return grn;
        }

        static void Main(string[] args)
        {
            IEnumerable<int> list = new GetRandomNumbersClass(10);
            IEnumerator<int> rator = list.GetEnumerator();
            try
            {
                while(rator.MoveNext())
                    Console.WriteLine(rator.Current);                    
            }
            finally
            {
                rator.Dispose();
            }
        }

        class GetRandomNumbersClass : IEnumerable<int>, IEnumerator<int>
        {
            public GetRandomNumbersClass(int count)
            {
                this.count = count;
            }

            int count;
            int current;
            int state;
            int i;

            public bool MoveNext()
            {
                switch (state)
                {
                    case 0:
                        i = 0;
                        goto case 1;
                    case 1:
                        state = 1;
                        if (i >= count)
                            return false;
                        current = ran.Next();
                        state = 2;
                        return true;
                    case 2:
                        i++;
                        goto case 1;
                }
                return false;
            }

            public IEnumerator<int> GetEnumerator()
            {
                return this;
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
            
            public int Current 
            {
                get { return current; }    
            }

            object IEnumerator.Current 
            {
                get { return Current; }
            }

            public void Dispose()
            {
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace n的质数
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CountPrimes(100));
        }
        public static int CountPrimes(int n)
        {

            if (n <= 1)
                return 0;

            //用于存储是否为 质数的 标识
            var temp = new bool[n];
            var count = 0;
            for (int i = 2; i < n; i++)
            {
                if (!temp[i])
                {
                    count++;
                    //为质数，那么把它前面是此质数的倍数的位置标志为 非质数
                    for (int j = 0; j * i < n; j++)
                    {
                        temp[j * i] = true;
                    }
                }
            }

            return count;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 钢条切割问题__递归实现
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 5;//要切割 售卖的钢条长度
            int[] p = { 0, 1, 5, 8, 9, 10, 17, 17, 20, 24, 30 };

            for (int i = 0; i <p.Length; i++)
            {
               Console.WriteLine(  UpDown(i, p));
            }
            Console.WriteLine();
        }

        public static int UpDown(int n, int[] p) //求长度为n 的 最大收益
        {
            if (n==0)
            { 
                return 0;
            }

            int maxP = 0;
            for (int i = 1; i < n+1; i++)
            {
                int temp = p[i] + UpDown(n-i, p);
                if (temp>maxP)
                {
                    maxP = temp;
                }
            }

            return maxP;
        }

        public static int UpDown2(int n, int[] p,int[]result)
        {
            if (n == 0) return 0;
            if (result[n]!=0)
            {
                return result[n];
            }
            int MaxPrice=0;
            for (int i = 1; i <=n; i++)
            {
                int temp = p[i] + UpDown2(n - i, p,result);
                if (temp>MaxPrice)
                {
                    MaxPrice = temp;
                }
            }
            result[n] = MaxPrice;
            return MaxPrice;
        }
    }
}

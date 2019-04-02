using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3的幂
{
    class Program
    {
        static void Main(string[] args)
        {
       
        }

        /// <summary>
        ///  递归 求 n 是否是 m的 幂次方   时间复杂度 On
        /// </summary>
        /// <param name="n">要求的 数</param>
        /// <param name="m">幂</param>
        /// <returns></returns>
        public static bool TestPower(int n,int m)
        {
            if (1 == n)
                return true;
            if (n % m != 0) return false;

            if (n==3)             
                return true;

            if (n == 0) return false;
            return IsPowerOfThree(n/m);

        }

        public static bool IsPowerOfThree(int n)
        {

            //------- m1
            if (1 == n) return true;
            if (n % 3 != 0) return false;

            if (n == 3)
                return true;
            if (n == 0 || n == 1) return false;

            return IsPowerOfThree(n / 3);

            // ------ M2   非递归 利用Math函数
            //string  t1=  Math.Log(n, 3).ToString()  ;
            //  int t2;
            // int.TryParse(t1, out t2);
            //return t1 == t2.ToString();

            // ------ M3
            //if(n<=0) return false;
            //string  t1=  Math.Log(n, 3).ToString();
            //return !t1.Contains(".");

        }
    }
}

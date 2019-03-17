using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 数论欧几里德算法10_14
{
    class Program
    {
        public static int gcd(int a,int b)
        {//对任意非负整数a和任意正整数b，gcd(a , b) = gcd(b , a%b)
            return b == 0 ? a : gcd(b, a % b);
        }
        int Icm(int a, int b)
        {
            return a / gcd(a, b) * b;
        }
      
     
    }
}

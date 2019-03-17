using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 钢铁切割问题_自底向上法
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] result = new int[11];
            int[] p = { 0, 1, 5, 8, 9, 10, 17, 17, 20, 24, 30 };
            
            
        }

        public static int BottonUp(int n,int[] p,int[] result)
        {
            for (int i = 1; i <n+1; i++)//i 为长度
            {
                //下面 取得 钢条长度为i的时候的最大收益
                int tempMaxprice = -1;
                for (int j = 1; j <=i; j++) //1 到i 可能的情况  比如 长度为4 就是 可以切成  1 2 3 4， 3就是 123
                {
                   //i 为1 的时候  result就保存了第一个值， 2的时候 需要计算 1 和2  1就不用再去计算了。
                    int maxPrice = p[j] + result[ i - j]; //i-j 的情况就是，比如i是4   i-j=3 i-j=2 i-j=1 i-j=0  里面保存的就是 前四个的最大价格

                    if (maxPrice>tempMaxprice)
                    {
                        tempMaxprice = maxPrice;
                    }
                }
                //计算i前面的 最大价格后,记录下i的值
                result[i] = tempMaxprice;
            }
            return result[n];
        }
      

    }
}

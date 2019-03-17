using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 贪心算法__钱币找零问题
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] Count = { 3, 0, 2, 1, 0, 3, 5 };

            int[] Value = { 1, 2, 5, 10, 20, 50, 100 };
            //0 0    2  1   0   0    3 
            int[] result = Change(323, Count, Value);
            foreach (var item in result)
            {
                Console.Write(item + " ");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="k">要找的钱 </param>
        /// <param name="count">有的纸币的个数</param>
        /// <param name="amount">所有面值的纸币表 </param>
        /// <returns></returns>
        static int[] Change(int k, int[] count, int[] amount)
        {
            if (k == 0) { return new int[amount.Length + 1]; }

            int[] list = new int[amount.Length + 1];

            int index = amount.Length - 1;//下标和编号差1
            int total = 0;
            while (true)
            {
                // 钱小于0或者 下标超出  跳出
                if (index < 0 || k <= 0)
                {
                    break;
                }
                //如果 要找的钱超过 面值的个数*面值
                if (k > count[index] * amount[index])
                {
                    //超出了 因此 取 里面最大
                    list[index] = count[index];  //加进 结果 列表
                    k -= count[index] * amount[index];

                }
                else
                {
                    //没超出 取相对应的值 （要找的钱除以面值）  
                    list[index] = k / amount[index];
                    k -= list[index] * amount[index];
                }
                index--;
            }

            //保存 剩下的钱 最后一位

            list[amount.Length] = k;
            return list;
        }
    }
}

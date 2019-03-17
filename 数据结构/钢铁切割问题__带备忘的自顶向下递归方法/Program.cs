  using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 钢铁切割问题__带备忘的自顶向下递归方法
{
    class Program
    {
        static void Main(string[] args)
        { 
            int[] result = new int[11];
            int[] p = { 0, 1, 5, 8, 9, 10, 17, 17, 20, 24, 30 };

            for (int i = 0; i <p.Length; i++)
            {
               Console.WriteLine(  UpDown(i, p, result));
            }
        }


        /// <summary>
        /// 带 备忘的 自顶向下递归方法
        /// </summary>
        /// <param name="n"></param>
        /// <param name="p"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        static int UpDown(int n,int[] p,int[] result)
        {
            if (n==0){return 0;}
       
            int max = 0;
            if (result[n]!=0){return result[n];}
          
            for (int i = 1; i <=n ; i++)//i<n+1  最大值 就是n
            {   // 长度为n的 最大 收益
                int temp= p[i]+UpDown(n-i,p,result);

                if (temp>max){ max = temp;}

            }
            result[n] = max; // 保存  下n的 结果
            return max;
        }



    }
}

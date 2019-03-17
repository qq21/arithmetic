using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01背包问题__穷举法
{
    class Program
    {
        static void Main(string[] args)
        {
            int m;
            int[] w={0,3,4,5 };
            int[] price = { 0, 4, 5, 6 };


            //Console.WriteLine( Exhausivity2(10,3, w, price));
            //Console.WriteLine(Exhausivity2(3, 3, w, price));
            //Console.WriteLine(Exhausivity2(4, 3, w, price));
            //Console.WriteLine(Exhausivity2(5, 3, w, price));
            //Console.WriteLine(Exhausivity2(7, 3, w, price));

            //Console.WriteLine(BottonUp(10, 3, w, price));
            //Console.WriteLine(BottonUp(3, 3, w, price));
            //Console.WriteLine(BottonUp(4, 3, w, price));
            //Console.WriteLine(BottonUp(5, 3, w, price));
            //Console.WriteLine(BottonUp(7, 3, w, price));
            Console.WriteLine(Exhausivity(10, price, w));
            Console.WriteLine(Exhausivity(3, price, w));
            Console.WriteLine(Exhausivity(4, price, w));
            Console.WriteLine(Exhausivity(5, price, w));
            Console.WriteLine(Exhausivity(7, price, w));

        }

        //暴力破解
        public static  int Exhausivity(int m, int[] p, int[] w)
        {
            int i = w.Length-1
                ;//物品的个数
            int maxPrice=0;
            for (int j = 0; j < Math.Pow(2, m); j++)//取得所有情况   总共 方案 有2 M次方  但是 要排除掉 里面全是00000（不包含1）的情况
            {
                //把j 装换下2进制   有 i位
                int wei = 0;
                int pri = 0;
                for (int number = 1; number <=i; number++)// 遍历 所有物品
                {
                    int result = Get2(j, number);//取得 number位 上的二进制值 0 和1
                   
                    if (result ==1)  //1 就加进去  0 表示 不选择 不加
                    {
                        wei += w[number];
                        pri += p[number];
                    }
                }
                if (wei<=m && pri >maxPrice )
                {
                    maxPrice = pri;
                }
            }
            return maxPrice;
        }
        //取得j 上的 number位的二进制值 是1 还是0
        public static int Get2(int j,int number )
        {
            int A = j;
            int b = (int)Math.Pow(2, number - 1);
            int res = A & b;
            if (res==0)
            {
                return 0;
            }
            return 1;
        }
        //自顶向上 法
        /// <summary>
        /// i 放进背包的物品个数
        /// </summary>
        /// <param name="m">背包总容量</param>
        /// <param name="w">物品的重量数组</param>
        /// <param name="p">价值数组</param>
        /// <returns></returns>
        public static int Exhausivity( int m,int i, int[] w,int[] p)
        {
            if (i==0||m==0)
            {
                return 0;
            }
            //如果w[i] 大于M  如果  w[i]的 重量 大于当前背包 容量
            if (w[i]>m)
            {
               return  Exhausivity(m,i-1,w,p);
            }
            else
            {
                int maxValue = Exhausivity(m-w[i],i-1,w,p) + p[i];

                int maxValue2 = Exhausivity(m,i-1,w,p);
 
                return Math.Max(maxValue, maxValue2);
            }
        }


        public static int[,] result = new int[11, 4];//第一个 代表的是M 第二个代表是i;
        /// <summary>
        /// 带备忘的
        /// </summary>
        public static int Exhausivity2(int m, int i, int[] w,int [] p)
        {
            if (m==0||i==0)
            {
                return 0;
            }

            if (result[m,i]!=0) //改结果存在的话
            {

                return result[m, i];
            }

            if (w[i]>m) //放进的物品 大于背包容量
            {
                result[m,i]= Exhausivity2(m, i - 1, w, p); 
                return  Exhausivity2(m, i - 1, w, p);
            }
            else
            {

                int max1 = Exhausivity2(m, i - 1, w, p);
                int max2 = Exhausivity2(m - w[i], i - 1, w, p);

                result[m, i] = Math.Max(max1, max2);
                return Math.Max(max1, max2);
            }

        }


        //自底向上法
        public static int BottonUp(int m,int i,int[] w,int [] p)
        {
            if (result[m,i]!=0)
            {
                return result[m, i];
            }
            for (int tempM = 1; tempM <=m; tempM++)
            {
                for (int tempI = 1; tempI <=i; tempI++)
                {
                    if (result[tempM,tempI]!=0){continue;}
                    if (w[tempI]>tempM)
                    {
                        result[tempM, tempI] = result[tempM, tempI - 1];
                    }
                    else
                    {
                        int maxValue1 = result[tempM - w[tempI], tempI - 1]+p[tempI];
                        int maxValue2 = result[tempM, tempI - 1];// 不放入
                         result[tempM,tempI]=   Math.Max(maxValue1, maxValue2);
                    }
                }
            }
            return result[m, i];
        }
        //自底向上法
        public static int ButtonUp(int m, int i,int[] w ,int[] p )
        {
            if (result[m,i]!=0)
            {
                return result[m, i];
            }
            for (int tempM = 1; tempM <=m; tempM++)
            {
                for (int tempI = 1; tempI <=i; tempI++)
                {
                    if (result[tempM,tempI]!=0)
                    {
                        continue;
                    }

                    if (w[tempI]>tempM)
                    {
                        result[tempM, tempI] = result[tempM, tempI - 1];
                    }
                    else
                    {
                         int max1 =  result[tempM, tempI - 1];
                        int max2 = result[tempM - w[tempI], tempI - 1] + p[tempI];

                        result[tempM, tempI] = Math.Max(max1, max2);
                    }
                }
            }
            return result[m, i];
        }
    }
}

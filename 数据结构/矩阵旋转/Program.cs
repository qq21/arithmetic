using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 矩阵旋转
{
    class Program
    {
        static void Main(string[] args)
        {
             int[,] mart = new int[,]{ {1,2,3,4}, { 5, 6, 7, 8 }, {10, 11, 12, 13 }, {15, 16, 17, 18 }, };
            int count= (int) Math.Sqrt(mart.Length);

            for (int i = 0; i < count; i++)//列
            {
                for (int j = 0; j < count; j++)//行
                {
                    Console.Write(mart[i, j] + " ");

                }
                Console.WriteLine();
            }
            Console.WriteLine("-------------");
            for (int i = 0; i < count; i++)
            {//mart[count - i - 1, count - j - 1]  下 左到右<<
                for (int j= i; j <count-1-i; j++)
                {
                    //[count - j - 1, i] 

                  
                    //marr[i,j] 上右到左  >>
                    int temp = mart[i, j]; //挖第一列的坑， 让左边上来
                    mart[i, j] = mart[count - j - 1, i];//列   行 交换  再挖坑  左边上去

                    mart[count - j - 1, i] = mart[count - i - 1, count - j - 1];//
                    mart[count - i - 1, count - j - 1] = mart[j, count - i - 1];
                    mart[j, count - i - 1] = temp;//最后填它

                    //[j, count - i - 1] 右从上到下 Down;
                    // mart[j, count - i - 1] = temp;
                    ////列交换
                    //mart[count - j - 1, i] = mart[j, count - i - 1];

                }
                Console.WriteLine();
            }
            Console.WriteLine("-------------");
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    Console.Write(mart[i, j] + " ");

                }
                Console.WriteLine();
            }
            Console.WriteLine("-------------");
        }
    }
}

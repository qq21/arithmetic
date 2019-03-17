using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 快速排序10_25
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] vs = { 10, 20, 30, 55, 44, 88, 11, 1, 8, 789, 54, 10, 4,10 };

            QuickSort(vs,0,vs.Length-1);

            foreach (int item in  vs)
            {
                Console.Write(item + " ");
            }
        }

        static void QuickSort(int[] data,int left,int right)
        {
            //排序 条件
            if (left<right)
            {
                int x = data[left];// 挖一个 坑
                int i = left;
                int j = right;
                //循环条件 遍历
                while (i<j)
                {
                    //从后往前  挖一个比x小的坑  
                    while (i<j)
                    {
                        if (data[j]<=x) //大于=的放在左边
                        {
                            data[i] = data[j];//把这个数填到 左边
                            break;//找到后 跳出
                        }
                        else
                        {
                            j--;
                        }
                    }
                    //从 前 往后找一个 比x大的坑
                    while (i < j)
                    {
                        if (data[i]>x)
                        {
                            data[j] = data[i];//把这个坑的值 填到右边 （刚刚挖的坑）
                            break;//找到后跳出
                        }
                        else
                        {
                            i++;
                        }
                    }
                }
                //跳出循环  找到 了 中间位置， 把x填进这个坑
                data[i] = x;
                //继续对  左边 和右边进行排序
                QuickSort(data, left, i - 1);
                QuickSort(data, i + 1, right);
                
            }
        }
       
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 快速排序
{
    class Program
    {
        /// <summary>
        /// 快速排序
        /// </summary>
        /// <param name="array"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        public static void QuickSort(int[] array, int left, int right)
        {
            if (left < right)
            {

                int x = array[left];
                int i = left;
                int j = right;

                while (j > i)
                {
                    while (j > i)
                    {
                        if (array[j] <= x)//在右边 找到一个比x小的值 
                        {
                            array[i] = array[j];//放到左边
                            break;
                        }
                        else
                        {
                            j--;
                        }
                    }

                    while (j > i)
                    {
                        if (array[i] > x)//在左边找到一个 比x大的值，
                        {
                            array[j] = array[i];//放到 左边
                            break;
                        }
                        else
                        {
                            i++;
                        }
                    }
                }

                //跳出循环  i==j ; 把基准书 放在中间 
                array[i] = x; // 此时  left -i  -right

                QuickSort(array, left, i - 1);//从0-  left-1
                QuickSort(array, i + 1,right);
            }
        }

        ///
        public static void QuickSort_6_11(int[] array, int left,int right)
        {
            if (left<right)
            {
                int i = left;
                int j = right;
                //去一个中间数  挖坑
                int temp = array[i];
                while (i<j)
                {
                    while (i<j)
                    {
                        //从后往前 找 一个比它 小的坑
                        if (temp>array[j])
                        {
                            array[i] = array[j];
                            break;
                            
                            //找到了
                        }
                        else
                        {
                            j--; //继续找
                        }
                    }
                    
                    while (i<j)
                    {
                        //从前往后 挖一个比它大的坑
                        if (array[i]>temp)
                        {
                            array[j] = array[i];
                            //找到了
                            break;
                            ;
                        }
                        else
                        {
                            i++;
                        }
                    }
                }
                //至此。   i==j  找到了中间值 ，
                array[left] = temp; //中间值 插入中间
                //依次 对 左边，右边  进行递归
                QuickSort_6_11(array, left, i-1);
                QuickSort_6_11(array,i+1,right);


            }
        }
    }
}

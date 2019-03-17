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
                QuickSort(array, left - 1, array.Length);
            }
        }
    }
}

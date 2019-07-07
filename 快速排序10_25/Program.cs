using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace 快速排序10_25
{
    class Program
    {
        
        static void Main(string[] args)
        {
            
            //int[] vs = { 10, 20, 30, 55, 44, 88, 11, 1, 8, 789, 54, 10, 4,10 };

            //QuickSort(vs,0,vs.Length-1);
            
            //foreach (int item in  vs)
            //{
            //    Console.Write(item + " ");
            //}
/*

          
            int[] a, b=new int[100];
            a = new int[3] { 1, 2, 3 };
            int i = 61;



            b = new int[4] { 4, 5, 6, 7 };
            int[] c = b;

            //垃圾回收
            GCHandle gCHandle1 = GCHandle.Alloc(b, GCHandleType.Pinned);
            IntPtr intPtr1 = gCHandle1.AddrOfPinnedObject();           
            Console.WriteLine("地址:" + intPtr1.ToString());
            Console.WriteLine("地址" + GCHandle.Alloc(b[0], GCHandleType.Pinned).AddrOfPinnedObject().ToString());
            Console.WriteLine("地址" + GCHandle.Alloc(b[1], GCHandleType.Pinned).AddrOfPinnedObject().ToString());
*/

            //b = a;
            //Console.WriteLine();

            //GCHandle gCHandle = GCHandle.Alloc(b,GCHandleType.Pinned);
            //IntPtr intPtr = gCHandle.AddrOfPinnedObject();

            //Console.WriteLine("地址:"+intPtr.ToString());

            //Console.WriteLine(b.Length);

        }

        static void QuickSort(int l ,int r ,int[] nums)
        {
            if (l<r)
            {
                int i = l; //左边
                int j = r;//右边
                int temp = nums[i]; //中间值  挖 一个坑 去 后面 比较

                while (i<j)
                {

                    while (i < j)
                    {

                        //从 右边找 比它 小的  放到左边
                        if (temp > nums[j])
                        {
                            //找到了
                            nums[i] = nums[j];
                            break;
                        }
                        else
                        {
                            j--;
                        }

                    }

                    while (i<j)
                    {

                        if (temp < nums[i])  //从左边开始找比它大的
                        {
                            //找到了
                            nums[j] = nums[i]; //放到 中间值的右边边
                            break;
                            
                        }
                        else
                        {
                            i++; //继续向前寻找
                        }
                         
                    }

                    //此时  i==j  中间值
                    nums[i] = temp;
                    QuickSort(l,i-1,nums);
                    QuickSort(i,r,nums);
                }
                 //找到了 中间值  此时 left==right
                   
            }
        }

        static void GetValue( ref int [] nums,int c)
        {
            nums = new int[10];
            c = 10;
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

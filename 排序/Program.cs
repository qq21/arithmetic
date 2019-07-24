using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace 排序
{

    class  Prgrame
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 5, 2, 7, 0, 8, 10,98,2,87,910,1,098,121,1,-121,09812,0872 };

            //BubleSort<int> bubleSort=new BubleSort<int>();
            //bubleSort.sort(nums);
            //Sort<int> sort=new SelectionSort<int>();
            //BubleSort<int> sort = new BubleSort<int>();
            //sort.BorderBubleSort(nums);

            //Sort<int> sort=new Shell<int>();
            //BubleSort<int> sort=new BubleSort<int>(); 

            //sort.CocktailSort(nums); //鸡尾酒排序 最优版 冒泡排序的升级版

            QuickSort<int> sort=new QuickSort<int>();



            sort.Sort(nums, 0, nums.Length - 1); 
            foreach (var num in nums)
            {
                Console.Write(num + " ");
            }

           

        }       
    }

    public abstract class Sort<T> where   T:IComparable<T>
    {
        public abstract void sort(T[] nums);

        /// <summary>
        /// 第一位比第二位小
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns></returns>
        protected bool less(T t1, T t2)
        {
            return t1.CompareTo(t2) < 0;
        }

        protected void Swap(int i,int j,T[] nums)
        {
            T temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }
    }

    /// <summary>
    /// 每次依次 从前往后  依次比较，直到把最大的数 冒泡到最后一位
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BubleSort<T>:Sort<T> where T : IComparable<T>
    {
        /// <inheritdoc />
        public override void sort(T[] nums)
        {
             
            for (int i = 0; i < nums.Length - 1; i++)
            {
                bool isNeed = false;
                for (int j = 1; j < nums.Length - i; j++)
                {
                    if (less(nums[j],nums[j-1]))
                    {
                        Swap(j,j-1,nums);                         
                        isNeed = true;
                    }
                }

                if (!isNeed)
                {
                    break;

                }
            }
        }

        /// <summary>
        /// 冒泡排序 优化版 ， 加外框,在每轮排序后，记录下来最后一次元素交换的位置，
        /// 该位置即为无序数组的边界， 往后就是有序数组了
        /// </summary>
        /// <param name="nums"></param>
        public void BorderBubleSort(T[] nums)
        {
            
            for (int i = 0; i < nums.Length - 1; i++)
            {
                bool isNeed = false;
                int border = nums.Length - 1;
                for (int j = 1; j <border; j++)
                {
                    if (less(nums[j], nums[j - 1]))
                    {
                        Swap(j, j - 1, nums);
                        isNeed = true;
                        border = j;
                    }
                }

                if (!isNeed)
                {
                    break;

                }
            }
        }

        /// <summary>
        /// 升级版 冒泡排序-鸡尾酒排序，  一前  一 后，
        /// </summary>
        /// <param name="nums"></param>
        public void CocktailSort(T[] nums)
        {
            for (int i = 0; i < nums.Length/2; i++)
            {
                bool isSort = false;
                int border = nums.Length - 1;
                for (int j = i; j <border; j++)//从 i
                {
                    if (less(nums[j],nums[j+1]))
                    {
                        Swap(j,j+1,nums);
                        isSort = true;
                        border = j;
                    }
                }

                if (!isSort)
                {
                    break;
                }

                isSort = false;
                border = nums.Length - 1;
                for (int j = border; j >i; j--)
                {
                    if (less(nums[j], nums[j - 1]))
                    {
                        Swap(j, j - 1, nums);
                        isSort = true;
                        border = j;
                    }
                }

                if (!isSort)
                {
                   break; 
                }
            }
        }
    }
    
    /// <summary>
    /// 从第i位开始到最后一位-1 ，拿出i 位 与第i位后面的元素依次进行比较，记录下最小索引， 找到最小索引 后，进行交换;
    /// 从数组中选择最小元素，将它与数组的第一个元素交换位置。再从数组剩下的元素中选择出最小的元素，将它与数组的第二个元素交换位置。不断进行这样的操作，直到将整个数组排序。
    /// 选择排序需要 ~N2/2 次比较和 ~N 次交换，它的运行时间与输入无关，这个特点使得它对一个已经排序的数组也需要这么多的比较和交换操作。
    /// </summary>
    /// <typeparam name="T"></typeparam>     
    public class SelectionSort<T> : Sort<T> where T : IComparable<T>
    {
        /// <inheritdoc />
        public override void sort(T[] nums)
        {
            for (int i = 0; i < nums.Length-1; i++)//最后一次已经交换完毕
            {
                int min = i; //保存最小下下标
                for (int j = i+1; j <nums.Length; j++)
                {
                    if (less(nums[j],nums[min]))
                    {
                        min = j;
                    }
                }
                if (min!=i)
                {
                 Swap(i,min,nums);   
                }
            }
        }
    }

    /// <summary>
    /// 大规模 排序会很慢
    /// 每次将当前元素插入到左侧已经排序好的数组中
    /// 使得插入之后左侧数组依然有序
    /// 如果已经部分有序，则插入次数较少
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class InsertSort<T> : Sort<T> where T : IComparable<T>
    {
        /// <inheritdoc />
        public override void sort(T[] nums)
        {
            for (int i = 1; i <nums.Length-1; i++)
            {
                for (int j = i; j >0&& less(nums[j],nums[j-1]) ; j--) //默认i之前的已经排序好，每次会把相邻的元素插入到 第i位
                {   //从i到0
                    //1-0 2-0，3-0 ... nums.length-0
                   Swap(j,j-1,nums);
                }
            }
        }
    }

    /// <summary>
    /// 希尔排序，在插入排序上添加了一个排序序列，每次都是3的倍数+1 ->N
    ///  加快速度  简单改进了插入排序，交换不相邻的元素以对数组 的局部进行排序，，并最终使用插入排序将局部有序的数组排序
    /// 算法思想：使数组中任意间隔为h的元素都是有序的，这样的数组被称为h有序数组。
    /// 一个h有序数组就是h个相互独立的有序数组编织在一起组成的一个数组；
    /// 进行排序时，如果h很大，我们就能将元素移动到很远的地方，为实现更小的h有序创造方便
    /// 更高效的原因是 权衡了子数组的规模和有序性
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Shell<T> : Sort<T> where T : IComparable<T>
    {
        /// <summary>
        /// / 算法思想：使数组中任意间隔为h的元素都是有序的，这样的数组被称为h有序数组。
        /// 一个h有序数组就是h个相互独立的有序数组编织在一起组成的一个数组；
        /// 进行排序时，如果h很大，我们就能将元素移动到很远的地方，为实现更小的h有序创造方便
        /// </summary>
        /// <param name="nums"></param>
        public override void sort(T[] nums)
        {
            int n = nums.Length;
            int h = 1;
            while (h>n/3)
            {
                h = h * 3 + 1;//1, 1*3+1 ,4*3+1  13*3+1......
            }

            while (h>1)
            {
                for (int i = h; i < n; i++)
                {
                    for (int j = i; j >=h &&less(nums[j],nums[j-h]) ; j-=h) //i j-h,j-2h ....
                    {   //只从 h开始， 一开始 相隔为n/3+1 的 子数组都是 有序数组 
                        Swap(j, j-h,nums);
                    }
                }

                h /= 3;
            }
        }
    }
    /// <summary>
    /// 算法思想：将数组分成两部分 分别排序，然后归并起来
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MergeSort<T> : Sort<T> where T : IComparable<T>
    {
        /// <inheritdoc />
        public override void sort(T[] nums)
        {
             
        }
    }


    /// <summary>
    /// 快速排序
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class QuickSort<T>:Sort<T> where T:IComparable<T>
    {
        /// <inheritdoc />
        public override void sort(T[] nums)
        {
             Sort(nums,0,nums.Length-1);
        }

        public void Sort(T[] nums ,int left,int right)
        {
            if (left<right)
            {
             
                int i = left, j = right;
                T x = nums[left]; 
 
            //以第一个数为基准数，从前往后 找比它大的放在它的右边，从后往前找比它小的放在左边
            //直到把数组分成左边都比  nums[x]小，右边都比nums[x]大 
            while (i<j)
            {
       
                   while (i<j)
                    {

                        if (x.CompareTo(nums[j])>=0)
                        {
                            nums[i] = nums[j];  
                            break;
                        }
                            j--;
                       Console.WriteLine(j);
                    }

                    while (i<j)
                    {
                        if (x.CompareTo(nums[i])<0)
                        {
                            nums[j] = nums[i];
                            break;
                        }                  
                            i++;
                   
                    }
              }
             
            //此时 i===j
            nums[i] = x;
            
            Sort(nums,left,i-1);
            Sort(nums,i+1,right);
          }
        }
    }
    
    
}

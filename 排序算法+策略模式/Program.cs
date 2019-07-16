using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 排序算法_策略模式
{
    class Program
    {
        static void Main(string[] args)
        {
        }

    }

    public interface ISort<T> 
    {
        void Sort(T[] nums);
       
    }

    public class BubuleSort<T> where T : struct,IComparable<T>,ISort<T>
    { 
        public void Sort(T[] nums)
        {
            for (int i = 0; i < nums.Length-1; i++)
            {
                bool flag = false;
                for (int j = nums.Length-1; j >i; j--) //0 1  1 2  2 3....  第一次 最大的会被冒泡到 最后一位上 
                { //依次于相邻的元素进行 比较，大就交换
                    if (nums[j].CompareTo(nums[j-1])<0)
                    {
                        T temp = nums[j];
                        nums[j] = nums[j -1];
                        nums[j - 1] = temp;
                        flag = true;
                    }
                }

                if (!flag)
                {
                     break;;
                }
            }
        }
    }

    public class SortContontex<T>
    {
        private ISort<T> sort;

        public void SetSortContext(ISort<T> sort)
        {
            this.sort = sort;
        }

        public void HandleContext(T[] nums)
        {
            sort.Sort(nums);
        }
    }

    public class InsertSort<T> where T : struct, IComparable<T>, ISort<T>
    {
        public void Sort(T[] nums)
        {
             
        }
    }
}

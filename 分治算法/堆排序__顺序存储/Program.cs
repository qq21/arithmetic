using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 堆排序__顺序存储
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] data = { 50, 10, 90, 30, 70, 40, 80, 60, 20 };

        }
        public void HeapSort(int[] data)
        {
            //从最小的子树，  构建成 大顶堆
            for (int i = data.Length/2; i >=1; i--) //挨个 把所有的 子树 变成 大顶堆
            {
                //把子节点 变成  大顶堆

            }
        }
    }
}

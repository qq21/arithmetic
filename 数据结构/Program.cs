using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 堆排序___顺序存储
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] data = { 50, 10, 90, 30, 70, 40, 80, 60, 20,80,400,10,30,2200,90 };

            HeapSort(data);
            foreach (var item in data)
            {
                Console.Write( item +" ");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// 堆排序   利用 堆（小顶堆或者大顶堆） 进行排序的方法 .
        ///  将排序的序列构造成一个 大顶堆，此时整个 序列的最大值就是 根节点。将它移走（跟堆的最后一个元素交换），此时末尾元素就是最大值
        ///  然后将剩余的 n-1 个序列 重新 构造成一个堆， 这样就会得到 n 个元素中的 最小值
        /// </summary>
        /// <param name="data"></param>
        public static void HeapSort(int[] data)  
        {
            for (int i = data.Length/2; i>=1; i--) // 遍历 这个数的 所有非叶节点，挨个把所有的字树，变成大顶堆;  data.length得到 叶子的父亲
            {
                HeapAdjust(i, data, data.Length);
            //把 二叉树 变成 大顶堆
            }
            //第一个 位置 和最后一个 位置进行 交换   编号和index相差1 
            for (int j = data.Length; j > 1; j--)    //剩余 的大 顶 堆是 j  到j-1s
            {   //把 编号1 和编号i 位置进行交换
                //1到(i-1)构造成大顶堆
                int temp1 = data[0];
                data[0] = data[j - 1];   //交换结束后，  第一个结点 树 不是 打顶 堆，要重新 构造
                data[j - 1] = temp1;
                //构建堆
                HeapAdjust(1, data, j - 1);
            }
        }

         /// <summary>
         /// 
         /// </summary>
         /// <param name="NumberToAdjust">要调整的编号</param>
         /// <param name="data">数据 数组 </param>
         /// <param name="MaxNumber">最大编号</param>
        public static void HeapAdjust2(int NumberToAdjust,int[] data,int MaxNumber)
        {
            int tempI = NumberToAdjust;
            int maxNumber = NumberToAdjust;

            while (true)
            {
                int leftChildNumber = 2 * tempI;
                int rightChildNumber = 2 * tempI + 1;

                //在左右 子节点 中  找到最大 的
                if (leftChildNumber< MaxNumber && data[leftChildNumber-1]>data[maxNumber-1])
                {
                    maxNumber = leftChildNumber;
                }
                if (rightChildNumber<MaxNumber && data[rightChildNumber-1]>data[maxNumber-1])
                {
                    maxNumber = rightChildNumber;
                }
                //找就 交换 数据 
                if (tempI!=maxNumber)
                {   //交换数据
                    int temp = data[tempI-1];
                    data[tempI - 1] = data[maxNumber - 1];
                    data[maxNumber - 1] = temp;
                    tempI = maxNumber;
                }
                else  // tempI 与 maxNumber 相等 跳出
                {
                    break;
                }
            }
        }


        public static void HeapSort2(int[] data)
        {
            //从最小的树上 开始遍历
            //完全二叉树里 左节点是2n 有节点是2n+1 因此 最小的父节点 就 是 最大编号/2  即length/2 
            //从最下 的子树开始 进行调整堆
            for (int i = data.Length/2; i>=1; i--)
            {
                HeapAdjust(i, data, data.Length);
            }
            // 把 第一个结点 和最后一个  结点 进行较换。 依次遍历   //最后一个不用交换 没有交换对象
            for (int i = data.Length; i>1; i--)
            {
                int temp = data[i - 1];
                data[i - 1] = data[0];
                data[0] = temp;
                //再次构建大顶 堆
                HeapAdjust2(1, data, i - 1);
            }
        }

        /// <summary>
        ///  堆 调整，构建 堆，在 孩子节点中寻找最大的,放在父节点上  依次遍历 直到构建成大顶堆，也就是当前节点和最大节点相等的时候
        /// </summary>
        /// <param name="numberToAdujust"> 调整的数字</param>
        /// <param name="data">数据 数组</param>
        /// <param name="maxNumber">最大编号</param>
        public static void HeapAdjust(int numberToAdujust,int[] data,int maxNumber)
        {
            int MaxNubmerNode = numberToAdujust; //保存 最大 节点的 编号;   
            int tempI = numberToAdujust;//记录是否需要交换
            while (true) //依次 与 子节点  判断
            {
                //节点i 变成  大顶堆
                int LeftChildNumber = tempI * 2; //左子 节点 
                int RightChildNumber = tempI * 2 + 1;//右子节点  ;
                
                //左子树
                //编号存在，  并且 数据 比 当前 结点大;  
                if (LeftChildNumber <= maxNumber && data[LeftChildNumber - 1] > data[MaxNubmerNode - 1]) // 节点 和 编号之间 相差 1;
                {
                    MaxNubmerNode = LeftChildNumber;  //更新这个结点的编号;
                }

                //同上  右子树
                if (RightChildNumber <= maxNumber && data[RightChildNumber - 1] > data[MaxNubmerNode - 1]) //得到 右 子节点;
                {
                    MaxNubmerNode = RightChildNumber;   //更新右 子节点的 编号
                }
                //找到一个 更大的了 发现比i 更大 的子节点 把向下移动 ,交换里面的数据  ，  编号比index多1 因此-1
                if (MaxNubmerNode != tempI)
                {
                    int temp = data[tempI - 1];
                    data[tempI - 1] = data[MaxNubmerNode - 1];
                    data[MaxNubmerNode - 1] = temp;
                    tempI = MaxNubmerNode;//再 跟新节点编号  用于 判断 下次 是否需要 交换
                }
                else
                {
                    break;
                }
            }
        }
        ///<summary>
        ///构建堆
        ///</summary>
        static void HeapAdjust(List<int> list, int parent, int length)
        {
            int temp = list[parent];

            int child = 2 * parent + 1;

            while (child < length)
            {
                if (child + 1 < length && list[child] < list[child + 1]) child++;

                if (temp >= list[child])
                    break;

                list[parent] = list[child];

                parent = child;

                child = 2 * parent + 1;
            }

            list[parent] = temp;
        }

        ///<summary>
        ///堆排序
        ///</summary>
        public static List<int> HeapSort(List<int> list, int top)
        {
            List<int> topNode = new List<int>();

            for (int i = list.Count / 2 - 1; i >= 0; i--)
            {
                HeapAdjust(list, i, list.Count);
            }

            for (int i = list.Count - 1; i >= list.Count - top; i--)
            {
                int temp = list[0];
                list[0] = list[i];
                list[i] = temp;

                topNode.Add(temp);

                HeapAdjust(list, 0, i);
            }
            return topNode;
        }

        public static void heapAdjust(int numberToAdjust,int[] data,int maxNumber)
        {
            int MaxNumberNode = numberToAdjust;
            int tempI = numberToAdjust;
            while (true)
            {
                int leftNode = 2 * tempI;
                int rightNode = 2 * tempI + 1;
                if (leftNode<=maxNumber && data[leftNode-1]>data[MaxNumberNode-1])
                {
                    MaxNumberNode = leftNode;
                }
                else if (rightNode<=maxNumber &&data[rightNode-1]>data[MaxNumberNode]-1)
                {
                    MaxNumberNode = rightNode;
                }

                if (tempI!=MaxNumberNode)
                {
                    int temp = data[tempI-1];
                    data[tempI-1] = data[MaxNumberNode-1];
                    data[MaxNumberNode-1] = temp;
                    tempI = MaxNumberNode;
                }
                else
                {
                    break;
                }
            }
        }

        void heapSort(int[] data)
        {
            for (int i = data.Length / 2; i >=1; i--)
            {
                heapAdjust(i, data, data.Length);
            }

            for (int i = data.Length; i >1; i--)
            {
                int temp = data[0];
                data[0] = data[i-1];
                data[i-1] = temp;
                heapAdjust(1, data,i-1);//从 1 到i -1 进行调整

            }
        }
    }
}

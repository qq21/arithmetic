using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 二叉树_顺序结构存储
{
    //如果一个结点是空的 话,那么这个结点所在的数组位置 设置为-1
    class BiTree<T>
    {
        private T[] data;//数据
        private int Count = 0;

        public BiTree(int capacity) //这个参数是当前二叉树的容量， count 表示当前存储了多少个数据
        {
            data = new T[capacity];
        }
        public bool Add(T item)
        {
            if (Count >= data.Length)
            {
                return false;
            }

            data[Count] = item;
            Count++;
            return true;
        }

        public void FirstTraverSal()
        {
            FirstTraverSal(0);
            
        }

      //使用递归方法来遍历  //传递一个索引   上 左 右 先输出前结点的数据 ，再依次遍历输出左结点 和右结点;
         private void FirstTraverSal(int index)
        {
            if (index >= Count)
            {
                return;
            }

            //得到要遍历的这个节点的编号    子节点的编号 从1 开始
            int number = index + 1;  //先 前 节点  然后 左节点  右节点
            Console.Write(data[index] + " "); //当前结点
            if (data[index].Equals(-1)) //-1是 表示 空节点
            {
                return;
            }
            //得到左子结点的编号
            int LeftNumber = number * 2;
            int RightNumber = number * 2 + 1;

            FirstTraverSal(LeftNumber - 1);  //编号 与 索引相差为1
            FirstTraverSal(RightNumber - 1);

        }

        /// <summary>
        ///  中序 遍历 二叉树   先遍历左 结点 ，再输出当前结点数据，最后遍历右结点
        /// </summary>
        public void MidTraverSal()
        {
            MidTraverSal(0);
        }
        private void MidTraverSal(int index)
        {
            if (index >= Count )
            {
                return;
            }
            int Number = index + 1;

            if (data[index].Equals(-1))
            {
                return;
            }

            int LeftNumber = Number * 2;
            int RightNumber = Number * 2 + 1;

            MidTraverSal(LeftNumber-1);  // 左 上 右
            //取得当前节点
            Console.Write(data[index]+" ");
            MidTraverSal(RightNumber-1);
        }

        public void LastTraverSal()
        {
            LastTraverSal(0);
        }
        /// <summary>
      /// 先 遍历输出左结点 再 遍历输出右结点 最后 输出 当前结点的数据   
      /// </summary>
      /// <param name="index"></param>
        private void LastTraverSal(int index)
      {
            //判断 是否越界
            if (index>=Count)
            {
                return;
            }
            //空节点  就返回
            if (data[index].Equals(-1))
            {
                return;
            }
            // 编号 与节点之间相差 一 
            int Number = index + 1;
            int LeftNumber = Number * 2;
            int RightNumber = Number * 2 + 1;
            //取得 左节点
            LastTraverSal(LeftNumber-1);
            //取得有 右节点
            LastTraverSal(RightNumber-1);
            //取得当前的节点  
            Console.Write(data[index] + " ");

      }

        /// <summary>
        /// 从树的 第一层开始 ，从上到下 逐层遍历，在同一层中，从左到右对结点 逐个访问输出
        /// </summary>
        /// <param name="index"> 下标</param>
        private void LayerTraverSal(int index)
        {
            for (int i = 0; i <Count; i++)
            {
                if (data[i].Equals(-1)) //该位置为空 继续 循环 
                {
                    continue;
                }
                Console.Write(data[i] + " ");

            }
        }

        public void LayerTrvaerSal()
        {
            LayerTraverSal(0);
        }
    }
}

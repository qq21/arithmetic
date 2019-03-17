using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 二叉树_顺序结构存储
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] data = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I' ,'J'}; //这个我们要存储的数据
            BiTree<Char> tree = new BiTree<char>(10);

            for (int i = 0; i <data.Length; i++)
            {
                tree.Add(data[i]);
            }
            tree.FirstTraverSal();
            Console.WriteLine();
            tree.MidTraverSal();
            Console.WriteLine();
            tree.LastTraverSal();
            Console.WriteLine();
            tree.LayerTrvaerSal();
            Console.WriteLine();
        }
    }
}

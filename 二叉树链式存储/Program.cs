using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 二叉树链式存储
{
    class Program
    {
        static void Main(string[] args)
        {
            BSTree bSTree = new BSTree();
            int[] data = { 62, 58, 88, 47, 73, 99, 35, 51, 93, 37 };

            foreach (int item in data)
            {
                bSTree.Add(item);
            }
            bSTree.Delete(88);
            bSTree.MiddleTraverSal();
            Console.WriteLine(bSTree.Find(99));
            Console.WriteLine(bSTree.Find(990));
        }
    }
}

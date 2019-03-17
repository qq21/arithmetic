using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 二叉树链式存储
{
    class BSNode
    {
        public BSNode LeftChild { get; set; } = null;

        public BSNode RightChild { get; set; } = null;

        public BSNode Parent { get; set; } = null;

        public int dada { get; set; }

        public BSNode() { }
        public BSNode(int item)
        {
            this.dada = item;
        }
    }
}

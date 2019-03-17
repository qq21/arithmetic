using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 二叉树链式存储10_16
{
    class BSTree
    {
        private BSNode Root=null;

        
        /// <summary>
        /// 大于 根结点 放在右边 小于放在左边
        /// </summary>
        /// <param name="item"></param>
        public void Add(int item)
        {
            BSNode newBSNode = new BSNode(item);

            if (Root==null)
            {
                Root = newBSNode;
            }
            else
            {
                BSNode temp = Root;
                while (true)
                {               //如果  比当前 结点的数据大就放右边    小于就 放左边
                    if (item >= temp.dada)
                    {
                        // 如果右边为空了就插入 节点
                        if (temp.RightChild==null)
                        {
                            temp.RightChild = newBSNode;
                            newBSNode.Parent = temp;
                            break; //插入了数据 跳出循环
                        }
                        else
                        {
                            temp = temp.RightChild;
                        }
                    }
                    else  //小于 放在左边
                    {
                        //往左边插入
                        if (temp.LeftChild==null)
                        {
                            temp.LeftChild = newBSNode;
                            newBSNode.Parent = temp;
                            break; //插入了数据  跳出循环
                        }
                        else //继续执行
                        {
                            temp = temp.LeftChild;

                        }
                    }
                }

            }

        }

        public void MiddleTraverSal() { MiddleTraverSal(Root);  }

        private void MiddleTraverSal(BSNode node)
        {
            if (node==null)
            {
                return;
            }

            MiddleTraverSal(node.LeftChild);
            Console.Write(node.dada + " ");
            MiddleTraverSal(node.RightChild); 

        }

        public bool Find(int item)
        {
            return Find(item, Root);
        }
        private bool Find(int item,BSNode node)
        {
            if (node==null)
            {
                return false;
            }

            if (node.dada==item)
            {
                return true;
            }
            else
            {
                if (node.dada<=item)
                {
                    return Find(item, node.RightChild);
                }
                else
                {
                    return Find(item, node.LeftChild);
                
                }

             
            }
            
            return false;
        }

        public bool Delete(int item)
        {
            BSNode temp = Root;

            while (true)
            {
                if (temp == null) return false;
                if (temp.dada == item)
                {
                    Delete(temp);
                    return true;
                }
                if (item>temp.dada)
                {
                    temp = temp.RightChild;
                }
                else
                {
                    temp = temp.LeftChild;
                }
            }
        }
        public void Delete(BSNode node)
        {
            ///删除的是  叶子 结点  情况1
            if (node.LeftChild==null && node.RightChild==null)
            {
                if (node.Parent==null) //无 父 结点 就是 根结点
                {
                    Root = null;
                }
                else if (node.Parent.RightChild==node) //如果结点是 父节点的 右结点 
                {
                    node.Parent.RightChild = null;
                }
                else if (node.Parent.LeftChild==node)
                {
                    node.Parent.LeftChild = null;
                }

                return;
            }

            //只有右孩子  情况2
            if (node.LeftChild == null && node.RightChild != null)
            {
                node.dada = node.RightChild.dada; //拿到数据 拿到引用
                node = node.RightChild; //左 节点已经为null 直接拿到引用
                return;
            }

            if (node.LeftChild!=null&& node.RightChild==null)
            {
                node.dada = node.LeftChild.dada;
                node = node.LeftChild;
                return;
            }

            // 情况3  左右孩子都有


            BSNode Temp = node.RightChild;
            while (true) //左结点最小 的
            {
                if (Temp.LeftChild != null) //存在左结点  一直查找到最后  右结点 中 的左子节点中寻找最小的 。  
                {
                    Temp = Temp.LeftChild;
                }
                else
                {
                    break;
                }
            }
            //BSNode Temp = node.LeftChild;
            //while (true)
            //{
            //    if (Temp.RightChild!=null)
            //    {
            //        Temp = Temp.RightChild;
            //    }
            //    else
            //    {
            //        break;
            //    }
            //}
            node.dada = Temp.dada;
            Delete(Temp);
         
        }
    }
}

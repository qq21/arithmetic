using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 最小栈
{
    public class MinStack
    {

        /** initialize your data structure here. */
        // 栈  先 入 后出

    
        Stack<int> data;
        Dictionary<int, int> _minDic;
        public MinStack()
        {
            data = new Stack<int>();
            _minDic = new Dictionary<int, int>();
        }

        public void Push(int x)
        {
            data.Push(x);
            if (data.Count==1)
            {
                _minDic.Add(1, x); //只有1 个默认 最小
            }
            else
            {
                int pre = data.Count - 1; //取 前一个下标
                int min= Math.Min(_minDic[pre],x);
                _minDic.Add(_minDic.Count, x);
            }
          
             
        }

        public void Pop()
        {


            int min = data.Pop();
            if (_minDic.ContainsKey(data.Count+1))
            {
                _minDic.Remove(data.Count+1);
            }
            
        }

        public int Top()
        {
             return data.Peek();
        }

        public int GetMin()
        {
            if (data.Count> 0)
            {
                return _minDic[data.Count];
            }
            else
            {
                return int.MinValue;
            }
        }

        static void Main()
        {
            uint a = 00000000000000000000000000011111;

 
            Console.WriteLine(a&(1<<4));
        }

        public int HammingWeight(uint n)
        {
            int count = 0;
            while (n!=null)
            {
                n &= n - 1;
                count++;
            }
            return count;
        }
    
}

    public class Hamming
    {
        public  int HammingWeight(uint n)
        {
            string nums = n.ToString();

            int count = 0;
            foreach (var item in  nums)
            {
                if (item=='1')
                {
                    count++;
                }
            }
            return count;
        }
    }
}

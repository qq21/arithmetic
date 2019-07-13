using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_双指针
{
    class Program
    {
       
        static void Main(string[] args)
        {
            
            int[] res = TwoSum3(new[] {1, 2, 3, 4, 5}, 5);
            Console.WriteLine("TwoSum:res"+res[0]+"_"+res[1]);

            Console.WriteLine("JudgeSqueareSum:"+JudgeSqueareSum(5));
           
        }


        #region  双指针
        //Input: numbers={2, 7, 11, 15}, target=9
        //Output: index1=1, index2=2
        //双指针  ----- 有序的数组 从小到大
        //使用双指针 一个指向最小， 一个指向最大
        public static int[] TwoSum3(int[] nums, int target)
        {
            int i = 0, j = nums.Length - 1;
            while (i < j)
            {
                int sum = nums[i] + nums[j];
                if (sum == target)//找到结果
                {

                    return new int[] { i, j };

                }
                else if (sum < target) //小了n i++
                {
                    i++;
                }
                else //大了  j--
                {
                    j--;

                }

            }

            return null;
        }
        //两数平方和 
        //描述：判断一个数是否是两个数的平方和
        public static bool JudgeSqueareSum(int n)
        {
            //思路 取得最大平方根j 和i，i=0  计算它们 各种的平方和，相加，如果比n大则说明 最大的需要减少了j--，如果比n小。则说明 最大的需要增加了
            
            int i = 0, j = (int)Math.Sqrt(n);
            int sum = 0;
            while (i <= j)
            {
                sum = i * i + j * j;

                if (sum > n)
                {
                    j--;
                }
                else
                {
                    i++;
                }

                if (sum == n)
                {
                    return true;
                }

            }
            return false;
        }
        //反转 元音 字母
        public static string ReverseVowels(string s)
        {
            // 元音字母 列表，
            char[] vowels = new char[] {'a', 'e', 'i','o','u','A','E','I','O','U'};
            HashSet<char> vowelSet=new HashSet<char>(vowels);
            //从存两个指针 i=0    和j=  最大长度-1，  因为下标是从0开始的。
            int i = 0, j = s.Length - 1;
            char[] res=new char[s.Length];

            while (i<j)
            {
                if (!vowelSet.Contains(s[i]))
                {
                    res[i] = s[i];
                    i++;
                }
                else if (!vowelSet.Contains(s[j]))
                {
                    res[j] = s[j];
                    j--;
                }
                else 
                {
                    res[i] = res[j];
                    i++;

                    res[j] = res[i];
                    j--;   
                }   
            }
            return res.ToString();
        }

        /// <summary>
        /// 删除一个字母  查看是否构成回文
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool ValidPalinDrom(string s)
        {
            for (int i = 0,j=s.Length-1; i <j; i++,j--)
            {
                if (s[i]!=s[j])
                {
                    //两种可能  1种是 需要删除i ，  一种 是需要删除j
                    return isPalinDrom(s, i+1, j) || isPalinDrom(s, i, j-1);
                }
            }
            return true; //不需要 删除的情况
        }

        /// <summary>
            /// 
            /// </summary>
            /// <param name="s">字符</param>
            /// <param name="i">最小索引</param>
            /// <param name="j">最大索引</param>
            /// <returns></returns>
        private static bool isPalinDrom(string s, int i, int j)
        {
            while (i<j)
            {
                if (s[i++]!=s[j--])
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        ///  合并两个有序 数组，思路就是 存3个最大 索引 指针，分别 是数组1的值 长度m， 数组2的值长度n， 以及它们合并后的最大长度m+n-1 
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="m"></param>
        /// <param name="num2"></param>
        /// <param name="n"></param>
        public void Merge(int[] nums1,int m,int[] num2, int n)
        {
            int index1 = m - 1; //nums的下标 从最大开始
            int index2 = n - 1; //nums2的下表， 从最大开始
            int indexMerge = m + n - 1; //合并数组的最大下表， 从最大开始
            //合并到 数组nums1 上
            while (index1>0||index2>0)
            {
                if ( index1<0) //剩下 index2
                {
                    nums1[indexMerge--] = num2[index2--];
                }
                else if (index2<0)  // 剩下index1
                {
                    nums1[indexMerge--] = nums1[index1--];
                }
                else if (nums1[index1]>num2[index2]) //第一最大的大于第二的
                {
                    nums1[indexMerge--] = nums1[index1--]; //存放最大
                }
                else
                {
                    nums1[indexMerge--] = num2[index2--];
                }
                 
            }
             
        }


        public class  ListNode<T>
        {
            public T Value;
            public ListNode<T> Next;

            /// <inheritdoc />
            public ListNode(T value)
            {
                Value = value;
            }

            /// <inheritdoc />
            public ListNode(T value, ListNode<T> next)
            {
                Value = value;
                Next = next;
            }

            /// <inheritdoc />
            public ListNode()
            {
            }
        }

        /// <summary>
        ///  环 链表， 思路  快慢指针，慢指针指向下一个， 快指针指向下一个的下一个，如果（引用）相等，说明是环链表 
        /// 最终肯定会相遇，即链表 存在环，
        /// </summary>
        public bool HasCycle(ListNode<int> head)
        {
            if (head==null)
            {
                return false;
            }
            ListNode<int> node1 = head;
            ListNode<int> node2 = head.Next;


            while (node1!=null&&node2!=null &&node2.Next!=null) //还需要判断node2的next是否为null
            {
                if (node1 ==node2 )
                {
                    return true;
                }
                else
                {
                    node1 = node1.Next;
                    node2 = node2.Next.Next;
                }
            }

            return false;
        }

        /// <summary>
        /// 最长子序列，
        /// 题目描述：删除 s 中的一些字符，使得它构成字符串列表 d 中的一个字符串，找出能构成的最长字符串。如果有多个相同长度的结果，返回字典序的最小字符串
        /// </summary>
        /// <param name="s"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public string FindLongestWord(string s,List<string> d)
        {
              
            return "";
        }

        #endregion
    }
}

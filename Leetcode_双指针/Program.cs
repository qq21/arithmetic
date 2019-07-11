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

        #endregion
    }
}

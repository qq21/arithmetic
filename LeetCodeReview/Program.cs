using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeReview
{
    class Program
    {
        static void Main(string[] args)
        {

           /*int[] op= TwoSum(new int[] {15, 7, 11, 2},9);

            Console.WriteLine(op[0]+"....."+op[1]);
            */

           if ("   "=="")
           {
              
           }
           //Console.WriteLine((int)'a');
           Console.WriteLine(LengthOfLongestSubstring("asjrgapa")); 
        }

        public static int LengthOfLongestSubstring(string s)
        {


            int n = s.Length;
            int res = 0;
            int[] code = new int[128];
            string temp = "";
            for (int i = 0,j=0; i <n; i++)
            {
                j = Math.Max(code[s[i]], j);//
                res = Math.Max(res, i - j + 1);
                code[s[i]] = i + 1;
            }
             
            return res;
        }


        #region 001l两数之和
        //两数之和
        public static int[] TwoSum(int []nums,int target)
        {
            Dictionary<int,int> numsDic=new Dictionary<int,int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (!numsDic.ContainsKey(nums[i]))
                {
                    numsDic.Add(nums[i], i);
                }   

                int res = target - nums[i];  

                if (numsDic.ContainsKey(res))
                {
                    return new int[] {numsDic[res], i};
                }
               
                
            }
            return null;
        }
   
        //暴力破解
        public static int[] TwoSum2(int []nums ,int target)
        {
            for (int i = 0; i <nums.Length; i++)
            {
                int res = target - nums[i];
                for (int j = 0; j < nums.Length; j++)
                {
                    if (i!=j)
                    {
                        if (res == nums[j])
                        {
                            int a = Math.Min(i, j);
                            int b = Math.Max(i, j);
                            return  new int[]{ a,b};
                        }
                    }
                    
                }
            }
            return  new int[]{};
        }
        #endregion

        #region 002x_爬楼梯
        //climbStair(i,n)=climbStair(i-1,n)+climbStair(i-2,n)
        public static int climbStair(int n)
        {
            return climb_Stair(0, n);
        }

        public static int climb_Stair(int i,int n)
        {
            if (i>n)
            {
                return 0;
            }

            if (i==n)
            {
                return 1;
            }

            return climb_Stair(i - 1, n) + climb_Stair(i - 2, n);
        }

        //记忆递归
        public static int climb_Stair2(int i, int n,int[] nums)
        {
            if (i > n)
            {
                return 0;
            }

            if (i == n)
            {
                return 1;
            }
            // 每次
            if (nums[i] > 0)
            {
                return nums[i];

            }

            nums[i] = climb_Stair2(i - 1, n, nums) + climb_Stair2(i - 2, n, nums);
             
            return nums[i];
        }
        
        //动态规划
        // 第i阶  可以由以下两种方法得到
        // I 在（i-1）阶 向上爬 一阶
        //II 在（i-2）阶 向上爬二阶
        //总数 到达第i阶的方法就是 第（i-1） 和第（i-2）阶的和
        //dp(n)=dp(n-1)+dp(n-2)

        public static int climb_Stair3(int n)
        {
            if (n==1)
            {
                return n;
            }
            int[] dp=new int[n+1];
            dp[1] = 1;
            dp[2] = 2;
            for (int i = 3; i <= n; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }

            return dp[n];
        }
        /// 斐波那契数  O（n)
        public static int climb_Stair4(int n)
        {
            if (n==1)
            {
                return 1;
            }

            int first = 1;
            int second = 2;
            int three = 3;
            for (int i = 3; i <=n; i++)
            {
                //第三个数是 前两个数的和
                three = first + second;
                first = second;
                second = three;

            }
            return three;
        }


        public static int climb_Stair5(int n)
        {
            double sqrt5 = Math.Sqrt(5);
            double fibn = Math.Pow((1 + sqrt5) / 2, n + 1) - Math.Pow((1 - sqrt5) / 2, n + 1);
            return (int)(fibn/sqrt5);
        }

        #endregion

        #region 002_买卖股票最佳时机         

        public static int MaxProfilt(int[] nums)
        {
            int max = 0;
            for (int i = 1; i <nums.Length; i++)
            {
                int res = nums[i] - nums[i - 1];
                if (res>0)
                {
                    max += res;
                }
            }

            return max;
        }

        #endregion


        #region 动态规划



        #endregion


    }


    ///
    ///
    ///
    ///
    ///
    ///


}

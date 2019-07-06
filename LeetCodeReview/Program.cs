using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeReview
{
    class Program
    {
        static void Main(string[] args)
        {

           int[] op= TwoSum(new int[] {15, 7, 11, 2},9);

            Console.WriteLine(op[0]+"....."+op[1]);

        }


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
    }
    

    ///
   ///
   ///
   ///
   ///
   ///
   
     
}

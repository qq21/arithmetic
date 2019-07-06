using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3数之和
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IList<int>> resList = new List<IList<int>>();

            List<int> res2 = new List<int>() { 1, 2, 3 };
            List<int> res3 = new List<int>() { 1, 2, 3 };
     
        }
        public static IList<IList<int>> ThreeSum(int[] nums)
        {
 
            List<IList<int>> resList = new List<IList<int>>();
            for (int i = 0; i < nums.Length-1; i++)
            {
                int count=0;
                int res=nums[i];
                for (int j = i+1; j <nums.Length; j++)
                {

                    res += nums[j];
                    count++;
                    if (count==2)
                    {
                        if (res==0)
                        {
                            List<int> temp = new List<int>();
                            temp.Add(nums[i]);
                            temp.Add(nums[j - 1]);
                            temp.Add(nums[j]);


                            foreach (var item in  resList)
                            {

                            }
                            if (!resList.Contains(temp))
                            {
                                resList.Add(temp);
                            }
                            
                            
                        }
                        res = nums[i];
                        count = 0;
                    }
                }
            }
            return resList;
        }
    }
}

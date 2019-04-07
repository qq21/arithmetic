using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 缺失数字
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public int MissingNumber(int[] nums)
        {


            Array.Sort(nums);
            if (nums.Length == 1 && nums[0] == 0) { return 1; }

            if (nums.Length == 1) { return 0; }

            if (nums.Length == 0) { return 0; }
            for (int i = 0; i < nums.Length; i++)
            {
                if (i != nums[i])
                {
                    return i;

                }
            }
            return nums.Length;
        }
    
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Str题目
{
    class Program1
    {
        static void Main(string[] args)
        {
            // string[] sts = {"test.email+alex@leetcode.com", "test.e.mail+bob.cathy@leetcode.com", "testemail+david@lee.tcode.com"};

            //Console.WriteLine(  NumUniqueEmails(sts));
            int[] nums = new int[] { 1, 2, 3, 4,5,6,7,8,9};
            int k =5;
           // Console.WriteLine(k % nums.Length);

            int r = k % nums.Length;
            Console.WriteLine("k:"+r);
            int[] less = new int[r];
            for (int i = 0;i< nums.Length; i++)
            {
                List<int> list = new List<int>();
                int[] res = new int[10];
                int[] newData = new int[5];
                res.CopyTo(newData, 0);
                if (i+r>nums.Length-1)//越界
                {
                    Console.WriteLine("越界的:" + nums[i]);
                    less[ less.Length-(nums.Length - i)]=nums[i];
                }

            }
            for (int i = nums.Length-1; i>=0; i--)
            {
                if (i + r < nums.Length - 1)
                {
                    nums[i + r] = nums[i];
                }
                else if (i+r==nums.Length-1)
                {
                    nums[i + r] = nums[i];
                }
            }

            for (int i = 0; i < less.Length; i++)
            {
                nums[i] = less[i];
            }
            
             
            
          
        }
        public static int NumUniqueEmails(string[] emails)
        {

            int count = 1;
            string[] FinalName = new string[emails.Length];
             
            for (int i = 0;i<emails.Length; i++)
            {
                
                string[] newStrs = emails[i].Split('@');
                string newStr2 = newStrs[0].Split('+')[0];
                string[] newStr3 = newStr2.Split('.');
                string resLocalName = "";
                //foreach (string item in newStr3)
                //{
                //    if (item!=null)
                //    {                        
                //    resLocalName += item;
                //    }
                //}
                for (int j = 0; j <newStr3.Length; j++)
                {
                    string item = newStr3[j];
                    if (item != null)
                    {
                        resLocalName += item;
                    }
                }
               FinalName[i] = resLocalName+ newStrs[1];                 
            }
            
            for (int i = 0; i <FinalName.Length; i++)
            {
                for (int j = i+1; j <FinalName.Length; j++)
                {
                    if (FinalName[i]==FinalName[j])
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}

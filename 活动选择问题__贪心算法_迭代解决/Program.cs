using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 活动选择问题__贪心算法_迭代解决
{
    public  class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    class Program
    {
      static  int[] s = { 0, 1, 3, 0, 5, 3, 5, 6, 8, 8, 2, 12 };
      static int[] f = { 0, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };


        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode temp1 = l1;
            ListNode temp2 = l2;
       
            //取得个位上的数
            int num1 = temp1.val;
            int num2 = temp2.val;
            int res = 0;
            //十位的个数
            int count = 1;


            //求得  顺序数;
            while (true)
            {
                if (temp1.next == null)
                {
                    break;
                }
                else
                {
                    temp1 = temp1.next;
                    count *= 10;
                    num1 += temp1.val * count;
                }
            }
            count = 1;
            while (true)
            {
                if (temp2.next == null)
                {
                    break;
                }
                else
                {
                    temp2 = temp2.next;
                    count *= 10;
                    num2 += temp2.val * count;
                }
            }
            //取得a上第x位 上的值 就是a%(x*10)/x 
            res = num1 + num2;
            Console.WriteLine(res);

            count = res.ToString().Length;
            ListNode resNode = new ListNode(res % 10);
            ListNode tempNode = resNode;
            int ten = 1;
            for (int i = 10; i <Math.Pow(10,count); i*=10)
            {
                ten *= 10;

                long x =GetXinNumber(i, res);
            

                ListNode NextNode = new ListNode((int)x);
                tempNode.next = NextNode;
                tempNode = NextNode;
            }
            return resNode;
        }

        static void Main()
        {


            //ListNode node = new ListNode(9);
            //ListNode node2 = new ListNode(1);
            //node2.next = new ListN ode(9);
            //ListNode node3= AddTwoNumbers(node, node2);

            //while (node3!=null)
            //{
            //    Console.Write(node3.val);
            //    node3 = node3.next;
            //}
            //Console.ReadKey();
            //int startTime = 0;
            //int endTime = 24;

            //List<int> list = new List<int>();

            //for (int i = 0; i <f.Length-1; i++)
            //{
            //    if (s[i]>=startTime&&f[i]<=endTime)
            //    {
            //        list.Add(i);
            //        startTime = f[i];//将上次 结束的时间走位 本次开始时间再进行比较
            //    }
            //}
            long max = 123456789987;

            for (long i = 1; i < Math.Pow(10, max.ToString().Length); i *= 10)
            {
                Console.WriteLine(GetXinNumber(i, max));
            }
            
        }

        static long GetXinNumber(long x, long number)
        {
            return number % (x * 10) / x;
        }

        public static List<int> ACS(int  startNum,int endNum,int startTime,int endTime)
        {
            int startANum = 0;
            for (int i = startNum; i <= endNum; i++)
            {
                if (s[i]>=startTime&&f[i]<=endTime)
                {
                    startANum = startNum;
                    break;
                }
            }
            
            //找下一个
            List<int> actList = ACS(startANum+1, endNum, s[startANum], endTime);
            actList.Add(startANum);
            return actList;
        } 
    }
}

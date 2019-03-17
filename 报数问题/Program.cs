using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 报数问题
{
    class Program
    {
        static void Main(string[] args)
        {
            //  Console.WriteLine("123" == "123");

            //Console.WriteLine( LongestCommonPrefix(new string[]{"a","b"}));
            ListNode node = new ListNode(4);
            ListNode Next =node.SetNext(new ListNode(5));
            ListNode Next2=Next.SetNext(new ListNode(1));
            ListNode Next3 = Next2.SetNext(new ListNode(9));


            RemoveNthFromEnd(node, 2);      
            while (node != null)
            {
                Console.Write(node.val);
                node = node.next;
            }
        }
        public string CountAndSay(int n)
        {
            //string a = "", temp = "";
            //for (int i = 1; i <n; i++)
            //{
            //    int t = 0;
            //    while (t<a.Length)
            //    {
            //        int value = 1;
            //        while (a[t] == a[t + 1])
            //        {
            //            value++;
            //            t++;
            //        }
            //        temp = temp + value.ToString() + a[t];
            //        t++;

            //    }
            //    a = temp;
            //    temp = "";
            //}
            //return a;
            string s = "1";
            int k;
            for (int i = 1; i < n; i++)
            {
                StringBuilder t = new StringBuilder();
                for (int j = 0; j < s.Length; j = k)
                {
                    k = j;
                    //找有几个相同的.
                    while (k < s.Length && s[k] == s[j])
                    {
                        k++;
                    }
                    t.Append(k - j).Append(s[j]);
                }
                s = t.ToString();
            }
            return s;
        }
        public static  string LongestCommonPrefix(string[] strs)
        {

            string temp = "";
            
            if (strs.Length == 0) return "";
            if (strs[0].Length == 0) return "";
            if (strs.Length == 1) return strs[0];

            temp = "";//保存前缀
            for (int j = 1; j <strs.Length; j++)//小于等于2 
            {
                string tempStr = "";//保存其他前缀
                for (int k = 0; k < strs[j].Length; k++)//小于1
                {
                    //越界 判断

                    if (k < strs[0].Length && strs[0][k] == strs[j][k])
                    {
                        tempStr += strs[0][k];

                    }
                    else
                    {
                        break;
                    }
                }
                if (j == 1)
                {
                    temp = tempStr;
                }
                else //第二次
                if (temp != tempStr)
                {
                    if (temp.Contains(tempStr))//大的 包含小的 取最小
                    {
                        temp = tempStr;
                        continue;
                    }
                    else
                    if (tempStr.Contains(temp))//
                    {
                        continue;
                    }
                    else
                    {
                        return "";
                    }

                }

            }
            return temp;
        }
        public static bool ContainsDuplicate(int[] nums)
        {
            Array.Sort(nums);
            for (int i = 0; i <nums.Length-1; i++)
            {
                if (nums[i]==nums[i+1])
                {
                    return true;
                }
            }
        return false;
        }
        public static void DeleteNode(ListNode node)
        {
            node.val = node.next.val;
            node.next = node.next.next;
        }
        public static ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            ListNode temp = head;
            int count=0;
            while (temp != null)
            {
                count++;
                temp = temp.next;
            }
            ListNode currentNode=head;
            for (int i = count - n; i > 0; i--)
            {
                currentNode = currentNode.next;
            }
            currentNode.val = currentNode.next.val;
            currentNode.next = currentNode.next.next;
            return head;
        }
    }
    public class ListNode
    {
      public int val;
      public ListNode next;
      public ListNode instance;
      public ListNode SetNext(ListNode next)
      {
            this.next = next;
            return next;
       }
      public ListNode(int x) { val = x; instance = this; }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 字符操作
{
    class Program
    {
        static void Main(string[] args)
        {

            //   Console.WriteLine(Reverse(-239999999));
            //int a = 'A';//97 122
            //Console.WriteLine(a);
            //   Console.WriteLine(IsPalindrome("A man, a plan, a canal: Panama"));
            //LinkedStack<int> linkedStack = new LinkedStack<int>();
            //LinkedQueue<int> linkedQueue = new LinkedQueue<int>();
            //linkedQueue.EnQueue(1); linkedQueue.EnQueue(2); linkedQueue.EnQueue(3); linkedQueue.EnQueue(4); linkedQueue.EnQueue(5);
            //linkedStack.Push(1).Push(2).Push(3).Push(4).Push(5);


            //for (int i = 0; i < 5; i++)
            //{
            //    Console.WriteLine(linkedQueue.DeQueue()); ;
            //    Console.WriteLine(linkedStack.Pop());

            //}
            Console.WriteLine(MyAtoi("+-2"));
        }
        public static string ReverseString(string s)
        {
            char[] res = s.ToArray();
            Array.Reverse(res);
            int a = 6666;
            char[] res2 = a.ToString().ToCharArray();

            s.IndexOf(s[0], 1);

            return new string(res);
        }
        public static int Reverse(int x)
        {
            bool isF = false;
            if (x < 0)
            {

                x = -x;
                isF = true;
            }

            char[] res2 = x.ToString().ToCharArray();
            Array.Reverse(res2);
            string str = new string(res2);

            int resNum = int.Parse(str);
            int.TryParse(str, out resNum);
            if (isF)
            {
                return -resNum;
            }
            else
            {
                return resNum;
            }


        }
        public static int FirstUniqChar(string s)
        {
            if (s == "") { return -1; }
            List<char> c = new List<char>();

            char temp = s[0];
            int length = s.Length;
            char[] res = s.ToArray();
            if (length == 1)
            {
                return 0;
            }
            bool isFind = false;
            for (int i = 0; i < length; i++)
            {
                isFind = false;
                if (!c.Contains(res[i]))
                {
                    for (int j = i + 1; j < length; j++)
                    {
                        if (!c.Contains(res[j]))
                        {
                            if (res[i] == res[j])
                            {
                                c.Add(res[i]);
                                isFind = true;
                            }

                        }
                    }
                }
                else { isFind = true; }
                if (!isFind)
                {
                    return i;
                }
            }

            return -1;

        }

        public static int StrStr(string haystack, string needle)
        {
            if (needle.Length > haystack.Length)
            {
                return -1;
            }
            if (needle=="")
            {
                return 0; 
            }
            return haystack.IndexOf(needle);

 

        }
        public static bool IsAnagram(string s, string t)
        {
            if (s == "" && t == "")
            {
                return true;
            }
            char[] cha1 = s.ToArray();

            char[] cha2 = t.ToArray();

            int[] ap = new int[26];
            for (int i = 0; i < cha1.Length; i++)
            {
                ap[cha1[i] - 'a']++;
                ap[cha2[i] - 'a']--;
            }
            for (int i = 0; i < ap.Length; i++)
            {
                if (ap[i] != 1)
                {
                    return false;
                }
            }
            return true;

        }
        public static bool IsPalindrome(string s)
        {
            //方法一
            //char[] cha = s.ToLower().ToArray();

            //List<char> cha2 = new List<char>();

            //LinkedStack<char> linkedStack = new LinkedStack<char>();

            //for (int i = 0; i < cha.Length; i++)
            //{
            //    if ((cha[i] >= 48 && cha[i] <= 57) || cha[i] >= 97 && cha[i] <= 122)
            //    {
            //        cha2.Add(cha[i]);
            //        linkedStack.Push(cha[i]);

            //    }
            //}
            //char[] char3 = new char[cha2.Count];
            //cha2.CopyTo(char3);

            //cha2.Reverse();
            //for (int i = 0; i < char3.Length; i++)
            //{
            //    if (char3[i] != cha2[i])
            //    {
            //        return false;
            //    }
            //}

            s = s.ToLower();

            int left = 0, right = s.Length - 1;
            while (left < right)
            {
                if (!Char.IsLetterOrDigit(s[left]))
                {
                    left++;
                    continue;
                }
                if (!Char.IsLetterOrDigit(s[right]))
                {
                    right++;
                    continue;
                }

                if (s[left] != s[right])
                {
                    return false;
                }


                left++;
                right--;
            }

            return true;
        }
        public static int MyAtoi(string str)
        {
            str = str.Trim();
            char[] cha1 = str.ToArray();
            string res = "";
            int numType = 1;

            if (str == "") { return 0; }
            if (str.Length == 1 && cha1[0] == '-') { return 0; }
            if (str.Length == 1 && cha1[0] == '+') { return 0; }

            if (cha1[0] == '-' || Char.IsNumber(cha1[0]) || cha1[0] == '+')
            {
                if (cha1[0] == '-')
                {
                    numType = -1;
                }

                int tempI = 0;
                if (cha1[0] == '-' || cha1[0] == '+')
                {
                    tempI = 1;
                }

                for (int i = tempI; i < cha1.Length; i++)
                {
                     
                        if (Char.IsNumber(cha1[i]))
                        {
                            res += cha1[i].ToString();
                        }
                    else
                    {
                        break;
                    }
                }
                int finalRes = 0;
                Console.WriteLine(res);
                if (res=="")
                {
                    return 0;
                }
                if (int.TryParse(res, out finalRes))
                {
                    return numType * finalRes;
                }
                else
                {
                    if (numType == 1)
                    {
                        return int.MaxValue;
                    }
                    return int.MinValue;
                }
            }
            else
            {
                return 0;
            }

        }
        public class Node<T>
        {
            public Node<T> next;
            public T data;
            public Node()
            {
            }
            public Node(T data)
            {
                this.data = data;
                next = null;
            }
            public Node(Node<T> node)
            {
                data = default(T);
                this.next = node;
            }
            public Node(Node<T> node, T data)
            {
                this.next = node;
                this.data = data;
            }
        }
        public class LinkedStack<T>
        {
            Node<T> head;
            int count = 0;
            LinkedStack<T> instance;
            public LinkedStack()
            {
                head = null;
                count = 0;
                instance = this;
            }
            public LinkedStack<T> Push(T data)
            {
                Node<T> node = new Node<T>(data);
                if (head == null)
                {
                    head = node;
                }
                else
                {
                    node.next = head;
                    head = node;
                }
                count++;
                return instance;
            }

            public T Pop()
            {
                if (head == null)
                {
                    throw new Exception("空栈");
                }
                else
                {

                    T data = head.data;
                    if (head.next != null)//不止一个的情况
                    {
                        Node<T> nextNode = head.next;//取得下个节点 断开引用
                        head = nextNode;
                    }
                    else
                    {
                        head = null;
                    }
                    count--;
                    return data;
                }

            }

            public int GetCount()
            {
                return count;
            }

            public T Peek()
            {
                if (head == null)
                {
                    throw new Exception("空栈");
                }
                return head.data;
            }
            public void Clear()
            {

                head = null;
                count = 0;
            }
        }
        public class LinkedQueue<T>
        {
            Node<T> front;
            int count;

            public void EnQueue(T data)
            {
                Node<T> Node = new Node<T>(data);
                if (front == null)
                {
                    front = Node;
                }
                else
                {
                    Node<T> temp = front;
                    while (temp.next != null)
                    {
                        temp = temp.next;
                    }
                    temp.next = Node;
                }
                count++;
            }
            public T DeQueue()
            {
                T data;
                if (front == null)
                {
                    throw new Exception("空队列");
                }
                else
                {
                    data = front.data;
                    Node<T> Next = front.next;
                    front = Next;

                    return data;
                }
            }
            public T Peek()
            {

                return front.data;
            }

            public LinkedQueue()
            {
                front = null;
                count = 0;
            }
        }
    }
}

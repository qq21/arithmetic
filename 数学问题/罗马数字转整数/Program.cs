using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 罗马数字转整数
{
    class Program
    {
        public static Dictionary<int, int> RomanDic = new Dictionary<int, int>()
        {
            {
                'I', 1
            },
            {
                'V', 5
            },
            {
                'X', 10
            },
            {
                'L', 50
            },
            {
                'C', 100
            },
            {
                'D', 500
            },
            {
                'M', 1000
            },
            {
                'I'+'V', 4
            },
            {
                'I'+'X', 9
            },
            {
                'X'+'L', 40
            },
            {
                'X'+'C', 90
            },
            {
                'C'+'D', 400
            },
            {
                'C'+'M', 900
            }
        };

        static void Main(string[] args)
        {

         
 

            Console.WriteLine( RomanToInt("MCMXCIV"));



            //V             5
            //X             10
            //L             50
            //C             100
            //D             500
            //M             1000



        }
        public static  int RomanToInt(string s)
        {
                
            int index = 0;//当前 下标
            int count=0;

            while (true)
            {

              
                if (s[index]=='I'|| s[index]=='X'|| s[index]=='C')
                {

                  int key = 0;

                    //最后一个元素
                    if (index == s.Length-1)
                    {
                          key = s[index];
                    }
                    else
                    {
                        key = s[index]  + s[index + 1] ;
                    }
                    
                    if (RomanDic.ContainsKey(key))
                    {
                        count += RomanDic[key];
                        
                        index += 2;
                    }
                    else
                    {
                        count += RomanDic[s[index]];
                        index++;
                    }
                }
                else
                {
                    count += RomanDic[s[index]];
                    index++;
                }

                if (index > s.Length - 1)
                {
                    break;
                }
            }

            return count;
        }

    }
   
}

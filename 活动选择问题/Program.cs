using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 活动选择问题
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 暴力破解
            //Dictionary<int,int> MaxList = new  Dictionary<int, int>();
            //for (int i = 0; i < 11; i++)
            //{
            //    Dictionary<int, int> TempMax;
            //    TempMax = ActivitySelect(new int[] { 1, 3, 0, 5, 3, 5, 6, 8, 8, 2, 12 }, new int[] { 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 }, i);
            //    if (TempMax.Count > MaxList.Count)
            //    {
            //        MaxList = TempMax;
            //    }
            //    Console.WriteLine();
            //}

            //foreach(KeyValuePair<int,int> keyValue in MaxList)
            //{
            //    Console.Write(keyValue.Value+" ");
            //}
            #endregion  

            int[] s = new int[] {0, 1, 3, 0, 5, 3, 5, 6, 8, 8, 2, 12 ,24};
            int[] f = new int[] {0, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 24};
            List<int>[,] result = new List<int>[13,13];//默认 值 null

            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    result[i, j] = new List<int>();
                }
            }

            for (int j = 0; j <13; j++) //当j=2的 时候 下面 才会运行
            {
                for (int i = 0; i < j-1; i++)// i 至少要 比i小 1 
                {
                    //S[ij] i 结束 之后 j开始之前的 活动集合
                    //f[i]开始  s[i]结束  这个时间区间内所有的活动
                    List<int> sij = new List<int>();
                    for (int number = 1; number < s.Length-1; number++) //最后 活动不算 因此 减1
                    {
                        if (s[number]>=f[i]&&f[number]<=s[j])
                        {
                            sij.Add(number);
                        }
                    }

                    if (sij.Count>0)
                    {

                        //result[i,j]=Max{result[i,k] +result[k,j]+k }     //有活动
                        int maxCount = 0;
                        List<int> tempList = new List<int>();
                        foreach (int  number in sij)
                        {
                            int count = result[i, number].Count + result[number, j].Count + 1;
                            if (maxCount<count)
                            {
                                maxCount = count;
                                tempList = result[i, number].Union<int>(result[number, j]).ToList<int>();
                                tempList.Add(number);

                            }
                        }
                        result[i, j] = tempList;
                    }
                }
            }

            List<int> l = result[0, 12];
            foreach (int item in l)
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// 按照 index找到 匹配的值
        /// </summary>
        /// <param name="s">活动开始时间</param>
        /// <param name="f">活动结束时间</param>
        /// <param name="index">下标</param>
        static Dictionary<int,int> ActivitySelect(int[] s,int [] f,int index)
        {
            Dictionary<int, int> res =new Dictionary<int, int>()  ;
            res.Add(s[index], f[index]);
         
            for (int i = 0; i <f.Length; i++)
            {
              
                if (s[i]>=f[index])
                {
                    res.Add(s[i], f[i]);
                    index = i;
                     
                }
            }

 
            return res;
        }
    }
}

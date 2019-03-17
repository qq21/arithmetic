using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 最大子数组问题_分治法
{
    struct MaxSubArray
    {
        public int startIndex;
        public int endIndex;
        public int total;
    }

    class Program
    {


        static void Main(string[] args)
        {
            int[] arrary = new int[] { 100, 113, 110, 85, 105, 102, 86, 63, 81, 101, 94, 106, 101, 79, 94, 90, 97 };

            int[] minRes = new int[arrary.Length - 1];

            for (int i = 0; i < arrary.Length - 1; i++)
            {
                minRes[i] = arrary[i + 1] - arrary[i];
            }

            MaxSubArray subArray = GetMaxSubArray(0, minRes.Length - 1, minRes);

            Console.WriteLine(subArray.startIndex);
            Console.WriteLine(subArray.endIndex);
            Console.WriteLine(subArray.startIndex + "天买入,在第" + subArray.endIndex + 1 + "卖出");

        }

        /// <summary>
        /// 暴力求解
        /// </summary>
        /// <param name="arrary"></param>
        /// <returns></returns>
        public int[] MaxProfit(int[] arrary)
        {
            int[] res;

            int[] minRes = new int[arrary.Length - 1];

            for (int i = 0; i < arrary.Length - 1; i++)
            {
                minRes[i] = arrary[i + 1] - arrary[i];
            }

            int minIndex = 0;
            int maxIndex = 0;
            int Max = minRes[0];

            for (int i = 0; i < minRes.Length; i++)
            {

                for (int j = i; j < minRes.Length; j++)
                {
                    //由i j就确定了一个和子数组 
                    int totalTemp = 0;//临时最大子数组的和

                    for (int k = i; k < j + 1; k++)//遍历 从i加到 j  包含 j  因此j+1 或者 <=
                    {
                        totalTemp += minRes[k];
                    }

                    if (totalTemp > Max)
                    {
                        Max = totalTemp;
                        minIndex = i;
                        maxIndex = j;
                    }

                }

            }

            return new int[] { minIndex, maxIndex + 1 };
        }

        /// <summary>
        /// 暴力破解
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public int[] MaxOutCome(int[] array)
        {
            int[] mins = new int[array.Length - 1];

            int MaxIndex = 0;
            int MinIndex = 0;
            int Total = 0;
            for (int i = 0; i < array.Length - 1; i++)//最后一次不用 没得减
            {
                mins[i] = array[i + 1] - array[i];
            }

            for (int i = 0; i < mins.Length; i++)//遍历下 差  数组
            {
                for (int j = i; j < mins.Length; j++)//从i 到length 依次遍历 0~L 1~L ....L-1~L;
                {
                    int temp = 0;
                    for (int k = i; k <= j; k++)//  从i 到 j 依次 累加  再 进行判断 和是否 比total 大   j也要加 进去 
                    {
                        temp += mins[k];
                    }
                    if (temp > Total)
                    {
                        Total = temp;
                        MaxIndex = j;
                        MinIndex = i;
                    }
                }
            }

            //遍历  结束 返回  下标
            return new int[] { MinIndex, MaxIndex + 1 };//卖出 那一天 要 加上1 得到 从Minindex  到MaxIndex +1 之间   最大最大数组是[MinIndex,MaxIndex]
        }

        public static MaxSubArray GetMaxSubArray(int low, int high, int[] arrary)
        {

            if (low == high)
            {
                MaxSubArray maxSubArray;
                maxSubArray.startIndex = low;
                maxSubArray.endIndex = high;
                maxSubArray.total = arrary[low];
                return maxSubArray;
            }

            int mid = (low + high) / 2;//低 区间[low,mid]  高区间 [mid+1，high]

            MaxSubArray maxSubArray1 = GetMaxSubArray(low, mid, arrary);

            MaxSubArray maxSubArray2 = GetMaxSubArray(mid + 1, high, arrary);

            //从[low,mid] 找到最大子数组[i,mid]  从mid 到0(low)遍历
            int total = arrary[mid];
            int tempTot = 0;
            int StartIndex = mid;
            for (int i = mid; i >= low; i--)
            {
                tempTot += arrary[i];
                if (tempTot > total)
                {
                    total = tempTot;
                    StartIndex = i;
                }
            }

            //从[mid+1,hight] 找到最大子数组[mid+1,j];
            int total2 = arrary[mid + 1];
            int endIndex = mid + 1;
            tempTot = 0;
            for (int i = mid + 1; i <= high; i++)
            {
                tempTot += arrary[i];
                if (tempTot > total2)
                {
                    total2 = tempTot;
                    endIndex = i;
                }
            }

            MaxSubArray subArray3;
            subArray3.startIndex = StartIndex;
            subArray3.endIndex = endIndex;
            subArray3.total = total + total2;

            if (maxSubArray1.total >= maxSubArray2.total && maxSubArray1.total >= subArray3.total)
            {
                return maxSubArray1;
            }
            else if (maxSubArray2.total > maxSubArray1.total && maxSubArray2.total > subArray3.total)
            {
                return maxSubArray2;
            }
            else
            {
                return subArray3;
            }
        }

        /// <summary>
        /// 递归 分治 
        /// </summary>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <param name="array"></param>
        /// <returns></returns>
        public MaxSubArray MaxSubArray2(int low,int high,int[] array)
        {
            //结束 条件
            if (low==high)
            {
                MaxSubArray maxSubArray;
                maxSubArray.startIndex = low;
                maxSubArray.endIndex = high;
                maxSubArray.total = array[low];
                return maxSubArray;
            }

            int mid = (low + high) / 2;//分区

            MaxSubArray subArray1 = MaxSubArray2(low, mid, array);//左边的     情况1
            MaxSubArray subArray2 = MaxSubArray2(mid+1,high, array);//右边的   情况2


            //   情况3
            // 左边 寻找
            int total = array[low];
            int startIndex = low;
            int temp = 0;
            for (int i = low; i <=mid; i++)
            {

                temp += array[i];
                if (temp>total)
                {
                    total = temp;
                    startIndex = i;
                }
            }

            //右边 寻找
            int total2 = array[mid + 1];
            int endIndex = mid + 1;
             temp = 0;
            for (int i = mid+1; i <high; i++)
            {
                total2 += array[i];
                if (temp>total2)
                {
                    total2 = temp;
                    endIndex = i;
                }
            }

            //   情况3
            MaxSubArray SubArray3;
            SubArray3.startIndex = startIndex;
            SubArray3.endIndex = endIndex;
            SubArray3.total = total + total2;

            if (subArray1.total > subArray2.total && subArray1.total > SubArray3.total)
            {
                return subArray1;
            }
            else if (subArray2.total > subArray1.total&&subArray2.total>SubArray3.total)
            {
                return subArray2;
            }
            else
            {
                return SubArray3;
            }


        }

    }
}

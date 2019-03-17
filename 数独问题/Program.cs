using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 数独问题
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 测试


            int[,] nums = new int[9, 9];
            int k = 0;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    nums[j, i] = ++k;
                    if (k < 10)
                    {
                        Console.Write("0" + k + "   ");
                    }
                    else
                    {
                        Console.Write(k + "   ");
                    }
                }
                Console.WriteLine();
            }
            List<int> vs = new List<int>();
 

            Console.WriteLine(); Console.WriteLine();
            int count = 0;


            for (int i = 0; i < 9; i++)
            {
                for (int h = 0; h < 3; h++)
                {

                }
                for (int j = 0; j <3; j++)
                {
                    Console.Write(nums[j, i]+" ");
                    
                }
                if ((i + 1) % 3 == 0)
                {
                    Console.WriteLine("_____________________________________");
                }
            }

            Console.WriteLine("_____________________________________");
            for (int i = 0; i < 9; i++)
            {
                for (int j = 3; j < 6; j++)
                {
                    Console.Write(nums[j, i] + " ");
                }
                if ((i + 1) % 3 == 0)
                {
                    Console.WriteLine("_____________________________________");
                }
            }
            Console.WriteLine("_____________________________________");
            for (int i = 0; i < 9; i++)
            {
                for (int j = 6; j < 9; j++)
                {
                    Console.Write(nums[j, i] + " ");
                }
                if ((i + 1) % 3 == 0)
                {
                    Console.WriteLine("_____________________________________");
                }
            }
            #endregion


        }
        public static bool IsValidSudoku(char[,] board)
        {
            //思路2 3个列表 

            //思路1
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {

                    for (int k = 0; k < 9; k++)
                    {
                        // 行 比较
                        if (board[i, j] != '.' && board[i, j] == board[i, k] && j != k)
                        {
                            return false;
                        }
                        //列的比较
                        if (board[j, i] == board[k, i] && j != k && board[k, i] != '.')
                        {
                            Console.Write(board[j, i]);
                            return false;
                        }
                    }

                }
            }
            List<int> vs = new List<int>();
            for (int tk = 1; tk < 4; tk++)//1 2 3
            {
                for (int i = (tk - 1) * 3; i < 3 * tk; i++)
                {
                    for (int j = (tk - 1) * 3; j < 3 * tk; j++)
                    {
                        if (board[i, j] != '.')
                        {
                            if (vs.Contains((int)board[i, j]))
                            {

                                return false;
                            }

                            vs.Add((int)board[i, j]);
                        }
                    }

                }
                vs.Clear();
            }
            return true;
        }
    }
}

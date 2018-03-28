using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Array
{
    /// <summary>
    /// All Algo related to Array 
    /// </summary>
    public class ArrayAlgo
    {
        /// <summary>
        /// Using Sorting method O(n^2) 
        /// </summary>
        /// <param name="Array">Input Array</param>
        /// <param name="k">Kth msallest number/element</param>
        /// <returns></returns>
        public int FindKthSmallestElement(int []Array, int k)
        {
            for (int i = 0; i < Array.Length; i++)
            {
                for (int j = i + 1; j < Array.Length; j++)
                {
                    if(Array[i] > Array[j])
                    {
                        var tmp = Array[j];
                        Array[j] = Array[i];
                        Array[i] = tmp;
                    }
                }
            }
            return Array[k];
        }


        /// <summary>
        /// Program to Convert Decimal to Binary
        /// </summary>
        /// <param name="Value">Input </param>
        /// <returns>Binary sequence </returns>
        public string DecimalToBinary(int Value)
        {
            Stack<int> Stk = new Stack<int>();
            String result = string.Empty;

            while (Value > 0)
            {
                int n = Value % 10;
                Value = Value / 10;
                Stk.Push(n);
            }
            while (Stk.Count >0 )
            {
                result += Stk.Pop();
            }
            return result;
        }
        
        public int FindSumOfAllElement(int []Array, int Index = 0, int Sum =0)
        {
            if (Index == Array.Length)
                return Sum;
            else
            {
                Sum += Array[Index];
                return FindSumOfAllElement(Array, ++Index, Sum);
            }
        }

        /// <summary>
        /// Program of Pascal Triangle
        /// </summary>
        /// <param name="Dim">Number of rows and columns of the triangle</param>
        public void PascalTriangle(int Dim)
        {
            int[,] Array = new int[Dim, Dim];
            for (int i = 0; i < Dim; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    if (i == j || j == 0)
                        Array[i, j] = 1;
                    else
                        Array[i, j] = Array[i - 1, j - 1] + Array[i - 1, j];
                }
            }

            //Printing of pascal triangle
            for (int i = 0; i < Dim; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Console.Write(Array[i, j] + " ");
                }
                Console.WriteLine("\n");
            }
        }

        /// <summary>
        /// Printing of Pascal Triangle for String
        /// </summary>
        /// <param name="Value"></param>
        public void PrintStringInPascalTriangle(string Value)
        {
            for (int i = 0; i < Value.Length; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Console.Write(Value[j]);
                }
                Console.WriteLine("\n");
            }
        }

        /// <summary>
        /// Sort Odd and Even number in Array
        /// {1,2,3,4,6,8,7,12} => [12, 2, 8, 4, 6, 3, 7, 1]
        /// Bring all Even number in left and Odd number in right
        /// </summary>
        /// <param name="Array"></param>
        public int[] SaperateOddAndEven(int []Array)
        {
            int Start = 0;
            int End = Array.Length - 1;

            while (Start < End)
            {
                if(Array[Start] %2 != 0 && Array[End] %2 == 0)
                {
                    int tmp = Array[Start];
                    Array[Start] = Array[End];
                    Array[End] = tmp;
                }
                if (Array[Start] % 2 == 0)
                    ++Start;

                if (Array[End] % 2 != 0)
                    --End;
            }
            return Array;
        }

        /// <summary>
        /// Find Two numbers in array whose sum is equal to some third number
        /// The  ARRAY MUST BE SORTED to implement same
        /// </summary>
        /// <param name="Array"></param>
        /// <returns></returns>
        public List<KeyValuePair<int,int>> FindTwoSumInArray(int []Array , int Number)
        {
            int Start = 0 , End = Array.Length -1;
            List<KeyValuePair<int, int>> Pair = new List<KeyValuePair<int, int>>();

            while (Start < End)
            {
                int Sum = Array[Start] + Array[End];
                if (Sum == Number)
                    Pair.Add(new KeyValuePair<int, int>(Array[Start], Array[End]));

                if (Sum > Number)
                    --End;

                if (Sum < Number)
                    ++Start;
            }
            return Pair;
        }


        /// <summary>
        /// Function is to return the closest value to a given number. Brute force method - O(n)
        /// 
        /// </summary>
        /// <param name="Array"></param>
        /// <returns></returns>
        public int FindNearestElement(int []Array, int Number)
        {
            int SmallIndex = 0;
            int SmallDiff =  Number - Array[0];

            if (SmallDiff < 0)
                SmallDiff = -SmallDiff;

            for (int i = 1; i < Array.Length; i++)
            {
                var tmp =  Number - Array[i];
                if (tmp < 0)
                    tmp = -tmp;

                if (tmp == 0)
                {
                    SmallIndex = i;
                    break;
                }
                if (tmp < SmallDiff)
                {
                    SmallDiff = tmp;
                    SmallIndex = i;
                }
            }
            return Array[SmallIndex];
        }

        /// <summary>
        /// Find nearest element from a sorted array.
        /// </summary>
        /// <param name="Array"></param>
        /// <param name="Number"></param>
        /// <returns></returns>
        public int FindNearestElementOfSortedArray(int []Array, int Number)
        {
            int i, j , min = -1;
            bool IsMatch = false;

            //Checking if item is out of cover

            if (Number > Array[Array.Length - 1])
                return Array[Array.Length - 1];

            if (Number < Array[0])
                return Array[0];

            for (i = 0 , j = Array.Length -1; i < Array.Length;)
            {
                if (Array[i] - Number == 0)
                {
                    min = Array[i];
                    IsMatch = true;
                }

                else if (Array[j] - Number == 0)
                {
                    min = Array[j];
                    IsMatch = true;
                }

                else if (Array[i] < Number && Array[j] > Number) {
                    ++i; --j;
                }
                else
                {
                    min = Array[ Math.Min((Array[i] - Number) < 0 ? -(Array[i] - Number) : (Array[i] - Number), (Array[j] - Number) < 0 ? -(Array[j] - Number) : (Array[j] - Number))];
                    IsMatch = true;
                }

                if (IsMatch)
                    break;
            }

            return min;
        }

    }
}

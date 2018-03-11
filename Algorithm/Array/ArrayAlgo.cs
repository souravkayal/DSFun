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
    }
}

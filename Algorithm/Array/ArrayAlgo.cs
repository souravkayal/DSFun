using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Array
{
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
        

       
    }
}

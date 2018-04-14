using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Searching
{
    public class SearchAlgo
    {
        /// <summary>
        /// Program of linear search- O(n)
        /// </summary>
        /// <param name="Array">Input</param>
        /// <param name="n">Search Element</param>
        /// <returns>result</returns>
        public bool LinearSearch(int []Array, int n)
        {
            bool result = false;
            for (int i = 0; i < Array.Length; i++)
            {
                if (Array[i] == n)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }


        /// <summary>
        /// Program of Binary Search O(logn)
        /// </summary>
        /// <param name="Array">Input Array</param>
        /// <param name="n">search element</param>
        /// <returns>result</returns>
        public bool BinarySearch(int []Array, int n)
        {
            int beg = 0, end = Array.Length - 1;
            bool result = false;

            while (beg <= end)
            {
               int mid = (beg + end) / 2;
               if (Array[mid] == n)
                {
                    result = true;
                    break;
                }
                else
                {
                    if (Array[mid] > n)
                        end = mid - 1;
                    else
                        beg = mid + 1;
                }
            }
            return result;
        }
    }
}

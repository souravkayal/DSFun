using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Sorting
{
    /// <summary>
    /// 
    /// </summary>
    public class BucketSort
    {
        public int[] SortElements(int []Array)
        {
            for (int i = 0; i < Array.Length; i++)
            {
                for (int j = i+1; j < Array.Length; j++)
                {
                    int tmp = Array[i];
                    Array[i] = Array[j];
                    Array[j] = tmp;
                }
            }
            return Array;
        }

        public List<int> BucketSortFun(int []Array)
        {
            //decleration 
            int NumberOfBucket = 10;
            List<int> Result = new List<int>();
            List<int>[] Buckets = new List<int>[NumberOfBucket];

            //distribution
            for (int i = 0; i < Array.Length; i++)
            {
                int BucketIndex = (Array[i] % NumberOfBucket);
                Buckets[BucketIndex].Add(Array[i]);
            }

            for (int i = 0; i < NumberOfBucket; i++)
            {
                var items = Buckets[i];
                //int[] SortedResult = ;
                Result.AddRange(SortElements(items.ToArray()));
            }
            return Result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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


        /// <summary>
        /// Function is to evaluate simple Expression
        /// </summary>
        /// <param name="Expression">3+4-7+13</param>
        /// <returns>13</returns>
        public int EvaludateExpression(string Expression)
        {

            // Regex.Split(strmsg, @"(?<=[}])").Where((s, i) => s != "").ToArray();
            //Regex.Split(input, @"([RK])")

            string[] Array = Regex.Split(Expression, @"([+-])").Where((s, i) => s != "").ToArray();

            int sum = Convert.ToInt32(Array[0]);

            for (int i =1 ; i< Array.Length; i+=2)
            {
                string Exp = Array[i];
                int value = Convert.ToInt32(Array[i+1]);

                if (Exp == "+")
                    sum = sum + value;
                else
                    sum = sum - value;
            }
            return sum;
        }


        public int EvaluateDigitCountInNumber(int Number, int Digit)
        {
            if (Number == 0 && Digit == 0)
                return 1;

            int Count = 0;
            while (Number > 0)
            {
                int Remender = Number % 10;

                if (Remender == Digit)
                    ++Count;
                Number = Number / 10;
            }
            return Count;
        }

        /// <summary>
        /// Function  to return apperence of digit in array 
        /// </summary>
        /// <param name="Array">[0,10]</param>
        /// <param name="Digit">0</param>
        /// <returns>2</returns>
        public int CountNumberOfApparence(int []Array , int Digit)
        {
            int Count = 0;
            foreach (var item in Array)
            {
                Count += EvaluateDigitCountInNumber(item, Digit);
            }
            return Count;
        }


        /// <summary>
        /// Input : [0,1,0,0,1,0] => [0,0,0,0,1,1]
        /// </summary>
        /// <param name="Array"></param>
        public int[] SaperateZeroAndOne(int []Array)
        {
            int i = 0, j = Array.Length - 1;
            while (i<j)
            {
                if (Array[i] == 0 && Array[j] == 1)
                {
                    ++i;
                    --j;
                }
                else if (Array[i] == 0)
                    ++i;
                else if (Array[j] == 1)
                    --j;
                else if(Array[i] == 1 && Array[j] == 0)
                {
                    int t = Array[i];
                    Array[i] = Array[j];
                    Array[j] = t;

                    ++i;
                    --j;
                }
            }
            return Array;
        }

        /// <summary>
        /// Rotate array for n number
        /// </summary>
        /// <param name="Array"></param>
        public int [] ArrayRotation(int []Array , int n)
        {
            for (int i = 0; i < n; i++)
            {
                int temp = Array[0];

                for (int j = 1; j < Array.Length ; j++)
                {
                    Array[j - 1] = Array[j];
                }
                Array[Array.Length - 1] = temp;
            }
            return Array;
        }

        
        /// <summary>
        /// Program of binary search
        /// </summary>
        /// <param name="Array">Sorted Array </param>
        /// <param name="Value">Search Element</param>
        /// <returns></returns>
        public bool BinarySearch(int []Array, int Value)
        {
            int beg = 0, end = Array.Length - 1;

            while (beg <= end)
            {
                int mid = (beg + end) / 2;

                if (Array[mid] == Value)
                    return true;

                if (Array[mid] < Value)
                    beg = mid +1;
                else
                    end = mid -1;
            }
            return false;
        }


        /// <summary>
        /// Find Rotation point of Array
        /// </summary>
        /// <param name="Array">[4,5,6,1,2,3]</param>
        /// <returns>3</returns>
        public int FindPivotPointOfArray(int []Array)
        {
            int last = Array.Length - 1;
            int prelast = Array.Length - 2;

            while (prelast >= 0 && Array[last] > Array[prelast] )
            {
                --last;
                --prelast;
            }
            return last;
        }

        /// <summary>
        /// Find Rotation Count in Rotated sorted Array
        /// </summary>
        /// <param name="Array">{15, 18, 2, 3, 6, 12}</param>
        /// <returns>2</returns>
        public int FindRottionCount(int []Array)
        {
            int i = 0;
            for ( ; i < Array.Length-1 ; i++)
            {
                if (Array[i] > Array[i + 1])
                    break;
            }
            return i ;
        }

        /// <summary>
        /// Program to arrange negative and positive number
        /// </summary>
        /// <param name="Array">Input aray : [1,-4,5,6,2,-7]</param>
        /// <returns>[-4,-7,1,5,6,2]-</returns>
        public int[] ArrangeNegativeAndPositiveNumber(int []Array)
        {
            int start = 0, end = Array.Length - 1;
            while (start < end)
            {
                if(Array[start] <0 && Array[end] > 0)
                {
                    ++start;
                    --end;
                }
                else if(Array[start] >0 && Array[end] <0)
                {
                    int tmp = Array[start];
                    Array[start] = Array[end];
                    Array[end] = tmp;

                    ++start;
                    --end;
                }
                else if (Array[start] < 0)
                    ++start;
                else if (Array[end] > 0)
                    --end;
            }
            return Array;
        }


        /// <summary>
        /// Function to alternate array element
        /// </summary>
        /// <param name="Array">[1,2,3,4,5,6]</param>
        /// <returns>[2,1,4,3,6,5]</returns>
        public int [] AlternateArrayElement(int []Array)
        {
            int first = 0, second = 1;

            while (second < Array.Length)
            {
                int tmp = Array[first];
                Array[first] = Array[second];
                Array[second] = tmp;

                first += 2;
                second +=2;
            }
            return Array;
        }


        /// <summary>
        /// Sorted array is input 
        /// </summary>
        /// <param name="Array">{1, 2, 3, 4, 5, 6} </param>
        /// <returns>{1,6,2,5,3,4}</returns>
        public int [] ArrangeArrayInMinMaxValue(int []Array)
        {
            int start = 0, end = Array.Length - 1 , Index = 0;
            int[] ArrayTmp = new int[Array.Length];

            for (int i = 0; i < Array.Length/ 2; i++)
            {
                ArrayTmp[Index] = Array[start];
                ArrayTmp[Index + 1] = Array[end];

                Index += 2;
                ++start;
                --end;
            }
            return ArrayTmp;
        }

        /// <summary>
        /// Function to replace every element of array by it's right greatest element - O(n^2)
        /// </summary>
        /// <param name="Array">Input array</param>
        /// <returns>modified array</returns>
        public int [] ReplaceEveryElementByGratestElementFromRight_n2(int []Array)
        {
            ///O(n^2) complexcity
            for (int i = 0; i < Array.Length ; i++)
            {
                int j = i + 1;
                if (j >= Array.Length)
                    break;

                int big = Array[j];
                for (; j < Array.Length; j++)
                {
                    if (Array[j] > big)
                        big = Array[j];
                }
                Array[i] = big;
            }
            return Array;
        }


        /// <summary>
        /// Function to replace every element of array by it's right greatest element - O(n)
        /// </summary>
        /// <param name="Array">Input array</param>
        /// <returns>modified array</returns>
        public int [] ReplaceEveryElementByGratestElementFromRight_n(int []Array)
        {
            int big = Array[Array.Length - 1];
            for (int i = Array.Length -2; i >= 0; i--)
            {
                int current = Array[i];

                int k = i + 1;
                if (Array[k] > big)
                    big = Array[k];

                Array[i] = big;
                if (current > big)
                    big = current;
            }

            return Array;
        }

        //Suffle array by equal probablity distribution


        /// <summary>
        /// https://www.geeksforgeeks.org/constant-time-range-add-operation-array/
        /// </summary>
        /// <param name="Array"></param>
        /// <returns></returns>
        public int [] ConstantTimeRangeAddOperation(int []Array , List<Tuple<int,int,int>> Ranges)
        {
            for (int i = 0; i <Ranges.Count; i++)
            {
                //int Start = Ranges[i].Item1;
                //int End = Ranges[i].Item2;
                for (int j = Ranges[i].Item1; j < Ranges[i].Item2; j++)
                {
                    Array[j] += Ranges[i].Item3;
                }
            }

            return Array;
        }
        
        
        /// <summary>
        /// Mountain will form , if array comes first increasing and then decreasing Order
        /// </summary>
        /// <param name="Array">[1,3,5,6,5,3,2]</param>
        /// <returns>true</returns>
        public bool FindWhetherArrayFormedMountain(int []Array)
        {
            //find pivot point
            //check left elements in pivot point
            //check right elements in pivot point
            int pivot = 0;

            for (int i = 0; i < Array.Length -2; i++)
            {
                if (Array[i] > Array[i + 1])
                {
                    pivot = i; 
                    break;
                }
            }
            //check left side of pivot 
            
            for (int i = 0; i < pivot-1; i++)
            {
                if (Array[i] > Array[i + 1])
                    return false;
            }
            //check right side of pivot

            for (int i = pivot +1; i < Array.Length -1; i++)
            {
                if (Array[i] < Array[i + 1])
                    return false;
            }
            return true;
        }


        /// <summary>
        /// Check whether binary representation of decimal is odd or even number.
        /// When there is 1 in right most digit it's odd number otherwise even number
        /// </summary>
        /// <param name="Array"></param>
        /// <returns></returns>
        public string CheckBinaryArrayForOddOrEvenInDecimal(int []Array)
        {
            return Array[Array.Length - 1] == 1 ? "Odd" : "Even";
        }


        /// <summary>
        /// Suffle an input array and print it.
        /// </summary>
        /// <param name="Array"></param>
        public void SuffleTheInputArray(int []Array)
        {
            for (int i = 0; i < Array.Length; i++)
            {
                int Rand = new Random().Next(0, 100) % (Array.Length - i);

                int tmp = Array[i];
                Array[i] = Array[Rand];
                Array[Rand] = tmp;
            }

            foreach (var item in Array)
            {
                Console.Write(item + " ");
            }
        }


    }
}

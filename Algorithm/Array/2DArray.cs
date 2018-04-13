using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Array
{
    public class TwoDArray
    {

        /// <summary>
        /// Program to print 2D array
        /// </summary>
        /// <param name="Array"></param>
        public void PrintTwoDArray(int [,] Array)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(Array[i, j]);
                }
                Console.WriteLine("\n");
            }
        }


        /// <summary>
        /// Program to 
        /// </summary>
        /// <param name="Array"></param>
        /// <param name="n"></param>
        public void PrintOnlyDiagonalElement(int [,]Array , int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if ((i == j) || (i+j) == n-1)
                        Console.Write(Array[i, j]);
                }
            }
        }

        /// <summary>
        /// Program to print transpose of matrix
        /// </summary>
        /// <param name="Array"></param>
        /// <param name="n"></param>
        public void TransposeOfMatrix(int [,]Array , int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(Array[j, i]);
                }
                Console.WriteLine("\n");
            }
        }

        /// <summary>
        /// Pascal Triangle
        /// </summary>
        /// <param name="n"></param>
        public void PrintPascalTriangle(int n)
        {
            int[,] Array = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (i == j || j == 0)
                        Array[i, j] = 1;
                    else
                        Array[i, j] = Array[i - 1, j - 1] + Array[i - 1, j];
                }
            }

            //PRINT 
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write(Array[i, j] + " ");
                }
                Console.WriteLine("\n");
            }
        }

        /// <summary>
        /// Swap the matrix element across diagonal element
        /// </summary>
        /// <param name="Array"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public int [,] SwapElementAcrossDiagonal(int [,]Array, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if(i != j)
                    {
                        int t = Array[i, j];
                        Array[i, j] = Array[j, i];
                        Array[j, i] = t;
                    }
                }
            }
            return Array;
        }

    }
}

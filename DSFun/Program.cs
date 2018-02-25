using DS.LinkedListWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DS.Model;
using ImplementationFun;
using Algorithm.Recursion;
using Algorithm.StackAlgo;
using DS.Hashing;
using System.Globalization;
using Algorithm.Array;

namespace DSFun
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayAlgo algo = new ArrayAlgo();

            Console.WriteLine(algo.FindSumOfAllElement(new int[] { 1, 4, 6, 2 }));


            Console.ReadLine();
        }
    }
}

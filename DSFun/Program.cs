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
using DS.Tree;
using DS.Graph;

namespace DSFun
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayAlgo Obj = new ArrayAlgo();
            var result = Obj.SaperateOddAndEven(new int[] { 1, 2, 3, 4, 6, 8, 7, 12 });

            Console.ReadLine();
        }
    }
}

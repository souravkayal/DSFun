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
            GraphRepresentationUsingMatrix Obj = new GraphRepresentationUsingMatrix();
            Dictionary<int, int[]> Array = new Dictionary<int, int[]>();
            Array.Add(1, new[] { 2 , 3});
            Array.Add(2, new[] { 3 });
            Array.Add(3, new[] { 4 });

            //Obj.CreateGraph(Array, 4);
            //Obj.Print();

            Obj.CreateGraph(Array);
            Obj.PrintList();


            Console.ReadLine();
        }
    }
}

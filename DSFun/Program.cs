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
using DS.LinkedList;
using ImplementationFun.EmployeeHierarchy;
using ImplementationFun.ProductCatalogue;
using Algorithm.Searching;

namespace DSFun
{
    class Program
    {
        static void Main(string[] args)
        {
            SearchAlgo Obj = new SearchAlgo();

            var result = Obj.BinarySearch(new[] {1,3,5,7,9,10 }, 25);

            Console.ReadLine();
        }
    }
}

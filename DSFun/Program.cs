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

namespace DSFun
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayAlgo Obj = new ArrayAlgo();
            var result = Obj.FindWhetherArrayFormedMountain(new[] { 2, 4, 1, 6, 3, 2 });


            Console.ReadLine();
        }
    }
}

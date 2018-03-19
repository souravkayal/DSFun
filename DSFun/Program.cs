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

namespace DSFun
{
    class Program
    {
        static void Main(string[] args)
        {

            LinkedListRecursion Obj = new LinkedListRecursion();
            Obj.AddItem(Obj.Head, new LinkedNode { Value = 1 });
            Obj.AddItem(Obj.Head, new LinkedNode { Value = 2 });
            Obj.AddItem(Obj.Head, new LinkedNode { Value = 3 });
            
            Obj.DeleteLinkedList(ref Obj.Head);




            Console.ReadLine();
        }
    }
}

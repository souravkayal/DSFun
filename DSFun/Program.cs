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

namespace DSFun
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree bt = new BinaryTree(new TreeNode { Value = 10 });
            bt.AddNode(bt.Root, new TreeNode { Value = 7 });
            bt.AddNode(bt.Root, new TreeNode { Value = 8 });
            bt.AddNode(bt.Root, new TreeNode { Value = 4 });
            bt.AddNode(bt.Root, new TreeNode { Value = 15 });


            BinaryTreeAlgo btalgo = new BinaryTreeAlgo(bt);
            btalgo.Print(bt.Root);


            Console.ReadLine();
        }
    }
}

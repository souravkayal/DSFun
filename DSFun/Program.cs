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
                    
            CatTree Obj = new CatTree(new Category { Id = -1, ParentId = 0, NodeName = "GlobalRoot" });
            Obj.AddAllCategory(new List<Category>
            {
                new Category { Id = 10, ParentId = 1, NodeName = "Commedy Book"},
                new Category { Id = 20, ParentId = 2, NodeName = "Tablets"},
                new Category { Id = 1, ParentId = -1, NodeName = "Books"},
                new Category { Id = 11, ParentId = 1, NodeName = "Novels"},
                new Category { Id = 12, ParentId = 11, NodeName = "Terror Novel"},
                new Category { Id = 2, ParentId = -1, NodeName = "Electronics"},
            });

            Obj.BuildTree(Obj.Root);

            Console.ReadLine();
        }
    }
}

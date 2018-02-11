using DS.LinkedListWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DS.Model;

namespace DSFun
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList LinkedList = new LinkedList();
            LinkedList.AddNode(new LinkedNode { Value = 2 });
            LinkedList.AddNode(new LinkedNode { Value = 3 });
            LinkedList.AddNode(new LinkedNode { Value = 4 });

            //LinkedList.InsertNode(1, new LinkedNode { Value = 100 });
            //LinkedList.PrintList();

            //LinkedList.DeleteList();

        }
    }
}

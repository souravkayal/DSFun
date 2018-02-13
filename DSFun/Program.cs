using DS.LinkedListWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DS.Model;
using ImplementationFun;
using Algorithm.Recursion;

namespace DSFun
{
    class Program
    {
        static void Main(string[] args)
        {

            Recursion Obj = new Recursion();
            Console.Write(Obj.FindMaxValueInList(new[] {1,4,5,20,10 }));


            Console.ReadLine();
        }
    }
}

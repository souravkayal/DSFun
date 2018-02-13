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

            String s = "sourav";
            s = Obj.RiverseString(s);
            Console.WriteLine(s);


            Console.ReadLine();
        }
    }
}

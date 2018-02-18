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

namespace DSFun
{
    class Program
    {
        static void Main(string[] args)
        {
            StackAlgo Obj = new StackAlgo();
            Stack<int> Stack = new Stack<int>();
            Stack.Push(1);
            Stack.Push(2);
            Stack.Push(3);

            var result = Obj.RiverseStack(Stack);
            
            //Console.WriteLine(Obj.EvaluationOfPrefixExpression("+19*8"));

            Console.ReadLine();
        }
    }
}

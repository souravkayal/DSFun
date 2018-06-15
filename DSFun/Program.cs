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
using ImplementationFun.DesignPattern;
using Newtonsoft.Json;
using System.Threading;

namespace DSFunWork
{

    public class StackWork
    {
        public void InsertButtomInStack(Stack<int> Stk , int Data)
        {
            if(Stk.Count == 0)
            {
                Stk.Push(Data);
                return;
            }
            else
            {
                var item = Stk.Pop();
                InsertButtomInStack(Stk, Data);
                Stk.Push(item);
            }
        }
        public Stack<int> StackRiversal(Stack<int> Stk , Stack<int> EmptyStk)
        {
            if (Stk.Count == 0)
                return Stk;
            else
            {
                EmptyStk.Push(Stk.Pop());
                StackRiversal(Stk, EmptyStk);
                return EmptyStk;
            }
        }
    }

    public class QueueUsingStack
    {
        Stack<int> Stk1 = new Stack<int>(); 
        Stack<int> Stk2 = new Stack<int>();

        public void Enque(int Data)
        {
            Stk1.Push(Data);
        }
        public void Deque()
        {
            Stk2.Clear();
            while (Stk1.Count > 1)
            {
                Stk2.Push(Stk1.Pop());

            }
            var item = Stk1.Pop();

            while (Stk2.Count != 0)
            {
                Stk1.Push(Stk2.Pop());
            }
        }
        public void PrintQ()
        {
            Stk2.Clear();
            while (Stk1.Count != 0)
            {
                Stk2.Push(Stk1.Pop());
            }

            while (Stk2.Count !=0)
            {
                Console.Write(Stk2.Pop()  +" ");
            }
        }

    }

    public class SpecialStack
    {
        Stack<int> DataStk = new Stack<int>();
        Stack<int> MinStk = new Stack<int>();
        public void Push(int Value)
        {
            DataStk.Push(Value);
            if(MinStk.Count ==0)
            {
                MinStk.Push(Value);
            }
            else
            {
                var item = MinStk.Peek();
                if (item < Value)
                    MinStk.Push(item);
                else
                    MinStk.Push(Value);
            }
        }
        public int Pop()
        {
            if (DataStk.Count > 0)
            {

                MinStk.Pop();
                return DataStk.Pop();
            }
            else
                throw new Exception("Stack Underflow");
        }
    }
   
    public class TwoStackUsingArray
    {
        int[] Array;
        int Stk1Index = 0;
        int Stk2Index = 5;

        public TwoStackUsingArray(int Length)
        {
            Array = new int[Length];
        }

        public enum Stack
        {
            Stack1, Stack2
        }
       
        public void Push(Stack Stack , int Value)
        {
            if(Stack == Stack.Stack1)
            {
                if (Stk1Index < Array.Length / 2 - 1)
                {
                    ++Stk1Index;
                    Array[Stk1Index] = Value;
                }
                else
                    throw new Exception("Stack Overflow");
            }
            else if (Stack == Stack.Stack2)
            {
                if (Stk2Index < Array.Length - 1)
                {
                    ++Stk2Index;
                    Array[Stk2Index] = Value;
                }
                else
                    throw new Exception("Stack Overflow");
            }
        }

        public void Pop(Stack Stk)
        {
            if(Stk == Stack.Stack1)
            {
                var item = Array[Stk1Index];
                if (Stk1Index > 0)
                    --Stk1Index;
            }
            else if(Stk == Stack.Stack2)
            {
                var item = Array[Stk2Index];
                if (Stk2Index < Array.Length - 1)
                    --Stk2Index;
            }
        }

    }



    class Program
    {
        static void Main(string[] args)
        {
           
            Console.ReadLine();
        }
    }
}

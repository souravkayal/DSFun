using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.Stack
{
    public class Stack
    {
        public void InsertButtomInStack(Stack<int> Stk, int Data)
        {
            if (Stk.Count == 0)
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

        public Stack<int> StackRiversal(Stack<int> Stk, Stack<int> EmptyStk)
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

            while (Stk2.Count != 0)
            {
                Console.Write(Stk2.Pop() + " ");
            }
        }

    }


}

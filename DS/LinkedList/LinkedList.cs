using DS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.LinkedListWork
{

    public class LinkedList
    {
        public LinkedNode Head { get; set; }
        public LinkedNode Tmp;

        public LinkedList()
        {
            this.Head = new LinkedNode();
        }

        public void AddNode(LinkedNode Item)
        {
            Tmp = this.Head;
            while (Tmp.Next != null)
            {
                Tmp = Tmp.Next;
            }

            Tmp.Next = Item;
        }

        public void PrintList()
        {
            Tmp = this.Head;
            while (Tmp != null)
            {
                Console.Write(Tmp.Value + "->");
                Tmp = Tmp.Next;
            }
            Console.ReadLine();
        }

        public void DeleteList()
        {
            Tmp = this.Head;
            LinkedNode NextTmp = this.Head.Next;

            while (NextTmp != null)
            {
                Tmp = null;
                Tmp = NextTmp;
                NextTmp = NextTmp.Next;
            }

            this.Head = null;
        }

        public int CountNodeInList()
        {
            int Count = 0;
            Tmp = this.Head;
            while (Tmp.Next != null)
            {
                ++Count;
                Tmp = Tmp.Next;
            }
            return Count;
        }

        public void InsertNode(int Index, LinkedNode Item)
        {
            int Count = 0;
            Tmp = this.Head;

            while (Tmp.Next != null && Count < Index) 
            {
                ++Count;
                Tmp = Tmp.Next;
            }

            if (Tmp != null)
            {
                var next = Tmp.Next;
                Tmp.Next = Item;
                Item.Next = next;
            }
            else
                throw new Exception("Invalid Index");
        }

        public void DeleteNode(int Index)
        {
            int Count = 0;
            Tmp = this.Head;

            while (Tmp.Next != null && Count < Index)
            {
                Tmp = Tmp.Next;
            }
            if (Tmp != null)
            {
                if(Tmp.Next != null)
                {
                    LinkedNode tmpNext = null;

                    if (Tmp.Next.Next != null)
                        tmpNext = Tmp.Next.Next;

                    Tmp.Next = tmpNext;
                }
            }
            else
                throw new Exception("Invalid Index");
        }

        public void SumOfAllNodes()
        {
            Tmp = this.Head;
            int Sum = 0;

            while (Tmp.Next != null)
            {
                Sum += Tmp.Value;
                Tmp = Tmp.Next;
            }
        }

        

    }
}

using DS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.LinkedList
{

    public class LinkedListRecursion
    {
        public LinkedNode Head;
        public LinkedListRecursion()
        {
            this.Head = new LinkedNode();
        }

        public void AddItem(LinkedNode Head, LinkedNode Item)
        {
            if (Head.Next == null)
            {
                Head.Next = Item;
            }
            else
                AddItem(Head.Next, Item);
        }

        public void Print(LinkedNode Head)
        {
            if (Head == null)
                return;
            else
            {
                Console.WriteLine(Head.Value);
                Print(Head.Next);
            }
        }

        public int  CountNodeInList(LinkedNode Head)
        {
            if (Head == null)
                return 0;
            else
                return 1 + CountNodeInList(Head.Next);
        }

        public int  SumOfAllNodes(LinkedNode Head)
        {
            if (Head == null)
                return 0;
            else
                return Head.Value + SumOfAllNodes(Head.Next);
        }

        public void InsertNodeAtNthPosition(LinkedNode Head, LinkedNode Item, int N , int IndexCount =0)
        {
            if(Head != null && IndexCount == N)
            {
                LinkedNode tmp = Head.Next;
                Head.Next = Item;
                Item.Next = tmp;
                return;
            }
            else
                InsertNodeAtNthPosition(Head.Next, Item, N, ++IndexCount);
        }

        public void DeleteNodeAtNthPosition(LinkedNode Head, int N, int IndexCount = 0)
        {
            if (Head != null && N == IndexCount)
            {
                if (Head.Next != null)
                {
                    Head.Next = Head.Next.Next;
                }
                return;
            }
            else
                DeleteNodeAtNthPosition(Head.Next, N, ++IndexCount);
        }

        public bool CompareValueOfTwoList(LinkedNode Head1, LinkedNode Head2)
        {
            if (Head1 != null && Head2 != null && (Head1.Value != Head2.Value))
                return false;
            else if (Head1 == null && Head2 == null)
                return true;
            return CompareValueOfTwoList(Head1.Next, Head2.Next);
        }

        public void DeleteLinkedList(ref LinkedNode Head)
        {
            if (Head == null)
                return;
            else
            {
                LinkedNode tmp = Head.Next;
                DeleteLinkedList(ref tmp);
                Head = null;
            }
        }
        
        /// <summary>
        /// The next pointer of last node will point ToThisNode
        /// </summary>
        /// <param name="ToThisNode"></param>
        public void SetCycleToList(LinkedNode Head, LinkedNode ToThisNode)
        {
            if (Head.Next == null)
                Head.Next = ToThisNode;
            else
                SetCycleToList(Head.Next, ToThisNode);
        }

        /// <summary>
        /// Detect cycle in Linked List using Two Pointers
        /// </summary>
        /// <param name="FirstPointer"></param>
        /// <param name="SlowPointer"></param>
        /// <returns></returns>
        public bool DetectCycleInList(LinkedNode FirstPointer, LinkedNode SlowPointer)
        {
            if (FirstPointer == SlowPointer)
                return true;

            else if (FirstPointer == null || SlowPointer == null)
                return false;

            return DetectCycleInList(FirstPointer.Next, SlowPointer.Next?.Next);
        }

        

    }
}

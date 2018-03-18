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

        //Function to detect cycle in linked list
        //Using List - O(n) Space complexcity
        public bool DetectCycleInLinkedList_ExtraSpace(LinkedNode List)
        {
            List<LinkedNode> LookUp = new List<LinkedNode>();
            LinkedNode tmp = List;
            while (tmp.Next != null)
            {
                if (LookUp.Contains(tmp))
                    return true;

                LookUp.Add(tmp);
                tmp = tmp.Next;
            }
            return false;
        }

        //Function to detect cycle in linked list
        //Using double pointer O(n) time O(1) space
        public bool DetectCycleInLinkedList_TwoPointer(LinkedNode Head)
        {
            LinkedNode ptrSlow = Head;
            LinkedNode ptrFast = Head?.Next?.Next;

            while (ptrFast != null)
            {
                if (ptrSlow == ptrFast) //There is cycle in list
                    return true;
                else
                {
                    ptrSlow = ptrSlow?.Next;
                    ptrFast = ptrFast?.Next?.Next;
                }
            }
            return false;
        }

        /// <summary>
        /// Find Common elements of 2 linked list
        /// </summary>
        /// <param name="Head1">Head node of 1st linked list</param>
        /// <param name="Head2">Head node of 2nd linked list</param>
        /// <returns></returns>
        public List<int> FindCommonOfTwoList(LinkedNode Head1 , LinkedNode Head2)
        {
            List<int> NodeList = new List<int>();
            List<int> CommonElement = new List<int>();

            LinkedNode tmp1 = Head1;
            while (tmp1.Next != null)
            {
                NodeList.Add(tmp1.Value);
                tmp1 = tmp1.Next;
            }

            tmp1 = Head2;
            while (tmp1.Next != null)
            {
                if (NodeList.Contains(tmp1.Value))
                {
                    CommonElement.Add(tmp1.Value);
                }
                tmp1 = tmp1.Next;
            }
            return CommonElement;
        }


        public void RiverseList()
        {
            LinkedNode Prev = null, Current = this.Head, Next = null;

            while (Current.Next != null)
            {
                Next = Current.Next;

                Current.Next = Prev;

                Prev = Current;
                Current = Next;
            }
        }


    }
}

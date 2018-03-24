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
        
        public bool SearchElementInList(int Item)
        {
            LinkedNode Tmp = this.Head;
            bool IsFound = false;

            while (Tmp.Next != null)
            {
                if (Tmp.Value == Item)
                {
                    IsFound = true;
                    break;
                }
                Tmp = Tmp.Next;
            }
            return IsFound;
        }
        
        public LinkedNode GetNthNodeFromLast(int N)
        {
            LinkedNode fastPointer = this.Head;
            LinkedNode slowPointer = this.Head;
            int Counter = 0;
            while (Counter < N && fastPointer.Next != null)
            {
                ++Counter;
                fastPointer = fastPointer.Next;
            }
            if (fastPointer.Next == null)
                throw new Exception("Invalid N");

            while (fastPointer.Next != null)
            {
                fastPointer = fastPointer.Next;
                slowPointer = slowPointer.Next;
            }
            return slowPointer;
        }

        //Function will assume that both list has same number of Nodes
        public LinkedNode MergeTwoListAlternateNode(LinkedNode Item1, LinkedNode Item2)
        {
            LinkedNode resultList = new LinkedNode();

            while (Item1.Next != null && Item2.Next != null)
            {
                //Take from List1
                resultList.Next = new LinkedNode { Value = Item1.Value };
                resultList = resultList.Next;
                resultList.Next = new LinkedNode { Value = Item2.Value };

                Item1 = Item1.Next;
                Item2 = Item2.Next;
            }

            return resultList;
        }

        /// <summary>
        /// Function to remove All occurance of certain number from list
        /// </summary>
        /// <param name="Value"></param>
        public void RemoveAllOccuranceOfAnElement(int Value)
        {
            LinkedNode Tmp = this.Head;

            while (Tmp != null && Tmp.Next != null)
            {
                if(Tmp.Next.Value == Value)
                {
                    var item = Tmp.Next;
                    while (item != null && item.Value == Value)
                    {
                        item = item.Next;
                    }
                    Tmp.Next = item;
                }

                else
                    Tmp = Tmp.Next;
            }
        }

        /// <summary>
        /// The function is to find the intersection of two lists. Hash set is used
        /// O(n) Space and O(n) time
        /// </summary>
        /// <param name="List1"></param>
        /// <param name="List2"></param>
        /// <returns></returns>
        public LinkedNode FindIntersectionOfTwoLists(LinkedNode List1, LinkedNode List2)
        {
            List<int> UniqueList = new List<int>();

            while (List1.Next != null)
            {
                if(!UniqueList.Contains(List1.Value))
                {
                    UniqueList.Add(List1.Value);
                }
                List1 = List1.Next;
            }

            while (List2.Next != null)
            {
                if (!UniqueList.Contains(List2.Value))
                {
                    UniqueList.Add(List1.Value);
                }
                List2 = List2.Next;
            }
            var tmp = this.Head;

            foreach (var item in UniqueList)
            {
                tmp.Next = new LinkedNode { Value = item };
                tmp = tmp.Next;
            }

            return this.Head;
        }

        public void RemoveAlternateElementInList()
        {

        }

    }
}

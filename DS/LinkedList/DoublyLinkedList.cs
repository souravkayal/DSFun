using DS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.LinkedList
{

    public class DoublyLinkedList
    {
        public LinkedNode Head { get; set; }

        public void AddNode(LinkedNode Item)
        {
            var tmp = this.Head;
            while (tmp.Next != null)
            {
                tmp = tmp.Next;
            }
            tmp.Next = Item;
            Item.Prev = tmp;
        }
        
        public void Print()
        {
            var tmp = this.Head;
            while (tmp.Next != null)
            {
                Console.Write(tmp.Value + " ");
                tmp = tmp.Next;
            }
        }


    }
}

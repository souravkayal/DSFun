using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.Graph
{
    /// <summary>
    /// Graph can be representated as adjacency matrix and adjacency list
    /// </summary>

    public class GraphRepresentation
    {
        int[,] Matrix;
        int DimCount;
        Dictionary<int, Node> AdjacencyList;

        public class Node
        {
            public int Value { get; set; }
            public Node Next { get; set; }
        }

        void AddItem(int Index , int[] Value)
        {
            this.AdjacencyList.Add(Index, new Node { Value = Value[0] });
            var item = this.AdjacencyList[Index];

            for (int i = 1; i < Value.Length; i++)
            {
                item.Next = new Node { Value = Value[i] };
                item = item.Next;
            }
        }
        public void CreateGraph(Dictionary<int,int[]> List)
        {
            this.AdjacencyList = new Dictionary<int, Node>();
            foreach (var index in List.Keys)
            {
                AddItem(index, List[index]);
            }
        }
        public void PrintList()
        {
            foreach (var item in this.AdjacencyList)
            {
                Console.Write(item.Key + "=>");
                var list = item.Value;

                while (list != null)
                {
                    Console.Write(list.Value + " ");
                    list = list.Next;
                }
                Console.WriteLine();
            }
        }


        //0 => 1, 2
        //1 => 2, 3
        public void CreateGraph(Dictionary<int, int[]> List , int n)
        {
            this.Matrix = new int[n, n];
            this.DimCount = n;
            foreach (var index in List.Keys)
            {
                foreach (var item in List[index])
                {
                    Matrix[index -1, item -1] = 1;
                }
            }
        }
        public void Print()
        {
            for (int i = 0; i < this.DimCount; i++)
            {
                for (int j = 0; j < this.DimCount; j++)
                {
                    Console.Write(Matrix[i, j] + "  ");
                }
                Console.WriteLine(" ");
            }
        }


        //OOP Representation of Graph
        public class Graph
        {
            public int Value { get; set; }
            public List<Graph> Connections { get; set; }
        }


    }
}

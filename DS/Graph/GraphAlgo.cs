using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.Graph
{
    public class Node
    {
        public int Value { get; set; }
        public List<Node> Connections { get; set; }
    }

    public class Graph
    {
        public List<Node> Nodes { get; set; }
        public Graph()
        {
            this.Nodes = new List<Node>();
        }
    }

    public class GraphAlgo
    {
        public void BredthFirstTraversal(Graph Graph)
        {
            List<Node> Visited = new List<Node>();
            Queue<Node> Queue = new Queue<Node>();
            Queue.Enqueue(Graph.Nodes[0]);
            while (Queue.Count >0)
            {
                var item = Queue.Dequeue();
                Console.Write(item.Value);
                Visited.Add(item);

                if(item.Connections != null)
                {
                    foreach (var node in item.Connections)
                    {
                        if (!Visited.Contains(node))
                        {
                            Queue.Enqueue(node);
                        }
                    }
                }
            }
        }
        public void DepthFirstTraversal(Graph Graph)
        {
            List<Node> Visited = new List<Node>();
            Stack<Node> Stack = new Stack<Node>();
            Stack.Push(Graph.Nodes[0]);
            while (Stack.Count > 0)
            {
                var item = Stack.Pop();
                Console.Write(item.Value);
                Visited.Add(item);
                if (item.Connections != null)
                {
                    foreach (var node in item.Connections)
                    {
                        if (!Visited.Contains(node))
                        {
                            Stack.Push(node);
                        }
                    }
                }
            }
        }
    }
}

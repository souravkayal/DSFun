using DS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.Tree
{

    public enum TraversalType
    {
        PreOrder, InOrder, PostOrder
    }

    public class BinaryTree
    {
        public TreeNode Root { get; set; }

        public BinaryTree(TreeNode RootNode)
        {
            this.Root = RootNode;
        }
        public void AddNode(TreeNode Root , TreeNode Item)
        {
            if(Root.Value > Item.Value)
            {
                if (Root.Left == null)
                    Root.Left = Item;
                else
                    AddNode(Root.Left, Item);
            }
            else
            {
                if (Root.Right == null)
                    Root.Right = Item;
                else
                    AddNode(Root.Right, Item);
            }
        }
        public void TraverseTree(TreeNode Root , TraversalType Type)
        {
            if (Root == null)
                return;

            switch (Type)
            {
                case TraversalType.PreOrder:
                    Console.Write(Root.Value);
                    TraverseTree(Root.Left, Type);
                    TraverseTree(Root.Right, Type);
                    break;
                case TraversalType.InOrder:
                    TraverseTree(Root.Left, Type);
                    Console.Write(Root.Value);
                    TraverseTree(Root.Right, Type);
                    break;
                case TraversalType.PostOrder:
                    TraverseTree(Root.Left, Type);
                    TraverseTree(Root.Right, Type);
                    Console.Write(Root.Value);
                    break;
                default:
                    break;
            }

          
        }
    }

    public class BinaryTreeAlgo 
    {
        public BinaryTree Tree { get; set; }
        public BinaryTreeAlgo(BinaryTree Tree)
        {
            this.Tree = Tree;
        }
        
        /// <summary>
        /// Bredth First Search
        /// </summary>
        public void BredthFirstTraversal()
        {
            Queue<TreeNode> Q = new Queue<TreeNode>();
            Q.Enqueue(this.Tree.Root);

            while (Q.Count > 0)
            {
                var item = Q.Dequeue();
                Console.Write(item.Value + " ");
                if (item.Left != null)
                    Q.Enqueue(item.Left);

                if (item.Right != null)
                    Q.Enqueue(item.Right);
            }
        }

        /// <summary>
        /// Depth First Search
        /// </summary>
        public void DepthFirstSearch()
        {
            Stack<TreeNode> Stk = new Stack<TreeNode>();
            Stk.Push(this.Tree.Root);

            while (Stk.Count > 0)
            {
                var item = Stk.Pop();
                Console.Write(item.Value + " ");

                if (item.Left != null)
                    Stk.Push(item.Left);
                if (item.Right != null)
                    Stk.Push(item.Right);
            }
        }

        /// <summary>
        /// Breadth First Search
        /// </summary>
        public void BredthFirstInLevel()
        {
            Queue<TreeNode> Q = new Queue<TreeNode>();
            Q.Enqueue(this.Tree.Root);
            
            while (true)
            {
                int ItemCount = Q.Count;
                if (ItemCount == 0)
                    break;

                while (ItemCount > 0)
                {
                    var item = Q.Dequeue();
                    Console.Write(item.Value + " ");

                    if (item.Left != null)
                        Q.Enqueue(item.Left);

                    if (item.Right != null)
                        Q.Enqueue(item.Right);

                    --ItemCount;
                }
                Console.WriteLine("\n");
            }

            
        }

        public int CountNodesOfTree()
        {
            Queue<TreeNode> Q = new Queue<TreeNode>();
            Q.Enqueue(this.Tree.Root);
            int Count = 0;

            while (Q.Count > 0)
            {
                var item = Q.Dequeue();
                ++Count;
                if (item.Left != null)
                    Q.Enqueue(item.Left);

                if (item.Right != null)
                    Q.Enqueue(item.Right);
            }
            return Count;
        }


        //TODO : 
        //Implement algo  where next() function returns the smallest node of BST
        //Using Stack to push all left child
        //when call next() pop from stack and if node has right child then push all left of right node


        #region ReturnMinimum from Stack
        Stack<TreeNode> Stk = new Stack<TreeNode>();
        void PrepareStack()
        {
            TreeNode head = Tree.Root;
            Stk.Push(Tree.Root);

            while (head.Left != null)
            {
                Stk.Push(head.Left);
                head = head.Left;
            }
        }
        public TreeNode FetchNextElement()
        {
            TreeNode item = null;
            if (Stk.Count == 0)
                PrepareStack();
            else
            {
                item = Stk.Pop();

                if (item.Right != null)
                {
                    var branchNode = item.Right;
                    Stk.Push(branchNode);
                    while (branchNode.Left != null)
                    {
                        Stk.Push(branchNode.Left);
                        branchNode = branchNode.Left;
                    }
                }
            }

            return item;
        }
        #endregion



    }

}

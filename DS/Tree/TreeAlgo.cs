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

        /// <summary>
        /// Program to count number of nodes in tree
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Program to print binary tree level by level
        /// </summary>
        public void PrintLevelByLevel()
        {
            Queue<TreeNode> Q = new Queue<TreeNode>();
            Q.Enqueue(Tree.Root);

            while (true)
            {
                int Count = Q.Count;

                if (Count == 0)
                    break;
                while (Count > 0)
                {
                    var item = Q.Dequeue();
                    Console.Write(item.Value);

                    if (item.Left != null)
                        Q.Enqueue(item.Left);

                    if (item.Right != null)
                        Q.Enqueue(item.Right);

                    --Count;
                }
                Console.WriteLine("\n");
            }
        }
        

        /// <summary>
        /// Program to print level order traversal in spiral form
        /// </summary>
        /// <param name="Root"></param>
        public void PrintLevelByLevelInSpiralForm(TreeNode Root)
        {
            Stack<TreeNode> Stk1 = new Stack<TreeNode>();
            Stack<TreeNode> Stk2 = new Stack<TreeNode>();

            Stk1.Push(Root);

            while (Stk1.Count> 0 || Stk2.Count > 0)
            {
                while (Stk1.Count >0)
                {
                    var item = Stk1.Pop();
                    Console.Write(item.Value + " ");

                    if (item.Right != null)
                        Stk2.Push(item.Right);

                    if (item.Left != null)
                        Stk2.Push(item.Left);
                }

                while (Stk2.Count > 0)
                {
                    var item = Stk2.Pop();
                    Console.Write(item.Value + " ");

                    if (item.Left != null)
                        Stk1.Push(item.Left);

                    if (item.Right != null)
                        Stk1.Push(item.Right);
                }

                Console.WriteLine();
            }


        }


        /// <summary>
        /// Program to find the depth of Binary Tree
        /// </summary>
        /// <param name="Root"></param>
        /// <returns></returns>
        public int FindDepthOfTree(TreeNode Root)
        {
            if (Root == null)
                return 0;
            else
                return Math.Max(FindDepthOfTree(Root.Left), FindDepthOfTree(Root.Right)) +1;
        }


        /// <summary>
        /// Pre order traversal using iterative method
        /// </summary>
        /// <param name="Root"></param>
        public void PreOrderTraversal_Iterative(TreeNode Root)
        {
            Stack<TreeNode> Stk = new Stack<TreeNode>();
            Stk.Push(Root);

            while (Stk.Count > 0)
            {
                var item = Stk.Pop();
                Console.WriteLine(item.Value);

                if (item.Right != null)
                    Stk.Push(item.Right);

                if (item.Left != null)
                    Stk.Push(item.Left);
            }
        }


        /// <summary>
        /// Inorder traversal 
        /// </summary>
        /// <param name="Root"></param>
        public void InOrderTraversal_Iterative(TreeNode Root)
        {
           
        }


        /// <summary>
        /// Print all leaf node in Binary Tree
        /// </summary>
        /// <param name="Root"></param>
        public void PrintAllLeafNode_Recursion(TreeNode Root)
        {
            if (Root == null)
                return;
            else
            {
                if (Root.Left == null && Root.Right == null)
                    Console.WriteLine(Root.Value);

                PrintAllLeafNode_Recursion(Root.Left);
                PrintAllLeafNode_Recursion(Root.Right);
            }
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

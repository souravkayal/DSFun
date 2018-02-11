using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.Model
{
    public class LinkedNode
    {
        public int Value { get; set; }
        public LinkedNode Next { get; set; }
        public LinkedNode Prev { get; set; }
    }

    public class TreeNode
    {
        public int Value { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }
    }

    public class LinkedNode<T>
    {
        public T Value { get; set; }
        public LinkedNode Next { get; set; }
        public LinkedNode Prev { get; set; }
    }

    public class TreeNode<T>
    {
        public T Value { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sem6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var bt = new BinaryTree();
            bt.Insert(4);
            bt.Insert(0);
            bt.Insert(7);
            bt.Insert(8);
            bt.Insert(1);
            bt.Insert(5);
            bt.Insert(6);
            Console.WriteLine(bt.ToString());
            Console.WriteLine("----------------------");
            bt.root = bt.right_rotation(bt.root);
            Console.WriteLine(bt.ToString());
            Console.WriteLine("----------------------");
            bt.root = bt.left_rotation(bt.root);
            Console.WriteLine(bt.ToString());
        }
    }
    public class TreeNode
    {
        private int data;
        private TreeNode left;
        private TreeNode right;

        public int Data
        { get { return data; } set { data = value; } }

        public TreeNode Left
        { get { return left; } set { left = value; } }

        public TreeNode Right
        { get { return right; } set { right = value; } }

        public TreeNode(int value)
        {
            Data = value;
        }
    }
    public class BinaryTree
    {
        public TreeNode root;

        public void Insert(int d)
        {
            if (root == null)
                root = new TreeNode(d);
            else
                insert(root, d);
        }

        private void insert(TreeNode n, int d)
        {
            if (d < n.Data)
            {
                if (n.Left == null)
                    n.Left = new TreeNode(d);
                else
                    insert(n.Left, d);
            }
            else
            {
                if (n.Right == null)
                    n.Right = new TreeNode(d);
                else
                    insert(n.Right, d);
            }
        }

        private KeyValuePair<int, string> ToStringHelper(TreeNode n)
        {
            if (n == null)
                return new KeyValuePair<int, string>(1, "\n");

            var left = ToStringHelper(n.Left);
            var right = ToStringHelper(n.Right);

            var objString = n.Data.ToString();
            var stringBuilder = new StringBuilder();

            stringBuilder.Append(' ', left.Key - 1);
            stringBuilder.Append(objString);
            stringBuilder.Append(' ', right.Key - 1);
            stringBuilder.Append('\n');

            var i = 0;
            while (i * left.Key < left.Value.Length && i * right.Key < right.Value.Length)
            {
                stringBuilder.Append(left.Value, i * left.Key, left.Key - 1);
                stringBuilder.Append(' ', objString.Length);
                stringBuilder.Append(right.Value, i * right.Key, right.Key);
                ++i;
            }

            while (i * left.Key < left.Value.Length)
            {
                stringBuilder.Append(left.Value, i * left.Key, left.Key - 1);
                stringBuilder.Append(' ', objString.Length + right.Key - 1);
                stringBuilder.Append('\n');

                ++i;
            }

            while (i * right.Key < right.Value.Length)
            {
                stringBuilder.Append(' ', left.Key + objString.Length - 1);
                stringBuilder.Append(right.Value, i * right.Key, right.Key);
                ++i;
            }
            return new KeyValuePair<int, string>(left.Key + objString.Length + right.Key - 1, stringBuilder.ToString());
        }
        public override string ToString()
        {
            var res = ToStringHelper(root).Value;
            return res;
        }




        public TreeNode right_rotation(TreeNode Root)
        {
            var Pivot = Root.Left;
            Root.Left = Pivot.Right;
            Pivot.Right = Root;
            return Pivot;
        }

        public TreeNode left_rotation(TreeNode Root)
        {
            var Pivot = Root.Right;
            Root.Right = Pivot.Left;
            Pivot.Left = Root;
            return Pivot;
        }

        public TreeNode BigRotateRight(TreeNode rt)
        {
            var piv = rt.Left;
            rt.Left = left_rotation(piv);
            return right_rotation(rt);
        }

        public TreeNode BigRotateLeft(TreeNode rt)
        {
            var piv = rt.Right;
            rt.Right = right_rotation(piv);
            return left_rotation(rt);
        }

    }
}

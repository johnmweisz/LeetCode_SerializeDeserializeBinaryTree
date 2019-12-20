using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_SerializeDeserializeBinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int x)
        {
            val = x;
        }
    }

    public class Codec
    {
        public string serialize(TreeNode root)
        {
            if (root == null) return "null";
            return root.val + "," + serialize(root.left) + "," + serialize(root.right);
        }

        public TreeNode deserialize(string data)
        {
            if (data == "null") return null;

            var dataArr = data.Split(',');
            var stack = new Stack<TreeNode>();
            var root = new TreeNode(Convert.ToInt32(dataArr[0]));
            bool right = false;

            stack.Push(root);

            for (int i = 1; i < dataArr.Length; i++)
            {
                if (dataArr[i] == "null")
                {
                    if (right) stack.Pop();
                    right = true;
                }
                else
                {
                    var newNode = new TreeNode(Convert.ToInt32(dataArr[i]));
                    if (right) stack.Pop().right = newNode;
                    else stack.Peek().left = newNode;
                    stack.Push(newNode);
                    right = false;
                }
            }

            return root;
        }
    }

}

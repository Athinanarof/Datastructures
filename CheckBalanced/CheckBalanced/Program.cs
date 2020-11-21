using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckBalanced
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode firstNode = new TreeNode(1);
            firstNode.left = new TreeNode(2);
            firstNode.right = new TreeNode(3);
            firstNode.left.left = new TreeNode(4);
            firstNode.right.right = new TreeNode(5);

            bool result = isBalanced_Improved(firstNode);
        }

        public static int getHeight(TreeNode root)
        {
            if (root == null) return -1;
            return Math.Max(getHeight(root.left), getHeight(root.right)) + 1;
        }

        public static bool isBalanced(TreeNode root)
        {
            if (root == null) return true;

            int heightDiff = getHeight(root.left) - getHeight(root.right);
            if (Math.Abs(heightDiff) > 1)
            {
                return false;
            }
            else
            {
                // Recuerse
                return isBalanced(root.left) && isBalanced(root.right);
            }
        }

        public static bool isBalanced_Improved(TreeNode root)
        {
            return checkHeight(root) != intMinValue;
        }

        public static int intMinValue = int.MinValue;
        private static int checkHeight(TreeNode root)
        {
            if (root == null) return -1;

            int leftHeight = checkHeight(root.left);
            if (leftHeight == intMinValue) return intMinValue;

            int rightHeight = checkHeight(root.right);
            if (rightHeight == intMinValue) return intMinValue;

            int heightDiff = leftHeight - rightHeight;
            if (Math.Abs(heightDiff) > 1)
            {
                return int.MinValue;
            }
            else
            {
                return Math.Max(leftHeight, rightHeight) + 1;
            }

        }
    }

    public class TreeNode
    {
        public int value;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int value)
        {
            this.value = value;
        }
    }
}

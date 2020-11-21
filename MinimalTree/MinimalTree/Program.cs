using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimalTree
{
    class Program
    {
        private static int[] array;

        static void Main(string[] args)
        {
            array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            createMinimalBST(array);
        }
        public static TreeNode createMinimalBST(int[] array)
        {
            TreeNode node = createMinimalBST(array, 0, array.Length - 1);
            return node;
        }

        public static TreeNode createMinimalBST(int[] array, int start, int end)
        {
            if (end < start)
            {
                return null;
            }
            int mid = (start + end) / 2;
            TreeNode node = new TreeNode(array[mid]);
            int node_value = node.value;

            node.left = createMinimalBST(array, start, mid - 1);
            node.right = createMinimalBST(array, mid + 1, end);

            return node;
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

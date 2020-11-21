using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListOfDepth
{
    class Program
    {
        static void Main(string[] args)
        {
            List<LinkedList<TreeNode>> lists = new List<LinkedList<TreeNode>>();
            TreeNode root = null;
            root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);
            root.left.left = new TreeNode(4);
            root.right.right = new TreeNode(5);
            root.right.right.right = new TreeNode(6);

            createLevelLinkList(root, lists, 0);
        }

        /* This is a preorder and dept first search combination*/
        public static void createLevelLinkList(TreeNode root, List<LinkedList<TreeNode>> lists, int level)
        {
            if (root == null) return;

            LinkedList<TreeNode> list = null;
            if (lists.Count() == level) // Level not contained in list
            {
                list = new LinkedList<TreeNode>();
                lists.Add(list);
            }
            else
            {
                list = lists[level];
            }
            createLevelLinkList(root.left, lists, level + 1);
            createLevelLinkList(root.right, lists, level + 1);
        }

        /*  This is a Breadth-First-Search implementation */
        public static List<LinkedList<TreeNode>> createLevelLinkList_BFS(TreeNode root) 
        {
            List<LinkedList<TreeNode>> final_list = new List<LinkedList<TreeNode>>();

            /* Starting visiting the root */
            LinkedList<TreeNode> queue = new LinkedList<TreeNode>();
            if (root != null)
            {
                queue.AddLast(root);
            }

            while (queue.Count > 0) // if it has children
            {
                final_list.Add(queue); // Add previous level
                LinkedList<TreeNode> parents = queue; // Go to next level

                queue = new LinkedList<TreeNode>();

                foreach (TreeNode parent in parents)
                {
                    /* Visit the childrens */
                    if (parent.left != null)
                    {
                        queue.AddLast(parent.left);
                    }
                    if (parent.right != null)
                    {
                        queue.AddLast(parent.right);
                    }
                }
            }

            return final_list;
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

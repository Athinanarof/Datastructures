using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
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


            TreeNode secondExample = new TreeNode(10);
            secondExample.left = new TreeNode(5);
            secondExample.right = new TreeNode(20);
            secondExample.left.left = new TreeNode(3);
            secondExample.left.right = new TreeNode(7);
            secondExample.right.right = new TreeNode(30);

            Console.WriteLine("InOrder");
            InOrder(firstNode);

            Console.WriteLine("InOrder");
            InOrder(secondExample);

            Console.WriteLine("PreOrden");
            Preorden(firstNode);

            Console.WriteLine("PostOrden");
            PostOrder(firstNode);
            Console.ReadKey();
        }

        // izquierda - raiz - derecha
        public static void InOrder(TreeNode root)
        {
            if (root == null)
            {
                return;
            }

            InOrder(root.left);
            Console.WriteLine(root.value);

            InOrder(root.right);
        }

        // Izquierda - derecha - raiz
        public static void PostOrder(TreeNode root)
        {
            if (root == null)
            {
                return;
            }
            PostOrder(root.left);
            PostOrder(root.right);
            Console.WriteLine(root.value);
        }

        // raiz - izquierda - derecha
        public static void Preorden(TreeNode root)
        {
            if (root == null)
            {
                return;
            }

            Console.WriteLine(root.value);
            Preorden(root.left);
            Preorden(root.right);
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

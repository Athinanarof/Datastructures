using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindKthToLastElementInLinkedList
{
    public class LinkedList
    {
        public int Value { get; set; }
        public LinkedList Next { get; set; }
        public LinkedList(int value)
        {
            this.Value = value;
        }
    }
    public class Index
    {
        public int value = 0;
    }
    class Program
    {
        public static LinkedList head = null;
        static void Main(string[] args)
        {
            InitializeList();
            PrintKthToLastElement(head, 4);
            PrintKthToLastElement_UsingWrapperClass(head, 4);
            PrintKthToLastElement_ByIterativeMethod(head, 4);
            DeleteNode_GivenTheNodeX(head);
        }

        public static bool DeleteNode_GivenTheNodeX(LinkedList node)
        {
            if (node.Next == null ||  node == null)
            {
                return false;
            }

            LinkedList nextNode = node.Next;
            node.Value = nextNode.Value;
            node.Next = nextNode.Next;

            return true;
        }

        public static int PrintKthToLastElement(LinkedList head, int k)
        {
            if (head == null)
            {
                return 0;
            }

            int index = PrintKthToLastElement(head.Next, k) + 1;

            if (index == k)
            {
                Console.WriteLine(k + "th to last node is " + head.Value);
            }

            return index;
        }

        #region PrintKthToLastElement_UsingWrapperClass
        public static LinkedList PrintKthToLastElement_UsingWrapperClass(LinkedList head, int k)
        {
            Index index = new Index();
            return PrintKthToLastElement_UsingWrapperClass(head, k, index);
        }

        public static LinkedList PrintKthToLastElement_UsingWrapperClass(LinkedList head, int k, Index index)
        {
            if (head == null)
            {
                return null;
            }

            LinkedList node = PrintKthToLastElement_UsingWrapperClass(head.Next, k, index);
            index.value = index.value + 1;

            if (index.value == k)
            {
                return head;
            }

            return node;
        }

        #endregion

        public static LinkedList PrintKthToLastElement_ByIterativeMethod(LinkedList head, int k)
        {
            LinkedList p1 = head;
            LinkedList p2 = head;

            /* Move p1 k nodes into the list */

            for (int i = 0; i < k; i++)
            {
                if (p1 == null)
                {
                    return null; // Out of bounds
                }
                else
                {
                    p1 = p1.Next;
                }
            }

            /* Move them at the same pace. When p1 hits the end, p2 will be at the right element*/

            while (p1 != null)
            {
                p1 = p1.Next;
                p2 = p2.Next;
            }

            return p2;
        }
        public static void InitializeList()
        {
            head = new LinkedList(1);
            //AddNode(5);
            int iterations = 2;
            while (iterations < 6)
            {
                AddNode(iterations);
                iterations++;
            }
        }
        public static void AddNode(int value)
        {
            LinkedList end = new LinkedList(value);
            LinkedList node = head;
            while (node.Next != null)
            {
                node = node.Next;
            }
            node.Next = end;
        }
    }
}

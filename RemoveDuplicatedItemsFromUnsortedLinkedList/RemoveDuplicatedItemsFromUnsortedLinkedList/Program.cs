using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveDuplicatedItemsFromUnsortedLinkedList
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
    class Program
    {
        public static LinkedList head = null;
        static void Main(string[] args)
        {
            // Append items to list
            InitializeList();

            RemoveDuplicatedItemsFromList_HashTable(head);

            InitializeList();
            RemoveDuplicatedItemsFromList_NoBuffer(head);

        }

        public static void InitializeList()
        {
            head = new LinkedList(1);
            AddNode(5);
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
        public static void RemoveDuplicatedItemsFromList_HashTable(LinkedList head)
        {
            HashSet<int> hashT = new HashSet<int>();
            LinkedList previousNode = null;
            LinkedList tempHead = head;

            while (tempHead != null)
            {
                if (hashT.Contains(tempHead.Value))
                {
                    previousNode.Next = tempHead.Next;
                }
                else
                {
                    hashT.Add(tempHead.Value);
                    previousNode = tempHead;
                }
                tempHead = tempHead.Next;
            }
        }
        public static void RemoveDuplicatedItemsFromList_NoBuffer(LinkedList head)
        {
            LinkedList current = head;
            while (current != null)
            {
                /* Remove future nodes that have the same value */
                LinkedList runner = current;
                while (runner.Next != null)
                {
                    if (runner.Next.Value == current.Value)
                    {
                        runner.Next = runner.Next.Next;
                    }
                    else
                    {
                        runner = runner.Next;
                    }
                }

                current = current.Next;
            }
        }
    }
}

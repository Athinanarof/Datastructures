using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartitionLinkedLists
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
            InitializeList();
            //Partition_Stable(head, 5);
            Partition_NotStable(head, 5);

        }

        /* Pass in the head of the linked list and the value to partition around */
        public static LinkedList Partition_Stable(LinkedList node, int x)
        {
            LinkedList beforeStart = null;
            LinkedList beforeEnd = null;
            LinkedList afterStart = null;
            LinkedList afterEnd = null;

            /* Partition list */

            while (node != null)
            {
                LinkedList next = node.Next;
                node.Next = null; // We only want the current element without the following
                if (node.Value < x)
                {
                    /* insert node into end of before list */
                    if (beforeStart == null)
                    {
                        beforeStart = node;
                        beforeEnd = beforeStart; // Latest node of node list/variable
                    }
                    else
                    {
                        beforeEnd.Next = node; // Attaching new node to the latest one, which at the same time will be reflected in entire list in beforeStart
                        beforeEnd = node; // Again setting latest new node into before end
                    }
                }
                else
                {
                    /* Insert node into end of after list */
                    if (afterStart == null)
                    {
                        afterStart = node;
                        afterEnd = afterStart;
                    }
                    else
                    {
                        afterEnd.Next = node;
                        afterEnd = node;
                    }
                }
                node = next;
            }

            if (beforeStart == null)
            {
                return afterStart;
            }

            /* Merge before list and after list */
            beforeEnd.Next = afterStart;
            return beforeStart;
        }
        public static LinkedList Partition_NotStable(LinkedList node, int x)
        {
            LinkedList head = node;
            LinkedList tail = node;

            while (node != null)
            {
                LinkedList next = node.Next;

                if (node.Value < x)
                {
                    /* Insert node at head */
                    node.Next = head; // We want to attach to this node value the previous values in head
                    head = node;
                }
                else
                {
                    /* Insert node at tail */
                    tail.Next = node; // The new node goes directly to the end of the tail
                    tail = node;
                }
                node = next;
            }
            tail.Next = null;

            // The head has changed, so we need to return it to the user.
            return head;
        }

        public static void InitializeList()
        {
            head = new LinkedList(3);
            AddNode(5);
            AddNode(8);
            AddNode(5);
            AddNode(10);
            AddNode(2);
            AddNode(1);

            //int iterations = 2;

            //while (iterations < 6)
            //{
            //    AddNode(iterations);
            //    iterations++;
            //}
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

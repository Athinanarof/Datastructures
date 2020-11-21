using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumLists_LinkedLists
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
        public static LinkedList firstNumber = null;
        public static LinkedList secondNumber = null;
        static void Main(string[] args)
        {
            InitializeList();
            AddLists(firstNumber, secondNumber);
        }

        public static LinkedList AddLists(LinkedList l1, LinkedList l2)
        {
            return AddLists(l1, l2, 0);
        }

        private static LinkedList AddLists(LinkedList l1, LinkedList l2, int carry)
        {
            if (l1 == null && l2 == null && carry == 0)
            {
                return null;
            }

            LinkedList result = null;

            int value = carry;
            if (l1 != null)
            {
                value += l1.Value;
            }
            if (l2 != null)
            {
                value += l2.Value;
            }

            result = new LinkedList(value % 10);

            if (l1 != null || l2 != null)
            {
                LinkedList more = AddLists(l1 == null ? null : l1.Next,
                                           l2 == null ? null : l2.Next,
                                           value >= 10 ? 1 : 0);
                if (more != null)
                {
                    AddNode(result, more.Value);
                }
            }

            return result;
        }

        public static void InitializeList()
        {
            firstNumber = new LinkedList(7);
            AddNode(firstNumber, 1);
            AddNode(firstNumber, 6);

            secondNumber = new LinkedList(5);
            AddNode(secondNumber, 9);
            AddNode(secondNumber, 2);

            //int iterations = 2;

            //while (iterations < 6)
            //{
            //    AddNode(iterations);
            //    iterations++;
            //}
        }
        public static void AddNode(LinkedList list, int value)
        {
            LinkedList end = new LinkedList(value);
            LinkedList node = list;
            while (node.Next != null)
            {
                node = node.Next;
            }
            node.Next = end;
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsPalindromeRecursiveSolution_LinkedList
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

    public class Result
    {
        public LinkedList node;
        public bool result;
    }
    class Program
    {
        public static LinkedList head = null;
        static void Main(string[] args)
        {
            InitializeList();
            IsPalindrome();
            
        }

        public static bool IsPalindrome()
        {
            int length = lengthOfList(head);
            Result p = isPalindromeRecurse(head, length);
            return p.result;
        }

        private static Result isPalindromeRecurse_v2(LinkedList head, int length)
        {
            /* Since we are sending length - 2 each time, if the length == 0 means it is a even list
             * If it reach exactly 1 it is a odd lenght list
             */
            if (head == null || length <= 0)
            {
                // Taking the exactly even middle of the list, LAST MIDDLE
                return new Result() { node = head, result = true }; // Even
            }
            else if (length == 1) // Odd
            {
                /* We will iterate one more node, since when this line is reached it is just in the middle
                 * we want to compare the LAST MIDDLE of the list
                */
                return new Result() { node = head.Next, result = true };
            }

            /* It will iterate through the head since the begining of the list */
            Result result = isPalindromeRecurse_v2(head.Next, length);

            if (!result.result || result.node == null)
            {
                return result;
            }

            /* When finish call stack (when it returns the last middle to compare)*/

            // The head at that moment vs the current first element from the RIGHT/LAST MIDDLE node
            result.result = (head.Value == result.node.Value);

            // Current node needs to be iterate for comparing with previous call stack
            result.node = result.node.Next;

            return result;
        }

        private static Result isPalindromeRecurse(LinkedList head, int length)
        {
            if (head == null || length <= 0)
            {
                return new Result() { node = head, result = true }; // Even number of nodes
            }
            else if (length == 1)
            {
                return new Result() { node = head.Next, result = true }; // Odd number of nodes
            }

            /* Recurse in sublist */
            Result res = isPalindromeRecurse(head.Next, length - 2);

            /* If child calls are not a palindrome, pass back up a failure */
            if (!res.result || res.node == null)
            {
                return res;
            }

            /* Check if mantches corresponding node on other side */
            res.result = (head.Value == res.node.Value);

            /* Returning corresponding node */
            res.node = res.node.Next;

            return res;
        }

        private static int lengthOfList(LinkedList node)
        {
            int size = 0;
            while (node != null)
            {
                size++;
                node = node.Next;
            }
            return size;
        }

        public static void InitializeList()
        {
            head = new LinkedList(0);
            AddNode(1);
            AddNode(2);
            AddNode(3);
            AddNode(4);
            AddNode(3);
            AddNode(2);
            AddNode(1);
            AddNode(0);
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

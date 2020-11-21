using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreenInOne_StackUsingSingleArray
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    public class FixedMultiStack
    {
        private int numberOfStacks = 3;
        private int stackCapacity;
        private int[] values;
        private int[] sizes;

        public FixedMultiStack(int stackSize)
        {
            stackCapacity = stackSize;
            values = new int[stackSize * numberOfStacks];
            sizes = new int[numberOfStacks];
        }

        /* Push values onto stack */
        public void push(int stackNum, int value)
        {
            /* Check that we have space for the next element */
            if (isFull(stackNum))
            {
                throw new Exception();
            }

            /* Increment stack pointer and then update top value. */
            sizes[stackNum]++;
            values[indexOfTop(stackNum)] = value;
        }

        /* pop item from top stack */
        public int pop(int stackNum)
        {
            if (isEmpty(stackNum))
            {
                throw new Exception();
            }

            int topIndex = indexOfTop(stackNum);
            int value = values[topIndex]; // Get top
            values[topIndex] = 0; // Clear
            sizes[stackNum]--; // Shrink
            return value;
        }

        /* Return top element */
        public int peek(int stackNum)
        {
            if (isEmpty(stackNum))
            {
                throw new Exception();
            }

            return values[indexOfTop(stackNum)];
        }
        private bool isEmpty(int stackNum)
        {
            return sizes[stackNum] == 0;
        }

        private int indexOfTop(int stackNum)
        {
            int offset = stackNum * stackCapacity;
            int size = sizes[stackNum];
            return offset + size - 1;
        }

        private bool isFull(int stackNum)
        {
            return sizes[stackNum] == stackCapacity;
        }
    }
}

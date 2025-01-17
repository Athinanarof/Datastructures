﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOfPlates
{
    class Program
    {
        static void Main(string[] args)
        {
            SetOfStacks mySet = new SetOfStacks(3);
            mySet.push(1);
            mySet.push(2);
            mySet.push(3);
            mySet.push(4);
            mySet.push(5);
            mySet.push(6);
            mySet.push(7);
            mySet.push(8);
            mySet.push(9);


            mySet.popAt(1);
        }
    }

    public class SetOfStacks
    {
        List<Stack> stacks = new List<Stack>();
        public int capacity;
        public SetOfStacks(int capacity)
        {
            this.capacity = capacity;
        }

        public Stack getLastStack()
        {
            if (stacks.Count == 0)
            {
                return null;
            }
            return stacks[stacks.Count - 1];
        }

        public void push(int v)
        {
            Stack last = getLastStack();
            if (last != null && !last.isFull())
            {
                last.push(v);
            }
            else
            {
                Stack stack = new Stack(capacity);
                stack.push(v);
                stacks.Add(stack);
            }
        }

        public int pop()
        {
            Stack last = getLastStack();
            if (last == null) throw new Exception();
            int v = last.pop();
            if (last.size == 0)
            {
                stacks.RemoveAt(stacks.Count - 1);
            }
            return v;
        }

        public bool isEmpty()
        {
            Stack last = getLastStack();
            return last == null || last.isEmpty();
        }

        public int popAt(int index) 
        {
            return leftShift(index, true);
        }

        private int leftShift(int index, bool remoteTop)
        {
            Stack stack = stacks[index];
            int removed_item;
            if (remoteTop) removed_item = stack.pop();
            else removed_item = stack.removeBottom();
            if (stack.isEmpty())
            {
                stacks.RemoveAt(index);
            }
            else if (stacks.Count > index + 1)
            {
                int v = leftShift(index + 1, false);
                stack.push(v);
            }
            return removed_item;
        }
    }

    public class Stack
    {
        private int capacity;
        public Node top, bottom;
        public int size = 0;

        public Stack(int capacity)
        {
            this.capacity = capacity;
        }

        public bool isFull()
        {
            return capacity == size;
        }

        public bool isEmpty() 
        {
            return size == 0;
        }

        public void join(Node above, Node below)
        {
            if (below != null)
            {
                below.above = above;
            }
            if (above != null)
            {
                above.below = below;
            }
        }

        public bool push(int v)
        {
            if (size >= capacity) 
            {
                return false;
            }
            size++;
            Node n = new Node(v);
            if (size == 1)
            {
                bottom = n;
            }
            join(n, top);
            top = n;
            return true;
        }

        public int pop()
        {
            Node t = top;
            top = top.below;
            size--;
            return t.value;
        }

        public int removeBottom()
        {
            Node b = bottom;
            bottom = bottom.above;
            if (bottom != null)
            {
                bottom.below = null;
            }
            size--;
            return b.value;
        }
    }
    public class Node
    {
        public Node above, below;
        public int value;

        public Node(int value)
        {
            this.value = value;
        }
    }
}

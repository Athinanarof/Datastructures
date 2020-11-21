using System;

namespace StackBasicStructure
{
    public class MyStack<T> // Outer classs
    {
        public class StackNode<T> // Inner/nested class, private and static (last one will reduce memory usage)
        {
            /* Class and properties are not required to be accessible from external classes */
            public T data;
            public StackNode<T> next;

            public StackNode(T data) // Only constructors is required to be accessible externally
            {
                this.data = data;
            }
        }

        private StackNode<T> top;

        /* Following methods are the only ones to be accessible from external classes */
        public T pop()
        {
            if (top == null)
            {
                throw new Exception();
            }
            else
            {
                T item = top.data; // Nested classes allows outer methods to access private scopes/properties
                top = top.next;
                return item;
            }
        }

        public void push(T item)
        {
            StackNode<T> node = new StackNode<T>(item);
            node.next = top;
            top = node;
        }

        public T peek()
        {
            if (top == null)
            {
                throw new Exception();
            }
            else
            {
                T item = top.data;
                return item;
            }
        }

        public bool isEmpty()
        {
            return top == null;
        }
    }
}

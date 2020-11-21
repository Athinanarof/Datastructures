using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueBasicStructure
{
    public class MyQueue<T>
    {
        public class QueueNode<T>
        {
            public T data;
            public QueueNode<T> next;

            public QueueNode(T data)
            {
                this.data = data;
            }
        }

        private QueueNode<T> first;
        private QueueNode<T> last;

        public void add(T item) 
        {
            QueueNode<T> node = new QueueNode<T>(item);
            if (last != null)
            {
                last.next = node;
            }
            last = node;
            if (first == null)
            {
                first = last;
            }
        }

        public T remove()
        {
            if (first == null)
            {
                throw new Exception();
            }
            T data = first.data;
            first = first.next;
            if (first == null)
            {
                last = null;
            }
            return data;
        }

        public T peek()
        {
            if (first == null)
            {
                throw new Exception();
            }
            return first.data;
        }

        public bool isEmpty()
        {
            return first == null;
        }
    }
}

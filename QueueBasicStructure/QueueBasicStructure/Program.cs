using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueBasicStructure
{
    class Program
    {
        static void Main(string[] args)
        {
            MyQueue<string> queue = new MyQueue<string>();
            queue.add("Araceli");
            queue.add("Josue");
            queue.add("Peludito");

            string item_removed = queue.remove();
            string item_peeked = queue.peek();

            bool isEmpty = queue.isEmpty();
        }
    }
}

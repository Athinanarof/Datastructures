using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackMin
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class StackWithMin : Stack<NodeWithMin> {

        Stack<NodeWithMin> super = new Stack<NodeWithMin>();
        public void push(int value)
        {
            int newMin = Math.Min(value, min());
            super.Push(new NodeWithMin(value, newMin));
        }

        private int min()
        {
            if (super  == null)
            {
                return int.MaxValue;
            }
            else
            {
                return 0; //Peek().min
            }
        }
    }
}

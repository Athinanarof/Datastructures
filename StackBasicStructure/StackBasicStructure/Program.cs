using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackBasicStructure
{
    partial class Program
    {
        static void Main(string[] args)
        {
            MyStack<int> stack = new MyStack<int>();
            stack.push(1);
            stack.push(2);
            stack.push(3);
            stack.push(4);

            int pop_value = stack.pop();
            int peek_value = stack.peek();

            bool isEmpty = stack.isEmpty();
        }
    }
}

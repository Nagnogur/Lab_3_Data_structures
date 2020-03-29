using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    class MyStack
    {
        private string[] stack = new string[32767];
        private int count = 0;
        public int Count { get { return count; } }

        public void Push(string s)
        {
            stack[count] = s;
            count++;
        }
        public void Pop()
        {
            count--;
        }
        public string Peek()
        {
            return stack[count - 1];
        }

        public void PrintStack()
        {
            for (int i = 0; i < count; i++)
            {
                Console.Write(stack[i] + " ");
            }
        }
    }
}

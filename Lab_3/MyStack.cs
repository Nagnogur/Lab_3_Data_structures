using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    class MyStack<T>
    {
        private T[] stack = new T[32767];
        private int count = 0;
        public int Count { get { return count; } }

        public void Push(T s)
        {
            stack[count] = s;
            count++;
        }
        public void Pop()
        {
            count--;
        }
        public T Peek()
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

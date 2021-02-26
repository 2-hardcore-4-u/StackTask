using System;
using System.IO;
using System.Dynamic;

namespace StackTask
{
    class Program
    {
        static void Main()
        {
            MyStacks<string> stack = new MyStacks<string>();
            stack.Push("a");
            stack.Push("b");
            string x = stack.Peek();
            Console.WriteLine(x);
            string y = stack.Pop();
            Console.WriteLine(y);
            string z = stack.Peek();
            Console.WriteLine(z);
        }
    }
    public class MyStacks<T> : IStack<T>
    {
        T[] theStack;
        int length;
        int maxLength;
        public MyStacks()
        {
            length = 1;
            maxLength = 0;
            theStack = new T[1];
        }

        public bool IsEmpty() => length == 0;
        private void IsEmptyExceptionCheck()
        {
            if (IsEmpty()) throw new Exception("Empty");
        }

        private void Resize() => Array.Resize(ref theStack, length * 2);

        public T Peek()
        {
            IsEmptyExceptionCheck();
            return theStack[length];
        }

        public T Pop()
        {
            IsEmptyExceptionCheck();
            return theStack[--length];
        }

        public void Push(T value)
        {
            length++;
            if (MoreThenMax())
            {
                maxLength = length;
                Array.Resize(ref theStack, length * 2);
            }
            theStack[length] = value;
        }
        private bool MoreThenMax()
        {
            if (length > maxLength) return true;
            return false;
        }
    }
    public interface IStack<T>
    {
        T Pop();
        T Peek();
        void Push(T value);
        bool IsEmpty();
    }
}
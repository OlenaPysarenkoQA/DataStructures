using System;

namespace DataStructures
{
    public class Stack
    {
        private object[] array;
        private int top;

        public int Count
        {
            get { return top + 1; }
        }

        public Stack()
        {
            array = new object[4];
            top = -1;
        }

        public void Push(object item)
        {
            EnsureCapacity();
            top++;
            array[top] = item;
        }

        public object Pop()
        {
            if (top == -1)
            {
                throw new InvalidOperationException("Stack is empty");
            }

            object item = array[top];
            array[top] = null;
            top--;

            return item;
        }

        public object Peek()
        {
            if (top == -1)
            {
                throw new InvalidOperationException("Stack is empty");
            }

            return array[top];
        }

        public bool Contains(object? item)
        {
            for (int i = 0; i < top; i++)
            {
                if (array[i].Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public void Clear()
        {
            array = new object[4];
            top = -1;
        }

        public object[] ToArray()
        {
            object[] result = new object[top + 1];
            Array.Copy(array, result, top + 1);
            return result;
        }

        private void EnsureCapacity()
        {
            if (top == array.Length - 1)
            {
                int newCapacity = array.Length * 2;
                object[] newArray = new object[newCapacity];
                Array.Copy(array, newArray, array.Length);
                array = newArray;
            }
        }
    }
}


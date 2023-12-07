using System;

namespace DataStructures
{
    public class Stack<T> : IStack<T>
    {
        private T[] array;
        private int top;

        public int Count
        {
            get { return top + 1; }
        }

        public Stack()
        {
            array = new T[4];
            top = -1;
        }

        public void Push(T item)
        {
            EnsureCapacity();
            top++;
            array[top] = item;
        }

        public T Pop()
        {
            if (top == -1)
            {
                throw new InvalidOperationException("Stack is empty");
            }

            T item = array[top];
            array[top] = default(T);
            top--;

            return item;
        }

        public T Peek()
        {
            if (top == -1)
            {
                throw new InvalidOperationException("Stack is empty");
            }

            return array[top];
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < top; i++)
            {
                if (ReferenceEquals(array[i], item) || (array[i] != null && array[i].Equals(item)))
                {
                    return true;
                }
            }
            return false;
        }

        public void Clear()
        {
            array = new T[4];
            top = -1;
        }

        public T[] ToArray()
        {
            T[] result = new T[top + 1];
            Array.Copy(array, result, top + 1);
            return result;
        }

        private void EnsureCapacity()
        {
            if (top == array.Length - 1)
            {
                int newCapacity = array.Length * 2;
                T[] newArray = new T[newCapacity];
                Array.Copy(array, newArray, array.Length);
                array = newArray;
            }
        }
    }
}


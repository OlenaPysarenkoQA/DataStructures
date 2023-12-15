using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
    public class Queue<T> : IQueue<T>, IEnumerable
    {
        private T[] array;
        private int head;
        private int tail;
        private int count;

        public int Count => count;

        public Queue()
        {
            array = new T[4];
            head = 0;
            tail = -1;
            count = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return EnumerateItems().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private IEnumerable<T> EnumerateItems()
        {
            for (int i = 0; i < count; i++)
            {
                int index = (head + i) % array.Length;
                yield return array[index];
            }
        }

        public void Enqueue(T item)
        {
            EnsureCapacity();

            tail = (tail + 1) % array.Length;
            array[tail] = item;
            count++;
        }

        public T Dequeue()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            T item = array[head];
            array[head] = default(T);
            head = (head + 1) % array.Length;
            count--;

            return item;
        }

        public void Clear()
        {
            array = new T[4];
            head = 0;
            tail = -1;
            count = 0;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < count; i++)
            {
                if (ReferenceEquals(array[i], item) || (array[i] != null && array[i].Equals(item)))
                {
                    return true;
                }
            }
            return false;
        }

        public T Peek()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            return array[head];
        }

        public T[] ToArray()
        {
            T[] newArray = new T[count];
            for (int i = 0; i < count; i++)
            {
                int index = (head + i) % array.Length;
                newArray[i] = array[index];
            }
            return newArray;
        }

        private void EnsureCapacity()
        {
            if (count == array.Length)
            {
                int newCapacity = array.Length * 2;
                T[] newArray = new T[newCapacity];

                for (int i = 0; i < count; i++)
                {
                    int index = (head + i) % array.Length;
                    newArray[i] = array[index];
                }

                array = newArray;
                head = 0;
                tail = count - 1;
            }
        }
    }
}

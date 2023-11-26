using System;

namespace DataStructures
{
    public class Queue
    {
        private object[] array;
        private int head;
        private int tail;
        private int count;

        public int Count
        {
            get { return count; }
        }

        public Queue()
        {
            array = new object[4];
            head = 0;
            tail = -1;
            count = 0;
        }

        public void Enqueue(object item)
        {
            EnsureCapacity();

            tail = (tail + 1) % array.Length;
            array[tail] = item;
            count++;
        }

        public object Dequeue()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            object item = array[head];
            array[head] = null;
            head = (head + 1) % array.Length;
            count--;

            return item;
        }

        public void Clear()
        {
            array = new object[4];
            head = 0;
            tail = -1;
            count = 0;
        }

        public bool Contains(object? item)
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

        public object Peek()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            return array[head];
        }

        public object[] ToArray()
        {
            object[] newArray = new object[count];
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
                object[] newArray = new object[newCapacity];

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

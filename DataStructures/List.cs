using System;

namespace DataStructures
{
    public class List : IList
    {
        private object[] array;
        private int count;
        private int capacity;

        public int Count
        {
            get { return count; }
        }

        public List()
        {
            array = new object[4];
            count = 0;
            capacity = 4;
        }

        public List(int capacity)
        {
            array = new object[capacity];
            count = 0;
            this.capacity = capacity;
        }

        public void Add(object item)
        {
            EnsureCapacity();
            array[count] = item;
            count++;
        }

        public void Insert(int index, object item)
        {
            EnsureCapacity();

            for (int i = count; i > index; i--)
            {
                array[i] = array[i - 1];
            }

            array[index] = item;
            count++;
        }

        public void Remove(object item)
        {
            for (int i = 0; i < count; i++)
            {
                if (array[i] == item)
                {
                    RemoveAt(i);
                    return;
                }
            }
        }

        public void RemoveAt(int index)
        {
            if (index >= 0 && index < count)
            {
                for (int i = index; i < count - 1; i++)
                {
                    array[i] = array[i + 1];
                }
                array[count - 1] = null;
                count--;
            }
        }

        public void Clear()
        {
            array = new object[capacity];
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

        public int IndexOf(object item)
        {
            for (int i = 0; i < count; i++)
            {
                if ((array[i] == null && item == null) || (array[i] != null && array[i] == item))
                {
                    return i;
                }
            }
            return -1;
        }

        public object[] ToArray()
        {
            object[] newArray = new object[count];
            for (int i = 0; i < count; i++)
            {
                newArray[i] = array[i];
            }
            return newArray;
        }

        public void Reverse()
        {
            for (int i = 0; i < count / 2; i++)
            {
                object temp = array[i];
                array[i] = array[count - i - 1];
                array[count - i - 1] = temp;
            }
        }

        private void EnsureCapacity()
        {
            if (count == capacity)
            {
                capacity *= 2;
                object[] newArray = new object[capacity];

                for (int i = 0; i < count; i++)
                {
                    newArray[i] = array[i];
                }

                array = newArray;
            }
        }

        public object this[int index]
        {
            get
            {
                if (index >= 0 && index < count)
                {
                    return array[index];
                }
                throw new IndexOutOfRangeException();
            }
            set
            {
                if (index >= 0 && index < count)
                {
                    array[index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }
    }
}
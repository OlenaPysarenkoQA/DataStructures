using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
    public class List<T> : IList<T>, IEnumerable<T>
    {
        private T[] array;
        private int count;
        private int capacity;
        private ICollection<T> collection;

        public int Count => count;

        public List()
        {
            array = new T[4];
            count = 0;
            capacity = 4;
        }

        public List(int capacity)
        {
            array = new T[capacity];
            count = 0;
            this.capacity = capacity;
        }

        public List(ICollection<T> collection)
        {
            this.collection = collection;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public virtual void Add(T item)
        {
            EnsureCapacity();
            array[count] = item;
            count++;
        }

        public virtual void Insert(int index, T item)
        {
            EnsureCapacity();

            for (int i = count; i > index; i--)
            {
                array[i] = array[i - 1];
            }

            array[index] = item;
            count++;
        }

        public virtual void Remove(T item)
        {
            for (int i = 0; i < count; i++)
            {
                if (EqualityComparer<T>.Default.Equals(array[i], item))
                {
                    RemoveAt(i);
                    return;
                }
            }
        }

        public virtual void RemoveAt(int index)
        {
            if (index >= 0 && index < count)
            {
                for (int i = index; i < count - 1; i++)
                {
                    array[i] = array[i + 1];
                }
                array[count - 1] = default(T);
                count--;
            }
        }

        public virtual void Clear()
        {
            array = new T[capacity];
            count = 0;
        }

        public virtual bool Contains(T item)
        {
            for (int i = 0; i < count; i++)
            {
                if (EqualityComparer<T>.Default.Equals(array[i], item))
                {
                    return true;
                }
            }
            return false;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < count; i++)
            {
                if (EqualityComparer<T>.Default.Equals(array[i], item))
                {
                    return i;
                }
            }
            return -1;
        }

        public T[] ToArray()
        {
            T[] newArray = new T[count];
            Array.Copy(array, newArray, count);
            return newArray;
        }

        public void Reverse()
        {
            for (int i = 0; i < count / 2; i++)
            {
                T temp = array[i];
                array[i] = array[count - i - 1];
                array[count - i - 1] = temp;
            }
        }

        private void EnsureCapacity()
        {
            if (count == capacity)
            {
                capacity *= 2;
                T[] newArray = new T[capacity];

                for (int i = 0; i < count; i++)
                {
                    newArray[i] = array[i];
                }

                array = newArray;
            }
        }

        public virtual T this[int index]
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
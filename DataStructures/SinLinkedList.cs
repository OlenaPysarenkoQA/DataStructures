using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
    public class SinLinkedList<T> : ISinLinkedList<T>, IEnumerable<T>
    {
        private class Node
        {
            public readonly T value;
            public Node next;

            public Node(T value)
            {
                this.value = value;
                next = null;
            }
        }

        private Node first;
        private Node last;
        private int сount;

        public int Count => Count;
        
        public T FirstValue
        {
            get
            {
                if (first == null)
                {
                    throw new InvalidOperationException("List is empty");
                }

                return first.value;
            }
        }

        public T LastValue
        {
            get
            {
                if (last == null)
                {
                    throw new InvalidOperationException("List is empty");
                }

                return last.value;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node current = first;

            while (current != null)
            {
                yield return current.value;
                current = current.next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T value)
        {
            Node newNode = new Node(value);

            if (first == null)
            {
                first = newNode;
                last = newNode;
            }
            else
            {
                last.next = newNode;
                last = newNode;
            }

            сount++;
        }

        public void AddFirst(T value)
        {
            Node newNode = new Node(value);

            if (first == null)
            {
                first = newNode;
                last = newNode;
            }
            else
            {
                newNode.next = first;
                first = newNode;
            }

            сount++;
        }

        public void Insert(int index, T value)
        {
            if (index < 0 || index > Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range");
            }

            if (index == 0)
            {
                AddFirst(value);
            }
            else if (index == сount)
            {
                Add(value);
            }
            else
            {
                Node newNode = new Node(value);
                Node current = first;

                for (int i = 0; i < index - 1; i++)
                {
                    current = current.next;
                }

                newNode.next = current.next;
                current.next = newNode;

                сount++;
            }
        }

        public void Clear()
        {
            first = null;
            last = null;
            сount = 0;
        }

        public bool Contains(T value)
        {
            Node current = first;

            while (current != null)
            {
                if (ObjectEquals(current.value, value))
                {
                    return true;
                }

                current = current.next;
            }

            return false;
        }

        private bool ObjectEquals(T obj1, T obj2)
        {
            if (obj1 == null && obj2 == null)
            {
                return true;
            }

            if (obj1 == null || obj2 == null)
            {
                return false;
            }

            return obj1.Equals(obj2);
        }

        public T[] ToArray()
        {
            T[] result = new T[сount];
            Node current = first;

            for (int i = 0; i < сount; i++)
            {
                result[i] = current.value;
                current = current.next;
            }

            return result;
        }
    }
}

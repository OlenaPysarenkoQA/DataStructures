using System;

namespace DataStructures
{
    public class SinLinkedList
    {
        private class Node
        {
            public readonly object Value;
            public Node Next;

            public Node(object value)
            {
                Value = value;
                Next = null;
            }
        }

        private Node first;
        private Node last;
        private int сount;

        public int Count
        {
            get { return сount; }
        }

        public void Add(object value)
        {
            Node newNode = new Node(value);

            if (first == null)
            {
                first = newNode;
                last = newNode;
            }
            else
            {
                last.Next = newNode;
                last = newNode;
            }

            сount++;
        }

        public void AddFirst(object value)
        {
            Node newNode = new Node(value);

            if (first == null)
            {
                first = newNode;
                last = newNode;
            }
            else
            {
                newNode.Next = first;
                first = newNode;
            }

            сount++;
        }

        public void Insert(int index, object value)
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
                    current = current.Next;
                }

                newNode.Next = current.Next;
                current.Next = newNode;

                сount++;
            }
        }

        public void Clear()
        {
            first = null;
            last = null;
            сount = 0;
        }

        public bool Contains(object value)
        {
            Node current = first;

            while (current != null)
            {
                if (ObjectEquals(current.Value, value))
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        private bool ObjectEquals(object obj1, object obj2)
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

        public object[] ToArray()
        {
            object[] result = new object[сount];
            Node current = first;

            for (int i = 0; i < сount; i++)
            {
                result[i] = current.Value;
                current = current.Next;
            }

            return result;
        }

        public object FirstValue
        {
            get
            {
                if (first == null)
                {
                    throw new InvalidOperationException("List is empty");
                }

                return first.Value;
            }
        }

        public object LastValue
        {
            get
            {
                if (last == null)
                {
                    throw new InvalidOperationException("List is empty");
                }

                return last.Value;
            }
        }
    }
}

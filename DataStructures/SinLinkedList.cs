using System;

namespace DataStructures
{
    public class SinLinkedList
    {
        private class Node
        {
            public object Value;
            public Node Next;

            public Node(object value)
            {
                Value = value;
                Next = null;
            }
        }

        private Node First;
        private Node Last;
        private int сount;

        public void Add(object value)
        {
            Node newNode = new Node(value);

            if (First == null)
            {
                First = newNode;
                Last = newNode;
            }
            else
            {
                Last.Next = newNode;
                Last = newNode;
            }

            сount++;
        }

        public void AddFirst(object value)
        {
            Node newNode = new Node(value);

            if (First == null)
            {
                First = newNode;
                Last = newNode;
            }
            else
            {
                newNode.Next = First;
                First = newNode;
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
                Node current = First;

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
            First = null;
            Last = null;
            сount = 0;
        }

        public bool Contains(object value)
        {
            Node current = First;

            while (current != null)
            {
                if (ObjectEqualityCheck(current.Value, value))
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public object[] ToArray()
        {
            object[] result = new object[сount];
            Node current = First;

            for (int i = 0; i < сount; i++)
            {
                result[i] = current.Value;
                current = current.Next;
            }

            return result;
        }

        public int Count
        {
            get { return сount; }
        }

        public object FirstValue
        {
            get
            {
                if (First == null)
                {
                    throw new InvalidOperationException("List is empty");
                }

                return First.Value;
            }
        }

        public object LastValue
        {
            get
            {
                if (Last == null)
                {
                    throw new InvalidOperationException("List is empty");
                }

                return Last.Value;
            }
        }

        private bool ObjectEqualityCheck(object obj1, object obj2)
        {
            if (obj1 == null && obj2 == null)
            {
                return true;
            }

            if (obj1 == null || obj2 == null)
            {
                return false;
            }

            try
            {
                int intX = (int)obj1;
                int intY = (int)obj2;

                return intX == intY;
            }
            catch (InvalidCastException)
            {
                return false;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public interface ICollection
    {
        int Count { get; }
        bool Contains(object? item);
        object[] ToArray();
        void Clear();
    }

    public interface IList : ICollection
    {
        object this[int index] { get; set; }
        void Add(object item);
        void Insert(int index, object item);
        void Remove(object item);
        void RemoveAt(int index);
        int IndexOf(object item);
    }

    public interface ISinLinkedList : ICollection
    {
        void Add(object value);
        void AddFirst(object value);
        void Insert(int index, object value);
        object FirstValue { get; }
        object LastValue { get; }
    }

    public interface IBinaryTree : ICollection
    {
        void Add(object value);
    }

    public interface IQueue : ICollection
    {
        void Enqueue(object item);
        object Dequeue();
        object Peek();
    }

    public interface IStack : ICollection
    {
        void Push(object item);
        object Pop();
        object Peek();
    }
}

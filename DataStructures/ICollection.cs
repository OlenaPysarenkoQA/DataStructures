using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public interface ICollection<T>
    {
        int Count { get; }
        bool Contains(T item);
        T[] ToArray();
        void Clear();
    }

    public interface IList<T> : ICollection<T>
    {
        T this[int index] { get; set; }
        void Add(T item);
        void Insert(int index, T item);
        void Remove(T item);
        void RemoveAt(int index);
        int IndexOf(T item);
    }

    public interface ISinLinkedList<T> : ICollection<T>
    {
        void Add(T value);
        void AddFirst(T value);
        void Insert(int index, T value);
        T FirstValue { get; }
        T LastValue { get; }
    }

    public interface IBinaryTree<T> : ICollection<T>
    {
        void Add(T value);
    }

    public interface IQueue<T> : ICollection<T>
    {
        void Enqueue(T item);
        T Dequeue();
        T Peek();
    }

    public interface IStack<T> : ICollection<T>
    {
        void Push(T item);
        T Pop();
        T Peek();
    }

    public interface IObservableList<T> : ICollection<T>
    {
        T this[int index] { get; set; }
        void Add(T item);
        void Insert(int index, T item);
        void Remove(T item);
        void RemoveAt(int index);
        int IndexOf(T item);
    }
}

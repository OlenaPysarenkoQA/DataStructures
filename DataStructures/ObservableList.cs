using System;
using System.Collections.Generic;

namespace DataStructures
{
    public class ItemChangedEventArgs<T> : EventArgs
    {
        public T Item { get; }
        public int Index { get; }

        public ItemChangedEventArgs(T item, int index)
        {
            Item = item;
            Index = index;
        }
    }

    public class ObservableList<T> : List<T>, IObservableList<T>
    {
        public event EventHandler<ItemChangedEventArgs<T>>? ItemAdded;
        public event EventHandler<ItemChangedEventArgs<T>>? ItemInserted;
        public event EventHandler<ItemChangedEventArgs<T>>? ItemRemoved;
        public event EventHandler<ItemChangedEventArgs<T>>? ItemChanged;
        public event EventHandler ItemsCleared;

        public override T this[int index]
        {
            get => base[index];

            set
            {
                T oldItem = base[index];
                base[index] = value;
                OnItemChanged(new ItemChangedEventArgs<T>(oldItem, index));
            }
        }

        public override void Add(T item)
        {
            base.Add(item);
            OnItemAdded(new ItemChangedEventArgs<T>(item, Count - 1));
        }

        public override void Insert(int index, T item)
        {
            base.Insert(index, item);
            OnItemInserted(new ItemChangedEventArgs<T>(item, index));
        }

        public override void Remove(T item)
        {
            int index = IndexOf(item);
            if (index != -1)
            {
                RemoveAt(index);
            }
        }

        public override void RemoveAt(int index)
        {
            T removedItem = base[index];
            base.RemoveAt(index);
            OnItemRemoved(new ItemChangedEventArgs<T>(removedItem, index));
        }

        public override void Clear()
        {
            base.Clear();
            OnItemsCleared();
        }

        protected void OnItemAdded(ItemChangedEventArgs<T> e)
        {
            ItemAdded?.Invoke(this, e);
        }

        protected void OnItemInserted(ItemChangedEventArgs<T> e)
        {
            ItemInserted?.Invoke(this, e);
        }

        protected void OnItemRemoved(ItemChangedEventArgs<T> e)
        {
            ItemRemoved?.Invoke(this, e);
        }

        protected void OnItemChanged(ItemChangedEventArgs<T> e)
        {
            ItemChanged?.Invoke(this, e);
        }

        protected void OnItemsCleared()
        {
            ItemsCleared?.Invoke(this, EventArgs.Empty);
        }
    }
}
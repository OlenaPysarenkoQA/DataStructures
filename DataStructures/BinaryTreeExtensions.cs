using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public static class BinaryTreeExtensions
    {
        public static IEnumerable<T> Filter<T>(this IBinaryTree<T> tree, Func<T, bool> predicate)
        {
            foreach (var item in tree)
            {
                if (predicate(item))
                    yield return item;
            }
        }

        public static IEnumerable<T> Skip<T>(this IBinaryTree<T> tree, int count)
        {
            using var enumerator = tree.GetEnumerator();

            for (int i = 0; i < count && enumerator.MoveNext(); i++) { }

            while (enumerator.MoveNext())
            {
                yield return enumerator.Current;
            }
        }

        public static IEnumerable<T> SkipWhile<T>(this IBinaryTree<T> tree, Func<T, bool> predicate)
        {
            using var enumerator = tree.GetEnumerator();

            while (enumerator.MoveNext() && predicate(enumerator.Current)) { }

            while (enumerator.MoveNext())
            {
                yield return enumerator.Current;
            }
        }

        public static IEnumerable<T> Take<T>(this IBinaryTree<T> tree, int count)
        {
            using var enumerator = tree.GetEnumerator();

            for (int i = 0; i < count && enumerator.MoveNext(); i++)
            {
                yield return enumerator.Current;
            }
        }

        public static IEnumerable<T> TakeWhile<T>(this IBinaryTree<T> tree, Func<T, bool> predicate)
        {
            using var enumerator = tree.GetEnumerator();

            while (enumerator.MoveNext() && predicate(enumerator.Current))
            {
                yield return enumerator.Current;
            }
        }

        public static T First<T>(this IBinaryTree<T> tree, Func<T, bool> predicate)
        {
            foreach (var item in tree)
            {
                if (predicate(item))
                    return item;
            }

            throw new InvalidOperationException("no matching element");
        }

        public static T FirstOrDefault<T>(this IBinaryTree<T> tree, Func<T, bool> predicate)
        {
            foreach (var item in tree)
            {
                if (predicate(item))
                    return item;
            }

            return default;
        }

        public static T Last<T>(this IBinaryTree<T> tree, Func<T, bool> predicate)
        {
            T lastMatchingItem = default;
            bool found = false;

            foreach (var item in tree)
            {
                if (predicate(item))
                {
                    lastMatchingItem = item;
                    found = true;
                }
            }

            if (found)
                return lastMatchingItem;

            throw new InvalidOperationException("no matching element");
        }

        public static T LastOrDefault<T>(this IBinaryTree<T> tree, Func<T, bool> predicate)
        {
            T lastMatchingItem = default;

            foreach (var item in tree)
            {
                if (predicate(item))
                    lastMatchingItem = item;
            }

            return lastMatchingItem;
        }

        public static IEnumerable<TResult> Select<T, TResult>(this IBinaryTree<T> tree, Func<T, TResult> selector)
        {
            foreach (var item in tree)
            {
                yield return selector(item);
            }
        }

        public static IEnumerable<TResult> SelectMany<T, TResult>(this IBinaryTree<T> tree, Func<T, IEnumerable<TResult>> selector)
        {
            foreach (var item in tree)
            {
                foreach (var selected in selector(item))
                {
                    yield return selected;
                }
            }
        }

        public static bool All<T>(this IBinaryTree<T> tree, Func<T, bool> predicate)
        {
            foreach (var item in tree)
            {
                if (!predicate(item))
                    return false;
            }

            return true;
        }

        public static bool Any<T>(this IBinaryTree<T> tree, Func<T, bool> predicate)
        {
            foreach (var item in tree)
            {
                if (predicate(item))
                    return true;
            }

            return false;
        }

        public static T[] ToArray<T>(this IBinaryTree<T> tree)
        {
            var result = new List<T>();

            foreach (var item in tree)
            {
                result.Add(item);
            }

            return result.ToArray();
        }

        public static List<T> ToList<T>(this IBinaryTree<T> tree)
        {
            var result = new List<T>();

            foreach (var item in tree)
            {
                result.Add(item);
            }

            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public static class ListExtensions
    {
        public static IEnumerable<T> Filter<T>(this ICollection<T> collection, Func<T, bool> predicate)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));

            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            foreach (var item in collection)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }

        public static IEnumerable<T> Skip<T>(this ICollection<T> collection, int count)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));

            foreach (var item in collection)
            {
                if (count <= 0)
                    yield return item;
                else
                    count--;
            }
        }

        public static IEnumerable<T> SkipWhile<T>(this ICollection<T> collection, Func<T, bool> predicate)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));

            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            bool skip = true;
            foreach (var item in collection)
            {
                if (!predicate(item))
                {
                    skip = false;
                }

                if (!skip)
                {
                    yield return item;
                }
            }
        }

        public static IEnumerable<T> Take<T>(this ICollection<T> collection, int count)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));

            foreach (var item in collection)
            {
                if (count <= 0)
                    yield break;  
                else
                {
                    yield return item;
                    count--;
                }
            }
        }

        public static IEnumerable<T> TakeWhile<T>(this ICollection<T> collection, Func<T, bool> predicate)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));

            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            foreach (var item in collection)
            {
                if (predicate(item))
                {
                    yield return item;
                }
                else
                {
                    break;
                }
            }
        }

        public static T First<T>(this ICollection<T> collection, Func<T, bool> predicate)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));

            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            foreach (var item in collection)
            {
                if (predicate(item))
                {
                    return item;
                }
            }

            throw new InvalidOperationException("no matching element");
        }

        public static T FirstOrDefault<T>(this ICollection<T> collection, Func<T, bool> predicate)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));

            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            foreach (var item in collection)
            {
                if (predicate(item))
                {
                    return item;
                }
            }

            return default(T);
        }

        public static T Last<T>(this ICollection<T> collection, Func<T, bool> predicate)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));

            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            T lastItem = default(T);
            bool found = false;

            foreach (var item in collection)
            {
                if (predicate(item))
                {
                    lastItem = item;
                    found = true;
                }
            }

            if (found)
                return lastItem;
            else
                throw new InvalidOperationException("no matching element");
        }

        public static T LastOrDefault<T>(this ICollection<T> collection, Func<T, bool> predicate)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));

            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            T lastItem = default(T);

            foreach (var item in collection)
            {
                if (predicate(item))
                {
                    lastItem = item;
                }
            }

            return lastItem;
        }

        public static IEnumerable<TResult> Select<T, TResult>(this ICollection<T> collection, Func<T, TResult> selector)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));

            if (selector == null)
                throw new ArgumentNullException(nameof(selector));

            foreach (var item in collection)
            {
                yield return selector(item);
            }
        }

        public static IEnumerable<TResult> SelectMany<T, TResult>(this ICollection<T> collection, Func<T, IEnumerable<TResult>> selector)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));

            if (selector == null)
                throw new ArgumentNullException(nameof(selector));

            foreach (var item in collection)
            {
                foreach (var result in selector(item))
                {
                    yield return result;
                }
            }
        }

        public static bool All<T>(this ICollection<T> collection, Func<T, bool> predicate)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));

            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            foreach (var item in collection)
            {
                if (!predicate(item))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool Any<T>(this ICollection<T> collection, Func<T, bool> predicate)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));

            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            foreach (var item in collection)
            {
                if (predicate(item))
                {
                    return true;
                }
            }

            return false;
        }

        public static T[] ToArray<T>(this ICollection<T> collection)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));

            return collection.ToArray();
        }

        public static List<T> ToList<T>(this ICollection<T> collection)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));

            return new List<T>(collection);
        }
    }
}

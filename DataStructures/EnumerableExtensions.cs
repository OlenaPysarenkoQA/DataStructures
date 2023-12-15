using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            foreach (var item in source)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }

        public static IEnumerable<T> Skip<T>(this IEnumerable<T> source, int count)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            foreach (var item in source)
            {
                if (count <= 0)
                    yield return item;
                else
                    count--;
            }
        }

        public static IEnumerable<T> SkipWhile<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            bool skip = true;
            foreach (var item in source)
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

        public static IEnumerable<T> Take<T>(this IEnumerable<T> source, int count)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            foreach (var item in source)
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

        public static IEnumerable<T> TakeWhile<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            foreach (var item in source)
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

        public static T First<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            foreach (var item in source)
            {
                if (predicate(item))
                {
                    return item;
                }
            }

            throw new InvalidOperationException("no matching element");
        }

        public static T FirstOrDefault<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            foreach (var item in source)
            {
                if (predicate(item))
                {
                    return item;
                }
            }

            return default(T);
        }

        public static T Last<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            T lastItem = default(T);
            bool found = false;

            foreach (var item in source)
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

        public static T LastOrDefault<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            T lastItem = default(T);

            foreach (var item in source)
            {
                if (predicate(item))
                {
                    lastItem = item;
                }
            }

            return lastItem;
        }

        public static IEnumerable<TResult> Select<T, TResult>(this IEnumerable<T> source, Func<T, TResult> selector)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (selector == null)
                throw new ArgumentNullException(nameof(selector));

            foreach (var item in source)
            {
                yield return selector(item);
            }
        }

        public static IEnumerable<TResult> SelectMany<T, TResult>(this IEnumerable<T> source, Func<T, IEnumerable<TResult>> selector)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (selector == null)
                throw new ArgumentNullException(nameof(selector));

            foreach (var item in source)
            {
                foreach (var result in selector(item))
                {
                    yield return result;
                }
            }
        }

        public static bool All<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            foreach (var item in source)
            {
                if (!predicate(item))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool Any<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            foreach (var item in source)
            {
                if (predicate(item))
                {
                    return true;
                }
            }

            return false;
        }

        public static T[] ToArray<T>(this IEnumerable<T> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return source.ToArray();
        }

        public static List<T> ToList<T>(this IEnumerable<T> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return source.ToList();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public static class SinLinkedListExtensions
    {
        public static IEnumerable<T> Filter<T>(this ISinLinkedList<T> list, Func<T, bool> predicate)
        {
            foreach (var item in list)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }
        public static IEnumerable<T> Skip<T>(this ISinLinkedList<T> list, int count)
        {
            int skipped = 0;
            foreach (var item in list)
            {
                if (skipped < count)
                {
                    skipped++;
                }
                else
                {
                    yield return item;
                }
            }
        }

        public static IEnumerable<T> SkipWhile<T>(this ISinLinkedList<T> list, Func<T, bool> predicate)
        {
            bool skipping = true;
            foreach (var item in list)
            {
                if (skipping && predicate(item))
                {
                    continue;
                }

                skipping = false;
                yield return item;
            }
        }

        public static IEnumerable<T> Take<T>(this ISinLinkedList<T> list, int count)
        {
            int taken = 0;
            foreach (var item in list)
            {
                if (taken < count)
                {
                    yield return item;
                    taken++;
                }
                else
                {
                    yield break;
                }
            }
        }

        public static IEnumerable<T> TakeWhile<T>(this ISinLinkedList<T> list, Func<T, bool> predicate)
        {
            foreach (var item in list)
            {
                if (predicate(item))
                {
                    yield return item;
                }
                else
                {
                    yield break;
                }
            }
        }

        public static T First<T>(this ISinLinkedList<T> list, Func<T, bool> predicate)
        {
            foreach (var item in list)
            {
                if (predicate(item))
                {
                    return item;
                }
            }

            throw new InvalidOperationException("No matching element found.");
        }

        public static T FirstOrDefault<T>(this ISinLinkedList<T> list, Func<T, bool> predicate)
        {
            foreach (var item in list)
            {
                if (predicate(item))
                {
                    return item;
                }
            }

            return default(T);
        }

        public static T Last<T>(this ISinLinkedList<T> list, Func<T, bool> predicate)
        {
            T lastMatch = default(T);
            bool found = false;

            foreach (var item in list)
            {
                if (predicate(item))
                {
                    lastMatch = item;
                    found = true;
                }
            }

            if (found)
            {
                return lastMatch;
            }

            throw new InvalidOperationException("No matching element found.");
        }

        public static T LastOrDefault<T>(this ISinLinkedList<T> list, Func<T, bool> predicate)
        {
            T lastMatch = default(T);

            foreach (var item in list)
            {
                if (predicate(item))
                {
                    lastMatch = item;
                }
            }

            return lastMatch;
        }

        public static IEnumerable<TResult> Select<T, TResult>(this ISinLinkedList<T> list, Func<T, TResult> selector)
        {
            foreach (var item in list)
            {
                yield return selector(item);
            }
        }

        public static IEnumerable<TResult> SelectMany<T, TResult>(this ISinLinkedList<T> list, Func<T, IEnumerable<TResult>> selector)
        {
            foreach (var item in list)
            {
                foreach (var result in selector(item))
                {
                    yield return result;
                }
            }
        }

        public static bool All<T>(this ISinLinkedList<T> list, Func<T, bool> predicate)
        {
            foreach (var item in list)
            {
                if (!predicate(item))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool Any<T>(this ISinLinkedList<T> list, Func<T, bool> predicate)
        {
            foreach (var item in list)
            {
                if (predicate(item))
                {
                    return true;
                }
            }

            return false;
        }

        public static T[] ToArray<T>(this ISinLinkedList<T> list)
        {
            return list.ToArray();
        }

        public static List<T> ToList<T>(this ISinLinkedList<T> list)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            var result = new List<T>();

            foreach (var item in list)
            {
                result.Add(item);
            }

            return result;
        }
    }
}

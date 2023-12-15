using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public static class StackExtensions
    {
        public static IEnumerable<T> Filter<T>(this IStack<T> stack, Func<T, bool> predicate)
        {
            foreach (var item in stack)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }

        public static IEnumerable<T> Skip<T>(this IStack<T> stack, int count)
        {
            int skipped = 0;
            foreach (var item in stack)
            {
                if (skipped < count)
                {
                    skipped++;
                    continue;
                }

                yield return item;
            }
        }

        public static IEnumerable<T> SkipWhile<T>(this IStack<T> stack, Func<T, bool> predicate)
        {
            bool skipping = true;
            foreach (var item in stack)
            {
                if (skipping && predicate(item))
                {
                    continue;
                }

                skipping = false;
                yield return item;
            }
        }

        public static IEnumerable<T> Take<T>(this IStack<T> stack, int count)
        {
            int taken = 0;
            foreach (var item in stack)
            {
                if (taken < count)
                {
                    yield return item;
                    taken++;
                }
                else
                {
                    break;
                }
            }
        }

        public static IEnumerable<T> TakeWhile<T>(this IStack<T> stack, Func<T, bool> predicate)
        {
            foreach (var item in stack)
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

        public static T First<T>(this IStack<T> stack, Func<T, bool> predicate)
        {
            foreach (var item in stack)
            {
                if (predicate(item))
                {
                    return item;
                }
            }

            throw new InvalidOperationException("Sequence contains no matching element");
        }

        public static T FirstOrDefault<T>(this IStack<T> stack, Func<T, bool> predicate)
        {
            foreach (var item in stack)
            {
                if (predicate(item))
                {
                    return item;
                }
            }

            return default(T);
        }

        public static T Last<T>(this IStack<T> stack, Func<T, bool> predicate)
        {
            T lastItem = default(T);
            bool found = false;

            foreach (var item in stack)
            {
                if (predicate(item))
                {
                    lastItem = item;
                    found = true;
                }
            }

            if (found)
            {
                return lastItem;
            }

            throw new InvalidOperationException("Sequence contains no matching element");
        }

        public static T LastOrDefault<T>(this IStack<T> stack, Func<T, bool> predicate)
        {
            T lastItem = default(T);
            bool found = false;

            foreach (var item in stack)
            {
                if (predicate(item))
                {
                    lastItem = item;
                    found = true;
                }
            }

            if (found)
            {
                return lastItem;
            }

            return default(T);
        }

        public static IEnumerable<TResult> Select<T, TResult>(this IStack<T> stack, Func<T, TResult> selector)
        {
            foreach (var item in stack)
            {
                yield return selector(item);
            }
        }

        public static IEnumerable<TResult> SelectMany<T, TResult>(this IStack<T> stack, Func<T, IEnumerable<TResult>> selector)
        {
            foreach (var item in stack)
            {
                foreach (var result in selector(item))
                {
                    yield return result;
                }
            }
        }

        public static bool All<T>(this IStack<T> stack, Func<T, bool> predicate)
        {
            foreach (var item in stack)
            {
                if (!predicate(item))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool Any<T>(this IStack<T> stack, Func<T, bool> predicate)
        {
            foreach (var item in stack)
            {
                if (predicate(item))
                {
                    return true;
                }
            }
            return false;
        }

        public static T[] ToArray<T>(this IStack<T> stack)
        {
            return stack.ToArray();
        }

        public static List<T> ToList<T>(this IStack<T> stack)
        {
            if (stack == null)
                throw new ArgumentNullException(nameof(stack));

            var result = new List<T>();

            foreach (var item in stack)
            {
                result.Add(item);
            }

            return result;
        }
    }
}


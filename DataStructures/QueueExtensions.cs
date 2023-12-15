using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures
{
    public static class QueueExtensions
    {
        public static IEnumerable<T> Filter<T>(this IQueue<T> queue, Func<T, bool> predicate)
        {
            foreach (var item in queue)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }

        public static IEnumerable<T> Skip<T>(this IQueue<T> queue, int count)
        {
            return queue.SkipWhile((item, index) => index < count);
        }

        public static IEnumerable<T> SkipWhile<T>(this IQueue<T> queue, Func<T, int, bool> predicate)
        {
            int index = 0;
            foreach (var item in queue)
            {
                if (!predicate(item, index++))
                {
                    yield return item;
                }
            }
        }

        public static IEnumerable<T> Take<T>(this IQueue<T> queue, int count)
        {
            return queue.TakeWhile((item, index) => index < count);
        }

        public static IEnumerable<T> TakeWhile<T>(this IQueue<T> queue, Func<T, int, bool> predicate)
        {
            int index = 0;
            foreach (var item in queue)
            {
                if (predicate(item, index++))
                {
                    yield return item;
                }
                else
                {
                    yield break; 
                }
            }
        }

        public static T First<T>(this IQueue<T> queue, Func<T, bool> predicate)
        {
            return queue.Filter(predicate).First();
        }

        public static T FirstOrDefault<T>(this IQueue<T> queue, Func<T, bool> predicate)
        {
            return queue.Filter(predicate).FirstOrDefault();
        }

        public static T Last<T>(this IQueue<T> queue, Func<T, bool> predicate)
        {
            return queue.Reverse().Where(predicate).Last();
        }

        public static T LastOrDefault<T>(this IQueue<T> queue, Func<T, bool> predicate)
        {
            return queue.Reverse().Where(predicate).LastOrDefault();
        }

        public static IEnumerable<TResult> Select<T, TResult>(this IQueue<T> queue, Func<T, TResult> selector)
        {
            return queue.SelectMany(item => new[] { selector(item) });
        }

        public static IEnumerable<TResult> SelectMany<T, TResult>(this IQueue<T> queue, Func<T, IEnumerable<TResult>> selector)
        {
            foreach (var item in queue)
            {
                foreach (var result in selector(item))
                {
                    yield return result;
                }
            }
        }

        public static bool All<T>(this IQueue<T> queue, Func<T, bool> predicate)
        {
            return queue.All((item, index) => predicate(item));
        }

        public static bool All<T>(this IQueue<T> queue, Func<T, int, bool> predicate)
        {
            int index = 0;
            foreach (var item in queue)
            {
                if (!predicate(item, index++))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool Any<T>(this IQueue<T> queue, Func<T, bool> predicate)
        {
            return queue.Any((item, index) => predicate(item));
        }

        public static bool Any<T>(this IQueue<T> queue, Func<T, int, bool> predicate)
        {
            int index = 0;
            foreach (var item in queue)
            {
                if (predicate(item, index++))
                {
                    return true;
                }
            }
            return false;
        }

        public static T[] ToArray<T>(this IQueue<T> queue)
        {
            return queue.ToArray();
        }

        public static List<T> ToList<T>(this IQueue<T> queue)
        {
            if (queue == null)
                throw new ArgumentNullException(nameof(queue));

            var result = new List<T>();

            foreach (var item in queue)
            {
                result.Add(item);
            }

            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Tests
{
    public static class TestQueueExtensions
    {
        public static void RunTestQueueExtensions()

        {
            IQueue<int> myQueue = new Queue<int>();
            myQueue.Enqueue(1);
            myQueue.Enqueue(2);
            myQueue.Enqueue(3);

            var filteredQueue = myQueue.Filter(x => x % 2 == 0);
            var skippedQueue = myQueue.Skip(1);
            var takenQueue = myQueue.Take(2);
            var firstItem = myQueue.First(x => x % 2 == 0);
            var lastItem = myQueue.Last(x => x % 2 == 0);
            var selectedQueue = myQueue.Select(x => x * 2);
            var allEven = myQueue.All(x => x % 2 == 0);
            var anyEven = myQueue.Any(x => x % 2 == 0);
            var toArray = myQueue.ToArray();
            var toList = myQueue.ToList();

            Console.WriteLine("Filtered Queue:");
            foreach (var item in filteredQueue)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Skipped Queue:");
            foreach (var item in skippedQueue)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Taken Queue:");
            foreach (var item in takenQueue)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("First Item: " + firstItem);
            Console.WriteLine("Last Item: " + lastItem);

            Console.WriteLine("Selected Queue:");
            foreach (var item in selectedQueue)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("All items are even: " + allEven);
            Console.WriteLine("Any item is even: " + anyEven);

            Console.WriteLine("Array:");
            foreach (var item in toArray)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("List:");
            foreach (var item in toList)
            {
                Console.WriteLine(item);
            }
        }
    }
}

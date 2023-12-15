using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Tests
{
    public static class TestStackExtensions
    {
        public static void RunTestStackExtensions()
        {
            var stack = new Stack<int>();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);

            Console.WriteLine("Original Stack:");
            PrintStack(stack);

            var filteredStack = stack.Filter(x => x % 2 == 0);
            Console.WriteLine("\nFiltered Stack (Even numbers):");
            PrintStack(filteredStack);

            var skippedStack = stack.Skip(2);
            Console.WriteLine("\nStack after skipping 2 elements:");
            PrintStack(skippedStack);

            var takenStack = stack.Take(3);
            Console.WriteLine("\nStack after taking 3 elements:");
            PrintStack(takenStack);

            var firstElement = stack.First(x => x > 2);
            Console.WriteLine($"\nFirst element greater than 2: {firstElement}");

            var lastElement = stack.Last(x => x < 4);
            Console.WriteLine($"Last element less than 4: {lastElement}");

            var squaredStack = stack.Select(x => x * x);
            Console.WriteLine("\nStack after squaring each element:");
            PrintStack(squaredStack);

            bool allGreaterThanZero = stack.All(x => x > 0);
            Console.WriteLine($"\nAre all elements greater than 0? {allGreaterThanZero}");

            bool anyEven = stack.Any(x => x % 2 == 0);
            Console.WriteLine($"Is there any even element? {anyEven}");

            var stackArray = stack.ToArray();
            Console.WriteLine("\nStack as array:");
            foreach (var item in stackArray)
            {
                Console.Write(item + " ");
            }

            var stackList = stack.ToList();
            Console.WriteLine("\nStack as List:");
            foreach (var item in stackList)
            {
                Console.Write(item + " ");
            }
        }

        static void PrintStack<T>(IEnumerable<T> stack)
        {
            foreach (var item in stack.Reverse())
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}

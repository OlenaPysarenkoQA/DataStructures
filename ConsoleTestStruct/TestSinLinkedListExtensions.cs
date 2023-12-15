using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Tests
{
     public static class TestSinLinkedListExtensions
    {
        public static void RunTestSinLinkedListExtensions()
        {
            var linkedList = new SinLinkedList<int>();
            linkedList.Add(1);
            linkedList.Add(2);
            linkedList.Add(3);
            linkedList.Add(4);
            linkedList.Add(5);

            Console.WriteLine("Original List:");
            PrintList(linkedList);

            Console.WriteLine("\nFilter (even numbers):");
            PrintList(linkedList.Filter(x => x % 2 == 0));

            Console.WriteLine("\nSkip 2 elements:");
            PrintList(linkedList.Skip(2));

            Console.WriteLine("\nSkipWhile (x < 4):");
            PrintList(linkedList.SkipWhile(x => x < 4));

            Console.WriteLine("\nTake 3 elements:");
            PrintList(linkedList.Take(3));

            Console.WriteLine("\nTakeWhile (x < 4):");
            PrintList(linkedList.TakeWhile(x => x < 4));

            Console.WriteLine("\nFirst (x > 2): " + linkedList.First(x => x > 2));

            Console.WriteLine("\nFirstOrDefault (x > 10): " + linkedList.FirstOrDefault(x => x > 10));

            Console.WriteLine("\nLast (x > 2): " + linkedList.Last(x => x > 2));

            Console.WriteLine("\nLastOrDefault (x > 10): " + linkedList.LastOrDefault(x => x > 10));

            Console.WriteLine("\nSelect (x * 2):");
            PrintList(linkedList.Select(x => x * 2));

            Console.WriteLine("\nAll (x < 10): " + linkedList.All(x => x < 10));

            Console.WriteLine("\nAny (x > 5): " + linkedList.Any(x => x > 5));

            Console.WriteLine("\nToArray:");
            var array = linkedList.ToArray();
            PrintArray(array);

            Console.WriteLine("\nToList:");
            var list = linkedList.ToList();
            PrintList(list);
        }

        static void PrintList<T>(IEnumerable<T> list)
        {
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        static void PrintArray<T>(T[] array)
        {
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
     }
}

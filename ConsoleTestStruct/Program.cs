using System;
using System.Collections.Generic;
using DataStructures;

namespace DataStructures.Tests
{
    class Program
    {
        static void Main()
        {
            TestListExtensions.RunTestListExtensions();
            Console.ReadKey();

            TestSinLinkedListExtensions.RunTestSinLinkedListExtensions();
            Console.ReadKey();

            TestQueueExtensions.RunTestQueueExtensions();
            Console.ReadKey();

            TestStackExtensions.RunTestStackExtensions();
            Console.ReadKey();

            TestBinaryTreeExtansions.RunTestBinaryTreeExtansions();
            Console.ReadKey();

            TestObservableList.RunTests();
            Console.ReadKey();
        }

        static void PrintCollection<T>(IEnumerable<T> collection)
        {
            Console.WriteLine("Collection elements:");
            foreach (var item in collection.ToArray())
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Tests
{
    public static class TestListExtensions
    {
        public static void RunTestListExtensions()
        {
            DataStructures.IList<int> myList = new DataStructures.List<int>();

            myList.Add(1);
            myList.Add(2);
            myList.Add(3);
            myList.Add(4);
            myList.Add(5);
            myList.Add(6);

            Console.WriteLine("Filtered List (Even Numbers):");
            var filteredList = myList.Filter(x => x % 2 == 0);
            PrintCollection<int>(filteredList);

            Console.WriteLine("Skipped 3 elements:");
            var skippedList = myList.Skip(3);
            PrintCollection<int>(skippedList);

            Console.WriteLine("Taken 2 elements:");
            var takenList = myList.Take(2);
            PrintCollection<int>(takenList);

            Console.WriteLine("First element greater than 2: " + (myList.Any() ? myList.First(x => x > 2) : "No matching element"));

            Console.WriteLine("Last element less than 5: " + (myList.Any() ? myList.Last(x => x < 5) : "No matching element"));

            Console.WriteLine("Selected squared elements:");
            var squaredList = myList.Select(x => x * x);
            PrintCollection<int>(squaredList);

            Console.WriteLine("All elements greater than 0: " + myList.All(x => x > 0));

            Console.WriteLine("Any element equal to 5: " + myList.Any(x => x == 5));

            Console.WriteLine("List as array: " + string.Join(", ", myList.ToArray()));

            Console.WriteLine("List as list: " + string.Join(", ", myList.ToList()));
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

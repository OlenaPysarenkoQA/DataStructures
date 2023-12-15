using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Tests
{
    public static class TestBinaryTreeExtansions
    {
        public static void RunTestBinaryTreeExtansions()
        {
            var binaryTree = new BinaryTree<int>();
            binaryTree.Add(5);
            binaryTree.Add(3);
            binaryTree.Add(7);
            binaryTree.Add(2);
            binaryTree.Add(4);
            binaryTree.Add(6);
            binaryTree.Add(8);

            Console.WriteLine("Original Binary Tree:");
            Console.WriteLine(string.Join(", ", binaryTree.ToArray()));

            var filteredTree = binaryTree.Filter(x => x % 2 == 0);
            Console.WriteLine("\nFiltered Binary Tree (Even numbers):");
            Console.WriteLine(string.Join(", ", filteredTree));

            var skippedTree = binaryTree.Skip(2);
            Console.WriteLine("\nSkipped Binary Tree (First 2 elements skipped):");
            Console.WriteLine(string.Join(", ", skippedTree));

            var skippedWhileTree = binaryTree.SkipWhile(x => x < 5);
            Console.WriteLine("\nSkipped While Binary Tree (Elements skipped while less than 5):");
            Console.WriteLine(string.Join(", ", skippedWhileTree));

            var takenTree = binaryTree.Take(3);
            Console.WriteLine("\nTaken Binary Tree (First 3 elements taken):");
            Console.WriteLine(string.Join(", ", takenTree));

            var takenWhileTree = binaryTree.TakeWhile(x => x < 5);
            Console.WriteLine("\nTaken While Binary Tree (Elements taken while less than 5):");
            Console.WriteLine(string.Join(", ", takenWhileTree));

            var firstElement = binaryTree.First(x => x % 2 == 0);
            Console.WriteLine($"\nFirst Even Element: {firstElement}");

            var firstOrDefaultElement = binaryTree.FirstOrDefault(x => x > 10);
            Console.WriteLine($"First Element Greater Than 10 (or default if not found): {firstOrDefaultElement}");

            var lastElement = binaryTree.Last(x => x % 2 == 0);
            Console.WriteLine($"Last Even Element: {lastElement}");

            var lastOrDefaultElement = binaryTree.LastOrDefault(x => x > 10);
            Console.WriteLine($"Last Element Greater Than 10 (or default if not found): {lastOrDefaultElement}");

            var squaredTree = binaryTree.Select(x => x * x);
            Console.WriteLine("\nSquared Binary Tree:");
            Console.WriteLine(string.Join(", ", squaredTree));

            var multipliedTree = binaryTree.SelectMany(x => new[] { x, x * 2 });
            Console.WriteLine("\nMultiplied Binary Tree (Each element and its double):");
            Console.WriteLine(string.Join(", ", multipliedTree));

            var allEven = binaryTree.All(x => x % 2 == 0);
            Console.WriteLine($"\nAre All Elements Even? {allEven}");

            var anyGreaterThan10 = binaryTree.Any(x => x > 10);
            Console.WriteLine($"Are Any Elements Greater Than 10? {anyGreaterThan10}");

            var treeArray = binaryTree.ToArray();
            Console.WriteLine("\nBinary Tree as Array:");
            Console.WriteLine(string.Join(", ", treeArray));

            var treeList = binaryTree.ToList();
            Console.WriteLine("\nBinary Tree as List:");
            Console.WriteLine(string.Join(", ", treeList));
        }
    }
}

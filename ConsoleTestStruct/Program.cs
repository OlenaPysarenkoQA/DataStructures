﻿using System;
using DataStructures;

namespace ConsoleTestStruct
{
    class Program
    {
        static void Main()
        {
            List myList = new List();
            Console.WriteLine("List created!");

            myList.Add(1);
            myList.Add(2);
            myList.Add(3);
            Console.WriteLine("List after adding elements:");

            PrintList(myList);

            myList.Insert(1, 4);
            Console.WriteLine("List after inserting 4 at index 1:");

            PrintList(myList);

            myList.Remove(3);
            Console.WriteLine("Contains 3: " + myList.Contains(3));

            PrintList(myList);

            myList.Reverse();
            Console.WriteLine("List after reversing:");

            PrintList(myList);

            Console.WriteLine("Element at index 1: " + myList[1]);
            Console.WriteLine("List count: " + myList.Count);

            myList.Clear();
            Console.WriteLine("List after clearing:");
            Console.WriteLine("List count after clearing: " + myList.Count);

            BinaryTree binaryTree = new BinaryTree();

            binaryTree.Add(1);
            binaryTree.Add(3);
            binaryTree.Add(4);
            binaryTree.Add(5);
            binaryTree.Add(6);
            binaryTree.Add(7);
            binaryTree.Add(8);

            Console.WriteLine("BinaryTree Contains 3: " + binaryTree.Contains(3));
            Console.WriteLine("BinaryTree Contains 2: " + binaryTree.Contains(9));

            Console.WriteLine("Count: " + binaryTree.Count);

            binaryTree.Clear();
            Console.WriteLine("BinaryTree count elements after clearing: " + binaryTree.Count);

            binaryTree.Add(10);
            binaryTree.Add(15);
            binaryTree.Add(5);
            binaryTree.Add(3);
            binaryTree.Add(1);

            object[] array = binaryTree.ToArray();
            Console.WriteLine("Array: " + string.Join(", ", array));

            Queue myQueue = new Queue();

            myQueue.Enqueue(1);
            myQueue.Enqueue(2);
            myQueue.Enqueue(3);

            Console.WriteLine($"Queue count: {myQueue.Count}");

            Console.WriteLine("Queue elements:");
            foreach (var item in myQueue.ToArray())
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"Peek: {myQueue.Peek()}");

            Console.WriteLine($"Queue contains 1: {myQueue.Contains(1)}");
            Console.WriteLine($"Queue contains 5: {myQueue.Contains(5)}");

            Console.WriteLine("Dequeue elements:");
            while (myQueue.Count > 0)
            {
                Console.WriteLine(myQueue.Dequeue());
            }

            Console.WriteLine($"Count after dequeue: {myQueue.Count}");

            Stack stack = new Stack();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Console.WriteLine($"Stack count: {stack.Count}");

            Console.WriteLine($"Stack contains 2: {stack.Contains(2)}");

            Console.WriteLine($"Peek: {stack.Peek()}");

            Console.WriteLine($"Pop: {stack.Pop()}");

            Console.WriteLine($"Peek after Pop: {stack.Peek()}");

            object[] arraySt = stack.ToArray();
            Console.WriteLine("Stack as array:");
            foreach (var item in arraySt)
            {
                Console.WriteLine(item);
            }

            stack.Clear();

            Console.WriteLine($"Stack count after Clear: {stack.Count}");

            SinLinkedList list = new SinLinkedList();

            list.Add(1);
            list.Add(2);
            list.Add(3);

            Console.WriteLine("List elements:");
            PrintList(list);

            list.AddFirst(0);

            list.Insert(2, 100);

            Console.WriteLine("List elements after modifications:");
            PrintList(list);

            Console.WriteLine("List contains 100: " + list.Contains(100));
            Console.WriteLine("List contains 5: " + list.Contains(5));

            Console.ReadLine();
        }

        static void PrintList(List list)
        {
            object[] array = list.ToArray();
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }

        static void PrintList(SinLinkedList list)
        {
            foreach (var item in list.ToArray())
            {
                Console.WriteLine(item);
            }
        }
    }
}
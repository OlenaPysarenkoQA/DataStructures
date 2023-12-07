using System;

namespace DataStructures.Tests
{
    public static class TestObservableList
    {
        public static void RunTests()
        {
            AddToListTest();
            InsertToListTest();
            RemoveFromListTest();
            ChangeListItemTest();
            ClearListTest();

            Console.ReadLine();
        }

        static void AddToListTest()
        {
            var observableList = new ObservableList<int>();

            observableList.ItemAdded += OnItemAdded;

            observableList.Add(1);
            observableList.Add(2);
            observableList.Add(3);

            bool isSuccess =
                observableList.Count == 3 &&
                observableList[0] == 1 &&
                observableList[1] == 2 &&
                observableList[2] == 3;

            ShowTestResult("Add to List", isSuccess);

            observableList.ItemAdded -= OnItemAdded;
        }

        static void InsertToListTest()
        {
            var observableList = new ObservableList<int>();

            observableList.ItemInserted += OnItemInserted;

            observableList.Add(1);
            observableList.Add(3);

            observableList.Insert(1, 2);

            bool isSuccess =
                observableList.Count == 3 &&
                observableList[0] == 1 &&
                observableList[1] == 2 &&
                observableList[2] == 3;

            ShowTestResult("Insert to List", isSuccess);

            observableList.ItemInserted -= OnItemInserted;
        }

        static void RemoveFromListTest()
        {
            var observableList = new ObservableList<int>();

            observableList.ItemRemoved += OnItemRemoved;

            observableList.Add(1);
            observableList.Add(2);
            observableList.Add(3);

            observableList.Remove(2);

            bool isSuccess =
                observableList.Count == 2 &&
                observableList[0] == 1 &&
                observableList[1] == 3;

            ShowTestResult("Remove from List", isSuccess);

            observableList.ItemRemoved -= OnItemRemoved;
        }

        static void ChangeListItemTest()
        {
            var observableList = new ObservableList<int>();

            observableList.ItemChanged += OnItemChanged;

            observableList.Add(1);
            observableList.Add(2);
            observableList.Add(3);

            observableList[1] = 4;

            bool isSuccess =
                observableList.Count == 3 &&
                observableList[0] == 1 &&
                observableList[1] == 4 &&
                observableList[2] == 3;

            ShowTestResult("Change List Item", isSuccess);

            observableList.ItemChanged -= OnItemChanged;
        }

        static void ClearListTest()
        {
            var observableList = new ObservableList<int>();

            observableList.ItemsCleared += OnItemsCleared;

            observableList.Add(1);
            observableList.Add(2);
            observableList.Add(3);

            observableList.Clear();

            bool isSuccess =
                observableList.Count == 0;

            ShowTestResult("Clear List", isSuccess);

            observableList.ItemsCleared -= OnItemsCleared;
        }

        static void OnItemAdded(object sender, ItemChangedEventArgs<int> e)
        {
            Console.WriteLine($"Item Added: {e.Item} at Index: {e.Index}");
        }

        static void OnItemInserted(object sender, ItemChangedEventArgs<int> e)
        {
            Console.WriteLine($"Item Inserted: {e.Item} at Index: {e.Index}");
        }

        static void OnItemRemoved(object sender, ItemChangedEventArgs<int> e)
        {
            Console.WriteLine($"Item Removed: {e.Item} at Index: {e.Index}");
        }

        static void OnItemChanged(object sender, ItemChangedEventArgs<int> e)
        {
            Console.WriteLine($"Item Changed: Old Value: {e.Item} at Index: {e.Index}");
        }

        static void OnItemsCleared(object sender, EventArgs e)
        {
            Console.WriteLine("All items cleared");
        }

        private static void ShowTestResult(string testName, bool isSuccess)
        {
            Console.ResetColor();
            Console.Write($"{testName}: ");

            string resultMsg = isSuccess ? "SUCCESS!" : "FAILED!";
            Console.BackgroundColor = isSuccess ? ConsoleColor.Green : ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(resultMsg);
            Console.ResetColor();
        }
    }
}
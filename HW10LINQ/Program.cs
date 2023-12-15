Console.WriteLine(string.Join(", ", Enumerable.Range(10, 41)) + "\n");

Console.WriteLine(string.Join(", ", Enumerable.Range(10, 41).Where(x => x % 3 == 0)) + "\n");

Console.WriteLine(string.Concat(Enumerable.Repeat("Linq", 10)) + "\n");

Console.WriteLine(string.Join(", ", "aaa;abb;ccc;dap".Split(';').Where(word => word.Contains('a'))) + "\n");

Console.WriteLine(string.Join(", ", "aaa;abb;ccc;dap".Split(';').Select(word => word.Count(c => c == 'a'))) + "\n");

Console.WriteLine("aaa;xabbx;abb;ccc;dap".Split(';').Any(word => word == "abb") + "\n");

Console.WriteLine("aaa;xabbx;abb;ccc;dap".Split(';').OrderByDescending(word => word.Length).First() + "\n");

Console.WriteLine("aaa;xabbx;abb;ccc;dap".Split(';').Average(word => word.Length) + "\n");

Console.WriteLine("aaa;xabbx;abb;ccc;dap;zh".Split(';').OrderBy(word => word.Length).First() + "\n");

Console.WriteLine("baaa;aabb;aaa;xabbx;abb;ccc;dap;zh".Split(';').FirstOrDefault(word => word.StartsWith("aa") && word.Skip(2).All(c => c == 'b')) != null);

Console.WriteLine("baaa;aabb;aaa;xabbx;abb;ccc;dap;zh".Split(';').Skip(2).Where(word => word.EndsWith("bb")).Skip(2).LastOrDefault() != null);


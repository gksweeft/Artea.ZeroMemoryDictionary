using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Artea.ZeroMemoryDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict1 = new ZeroMemoryDictionary();

            dict1.Add("1", "some text");
            dict1.TryAdd("1", "some more text");
            dict1.Add("2", "some text 2");
            dict1["2"] = "some more text 2";

            Console.WriteLine(nameof(dict1));
            Console.WriteLine($"Count: {dict1.Count}");

            foreach (var item in dict1)
            {
                Console.WriteLine($"{item.Key} = {item.Value}");
            }

            Console.WriteLine();
            Console.WriteLine("=====================================");
            Console.WriteLine();

            var dict2 = new ZeroMemoryDictionary();

            dict2.Add("1", "some text");

            Console.WriteLine(nameof(dict2));
            Console.WriteLine($"Count: {dict2.Count}");

            foreach (var item in dict2)
            {
                Console.WriteLine($"{item.Key} = {item.Value}");
            }

            Console.WriteLine();
            Console.WriteLine("=====================================");
            Console.WriteLine();

            var namedDict1 = new ZeroMemoryDictionary("namedStore");

            namedDict1.TryAdd("1", "some text");
            namedDict1.TryAdd("1", "some more text");
            namedDict1.TryAdd("2", "some text 2");
            namedDict1["2"] = "some more text 2";

            Console.WriteLine(nameof(namedDict1));
            Console.WriteLine($"Count: {namedDict1.Count}");

            foreach (var item in namedDict1)
            {
                Console.WriteLine($"{item.Key} = {item.Value}");
            }

            Console.WriteLine();
            Console.WriteLine("=====================================");
            Console.WriteLine();

            namedDict1.Remove("1");

            var namedDict2 = new ZeroMemoryDictionary("namedStore");

            namedDict2.TryAdd("3", "some text 23");
            namedDict2.TryAdd("4", "some text 34234");

            Console.WriteLine(nameof(namedDict2));
            Console.WriteLine($"Count: {namedDict2.Count}");

            foreach (var item in namedDict2)
            {
                Console.WriteLine($"{item.Key} = {item.Value}");
            }
        }
    }
}

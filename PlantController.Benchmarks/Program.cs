using PlantController.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace PlantController.Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = BenchmarkRunner.Run<MyBenchmark>();
            Console.ReadKey();
        }
    }

    [MemoryDiagnoser]
    public class MyBenchmark
    {
        [Benchmark]
        public void DynamicCollection()
        {
            List<Item> items = new List<Item>();

            for (int i = 0; i < 1000; i++)
            {
                items.Add(new Item { Id = 1, Code = "A", Name = "B", OrderDate = new DateTime(2021, 12, 31), Quantity = 1, StateId = 1 });
            }
        }

        [Benchmark]
        public void StaticCollection()
        {
            List<Item> items = new List<Item>(1000);

            for (int i = 0; i < 1000; i++)
            {
                items.Add(new Item { Id = 1, Code = "A", Name = "B", OrderDate = new DateTime(2021, 12, 31), Quantity = 1, StateId = 1 });
            }
        }
    }
}

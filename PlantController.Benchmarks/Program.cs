using PlantController.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Buffers;

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
        //[Benchmark]
        public void DynamicCollection()
        {
            List<Item> items = new List<Item>();

            for (int i = 0; i < 1000; i++)
            {
                items.Add(new Item { Id = 1, Code = "A", Name = "B", OrderDate = new DateTime(2021, 12, 31), Quantity = 1, StateId = 1 });
            }
        }

        //[Benchmark]
        public void StaticCollection()
        {
            List<Item> items = new List<Item>(1000);

            for (int i = 0; i < 1000; i++)
            {
                items.Add(new Item { Id = 1, Code = "A", Name = "B", OrderDate = new DateTime(2021, 12, 31), Quantity = 1, StateId = 1 });
            }
        }

        //[Benchmark]
        public void StaticCollectionFin()
        {
            List<ItemFin> items = new List<ItemFin>(1000);

            for (int i = 0; i < 1000; i++)
            {
                items.Add(new ItemFin { Id = 1, Code = "A", Name = "B", OrderDate = new DateTime(2021, 12, 31), Quantity = 1, StateId = 1 });
            }
        }


       // [Benchmark]
        public void StaticCollectionStruct()
        {
            List<ItemStruct> items = new List<ItemStruct>(1000);

            for (int i = 0; i < 1000; i++)
            {
                items.Add(new ItemStruct { Id = 1, Code = "A", Name = "B", OrderDate = new DateTime(2021, 12, 31), Quantity = 1, StateId = 1 });
            }
        }

        [Benchmark]
        public void arrayStandard()
        {
            int[] a = new int[1000];
        }

        [Benchmark]
        public void arrayPool()
        {
            var pool = ArrayPool<int>.Shared;
            int[] a = pool.Rent(1000);


            string str = "Hello World";
            str = str + "!";



            pool.Return(a);
        }
    }

    public struct ItemStruct
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public double Quantity { get; set; }

        public int StateId { get; set; } //1-Da produrre      2-In produzione     3-Prodotto

        public DateTime OrderDate { get; set; }
    }

    public partial class ItemFin
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public double Quantity { get; set; }

        public int StateId { get; set; } //1-Da produrre      2-In produzione     3-Prodotto

        public DateTime OrderDate { get; set; }

        ~ItemFin()
        {

        }
    }
}

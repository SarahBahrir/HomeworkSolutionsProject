using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HomeworkProject.Lesson1_Answers;

namespace HomeworkProject
{
    internal class Lesson2_Answers
    {
        public static void MeasureStructMemory()
        {
            long before = GC.GetAllocatedBytesForCurrentThread();
            PointStruct pointStruct = new PointStruct();
            long after = GC.GetAllocatedBytesForCurrentThread();
            Console.WriteLine($"MeasureStructMemory: Allocated Memory={after - before}");
        }
        public static void MeasureStringMemory()
        {
            long before = GC.GetAllocatedBytesForCurrentThread();
            string s = new string("hello world");
            long after = GC.GetAllocatedBytesForCurrentThread();
            Console.WriteLine($"MeasureStringMemory: Allocated Memory={after - before}");
        }

        public static string GenrateStringNumber()
        {
            string s = "";
            for (int i = 0; i <= 100; i++)
            {
                s += i + " ";
            }
            return s;
        }


        public static string GenrateNewStringNumber()
        {
            StringBuilder s = new StringBuilder();
            for (int i = 0; i <= 100; i++)
            {
                s.Append(i);
                s.Append(' ');
            }

            return s.ToString();

        }
        public static void CompareStringsMemory()
        {
            long beforeString = GC.GetAllocatedBytesForCurrentThread();
            string s1 = GenrateStringNumber();
            Console.WriteLine($"string ={s1}");
            long afterString = GC.GetAllocatedBytesForCurrentThread();
            Console.WriteLine($"MeasureStringMemory: Allocated Memory={afterString - beforeString}");
            long beforeStringBuilder = GC.GetAllocatedBytesForCurrentThread();
            string s2 = GenrateNewStringNumber();
            Console.WriteLine($"stringBuilder={s2}");
            long afterStringBuilder = GC.GetAllocatedBytesForCurrentThread();
            Console.WriteLine($"MeasureStringMemory: Allocated Memory={afterStringBuilder - beforeStringBuilder}");
        }
        public static void GCGenerationsTest()
        {
            var obj = new object();

            Console.WriteLine($"Generation of obj before GC: {GC.GetGeneration(obj)}");

            GC.Collect(0);
            Console.WriteLine("Garbage Collection for Generation 0 performed.");

            Console.WriteLine($"Generation of obj after GC: {GC.GetGeneration(obj)}");
        }



        public static void GCGenerationsExperiment()
        {
            Console.WriteLine("Starting Generational GC Experiment");

            // Allocate a small object and check its generation
            var gen0Object = new object();
            Console.WriteLine($"Generation of gen0Object: {GC.GetGeneration(gen0Object)}");

            // Force a Gen 0 garbage collection
            GC.Collect(0); // Only collects Gen 0
            Console.WriteLine("Forced Gen 0 collection.");
            Console.WriteLine($"Generation of gen0Object after Gen 0 GC: {GC.GetGeneration(gen0Object)}");

            // re-allocate:
            gen0Object = new object();
            Console.WriteLine($"Generation of gen0Object after re-allocation: {GC.GetGeneration(gen0Object)}");

            // Allocate a large number of objects to trigger Gen 0 collection
            Console.WriteLine("Allocating objects to trigger Gen 0 collection...");
            for (int i = 0; i < 1000_000; i++)
            {
                var temp = new object();
            }

            // The gen0Object should now be promoted to Gen 1
            Console.WriteLine($"Generation of gen0Object after allocations: {GC.GetGeneration(gen0Object)}");

            // Force a Gen 1 garbage collection
            GC.Collect(1); // Collects Gen 0 and Gen 1
            Console.WriteLine("Forced Gen 1 collection.");
            Console.WriteLine($"Generation of gen0Object after Gen 1 GC: {GC.GetGeneration(gen0Object)}");

            // Create a long-lived object and test its promotion
            var gen2Object = new object();
            Console.WriteLine($"Generation of gen2Object: {GC.GetGeneration(gen2Object)}");

            // Simulate long-lived objects by holding references
            for (int i = 0; i < 10; i++)
            {
                GC.Collect(); // Force full GC (collects all generations)
                Console.WriteLine($"Generation of gen2Object after full GC #{i + 1}: {GC.GetGeneration(gen2Object)}");
            }

            // Allocate a large object to demonstrate Large Object Heap (LOH)
            var largeObject = new byte[85_001]; // Large object threshold is ~85 KB
            Console.WriteLine($"Large object is in Generation: {GC.GetGeneration(largeObject)}");

            // End of demonstration
            Console.WriteLine("Generational GC Demo Complete.");
        }





    }
}

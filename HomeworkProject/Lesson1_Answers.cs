namespace HomeworkProject
{
    internal class Lesson1_Answers
    {
        // Update struct to be public
        public struct PointStruct
        {
            public int x;
            public int y;
        }

        // Internal class definition
        public class PointClass
        {
            public int x;
            public int y;
        }

        // Modify struct
        public static void ModifyPointStruct(PointStruct p)
        {
            p.x += 10;
            p.y += 20;
            Console.WriteLine($"In ModifyPointStruct: p.x={p.x} p.y={p.y}");
        }

        // Modify class
        public static void ModifyPointClass(PointClass p)
        {
            p.x += 10;
            p.y += 20;
            Console.WriteLine($"In ModifyPointClass: pc.x={p.x} pc.y={p.y}");
        }

        // Calculate object memory allocation
        public static long ObjectCalculation()
        {
            long before = GC.GetAllocatedBytesForCurrentThread();
            PointClass p = new PointClass();
            long after = GC.GetAllocatedBytesForCurrentThread();

            return (after - before);
        }

        // Memory allocation experiment
        public static void MemoryAllocationExperiment()
        {
            long baselineMemory = GC.GetAllocatedBytesForCurrentThread();

            int[] intArray = new int[10000];
            long afterIntArray = GC.GetAllocatedBytesForCurrentThread();

            double[] doubleArray = new double[10000];
            long afterDoubleArray = GC.GetAllocatedBytesForCurrentThread();

            string[] stringArray = new string[10000];
            long afterStringArray = GC.GetAllocatedBytesForCurrentThread();

            PointStruct[] structArray = new PointStruct[10];
            long afterStructArray = GC.GetAllocatedBytesForCurrentThread();

            PointStruct[] structArray1 = new PointStruct[100];
            long afterStructArray1 = GC.GetAllocatedBytesForCurrentThread();

            PointClass[] classArray = new PointClass[10];
            long afterClassArray = GC.GetAllocatedBytesForCurrentThread();

            PointClass[] classArray1 = new PointClass[100];
            long afterClassArray1 = GC.GetAllocatedBytesForCurrentThread();

            Console.WriteLine($"Baseline Memory: {baselineMemory} bytes");
            Console.WriteLine($"Int Array Allocation: {afterIntArray - baselineMemory} bytes");
            Console.WriteLine($"Double Array Allocation: {afterDoubleArray - afterIntArray} bytes");
            Console.WriteLine($"String Array Allocation: {afterStringArray - afterDoubleArray} bytes");
            Console.WriteLine($"Struct Array Allocation: {afterStructArray - afterStringArray} bytes");
            Console.WriteLine($"More struct Array Allocation: {afterStructArray1 - afterStructArray} bytes");
            Console.WriteLine($"Class Array Allocation: {afterClassArray - afterStructArray1} bytes");
            Console.WriteLine($"More Class Array Allocation: {afterClassArray1 - afterClassArray} bytes");
        }

        // Central function to run all experiments
        public static void RunAllExperiments()
        {
            // q1: Struct vs Class modification
            PointStruct pStruct = new PointStruct { x = 4, y = 5 };
            ModifyPointStruct(pStruct);
            Console.WriteLine($"After ModifyPointStruct: pStruct.x={pStruct.x}, pStruct.y={pStruct.y}");

            PointClass pClass = new PointClass { x = 4, y = 5 };
            ModifyPointClass(pClass);
            Console.WriteLine($"After ModifyPointClass: pClass.x={pClass.x}, pClass.y={pClass.y}");

            // q3: Memory allocation experiment
            MemoryAllocationExperiment();
        }
    }
}

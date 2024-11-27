public class Program
{
    struct PointStruct
    {
        public int x;
        public int y;

    }

    class PointClass
    {
        public int x;
        public int y;

    }

    static void ModifyPointStruct(PointStruct p)
    {
        p.x += 10;
        p.y += 20;
        Console.WriteLine($"In ModifyPoint: p.x={p.x} p.y={p.y}");
    }

    static void ModifyPointClass(PointClass p)
    {
        p.x += 10;
        p.y += 20;
        Console.WriteLine($"In ModifyPoint: pc.x={p.x} pc.y={p.y}");
    }

    static long ObjectCalculation()
    {
        long before = GC.GetAllocatedBytesForCurrentThread();
        PointClass p = new PointClass();
        long after = GC.GetAllocatedBytesForCurrentThread();

        return (after - before);
    }


    public static void MemoryAllocationExperiment()
    {
        // Track initial allocation 
        long baselineMemory = GC.GetAllocatedBytesForCurrentThread();

        // TODO: Complete the following experiments 

        // 1. Allocate an array of integers 
        int[] intArray = new int[10000];
        long afterIntArray = GC.GetAllocatedBytesForCurrentThread();

        // 2. Allocate an array of doubles 
        double[] doubleArray = new double[10000];
        long afterDoubleArray = GC.GetAllocatedBytesForCurrentThread();

        // 3. Allocate an array of strings 
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

        // Print allocation sizes 
        Console.WriteLine($"Baseline Memory: {baselineMemory} bytes");
        Console.WriteLine($"Int Array Allocation: {afterIntArray - baselineMemory} bytes");
        Console.WriteLine($"Double Array Allocation: {afterDoubleArray - afterIntArray} bytes");
        Console.WriteLine($"String Array Allocation: {afterStringArray - afterDoubleArray} bytes");
        Console.WriteLine($"Struct Array Allocation: {afterStructArray - afterStringArray} bytes");
        Console.WriteLine($"More struct Array Allocation: {afterStructArray1 - afterStructArray} bytes");
        Console.WriteLine($"Class Array Allocation: {afterClassArray - afterStructArray1} bytes");
        Console.WriteLine($"More Class Array Allocation: {afterClassArray1 - afterClassArray} bytes");
        //Console.WriteLine($"Struct use :{}")
    }


    private static void Main(string[] args)
    {
        //q1

        PointStruct pStruct = new PointStruct();
        pStruct.x = 4;
        pStruct.y = 5;
        ModifyPointStruct(pStruct);
        Console.WriteLine($"pStruct.x={pStruct.x} pStruct.y={pStruct.y}");
        PointClass pClass = new PointClass();
        pClass.x = 4;
        pClass.y = 5;
        ModifyPointClass(pClass);
        Console.WriteLine($"pClass.x={pClass.x} pClass.y={pClass.y}");

        //q3

        MemoryAllocationExperiment();


    }


}




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class ArrayProcessor
{
    public static void ProcessArray(int[] array, Action<int> processor)
    {
        foreach (int item in array)
        {
            processor(item);
        }
    }
}
public class MaxNumber
{
    private int maxNumber = int.MinValue;

    public void FindMaxNumber(int number)
    {
        if (number >maxNumber)
        {
            maxNumber = number;
        }
        
    }

    public int GetMaxNumber()
    {
        return maxNumber;
    }

    //public static void Main()
    //{
    //    int[] numbers = { 1, 2, 3, 4, 5 };
    //    var sumCalculator = new SumCalculator();

    //    ArrayProcessor.ProcessArray(numbers, sumCalculator.AddToSum);

    //    int totalSum = sumCalculator.GetSum(); // Returns 15
    //    Console.WriteLine($"Total sum: {totalSum}");
    //}
}



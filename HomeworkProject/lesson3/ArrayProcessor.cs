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


}



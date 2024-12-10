using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkProject.lesson4
{
    internal class exercise1
    {
        public static void RunMaxNumber()
        {
            int[] numbers = { 1, 2, 3, 4, 5 };
            var maxNumber = new MaxNumber();

            ArrayProcessor.ProcessArray(numbers, maxNumber.FindMaxNumber);

            int result = maxNumber.GetMaxNumber(); 
            Console.WriteLine($"Max number: {result}");
        }

    }
}

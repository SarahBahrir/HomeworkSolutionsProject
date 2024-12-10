﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkProject
{
    internal class Lesson3_Answer
    {
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

        public class SumCalculator
        {
            private int _sum;

            public void AddToSum(int number)
            {
                _sum += number;
            }

            public int GetSum()
            {
                return _sum;
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
    }
}

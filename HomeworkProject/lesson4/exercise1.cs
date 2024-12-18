using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal class exercise1
{


    public static void SortTwo<T>(ref T x, ref T y) where T : IComparable<T>
    {
        if (x.CompareTo(y) > 0)
        {
            T temp = x;
            x= y; 
            y = temp;
        }
    }


}


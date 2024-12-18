using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal class exercise2
{
    public class Fraction
    {
        int numerator, denominator;

        public Fraction(int numerator, int denominator)
        {
            this.numerator = numerator;
            if (denominator == 0)
            {
                throw new DivideByZeroException();
            }
            this.denominator = denominator;
        }

        public static Fraction operator +(Fraction a, Fraction b)
        {
            Fraction result = new Fraction(0, 1);
            result.numerator = a.numerator * b.denominator + b.numerator * a.denominator;
            result.denominator = a.denominator * b.denominator;
            return result;
        }

        public static Fraction operator -(Fraction a, Fraction b)
        {
            Fraction minus_b = new Fraction(-b.numerator, b.denominator);
            return a + minus_b;
        }

        public override string ToString()
        {
            return $"{numerator}/{denominator}";
        }
    }

    class GenericOperationTable<T>
    {
        public delegate T Operation(T a, T b);

        Operation op;
        List<T> row_values;
        List<T> col_values;
        public T[,] results = null;

        public GenericOperationTable(List<T> _row_values, List<T> _col_values, Operation _op)
        {
            op = _op;
            row_values = _row_values;
            col_values = _col_values;
            results = new T[_row_values.Count, _col_values.Count];
        }
        public void Calculate()
        {
            for (int row = 0; row < results.GetLength(0); row++)
            {
                for (int col = 0; col < results.GetLength(1); col++)
                {
                    results[row, col] = op(row_values[row], col_values[col]);
                }
            }
        }

        public override string ToString()
        {
            int maxWidth = 0;
            for (int row = 0; row < results.GetLength(0); row++)
            {
                for (int col = 0; col < results.GetLength(1); col++)
                {
                    T t = results[row, col];
                    int width;
                    if (t == null)
                    {
                        width = 0;
                    }
                    else
                    {
                        string s = t.ToString();
                        width = s.Length;
                    }

                    maxWidth = Math.Max(maxWidth, width);
                }
            }

            string res = "";
            for (int row = 0; row < results.GetLength(0); row++)
            {
                for (int col = 0; col < results.GetLength(1); col++)
                {
                    res += results[row, col].ToString().PadLeft(maxWidth, ' ');
                    if (col < results.GetLength(1) - 1)
                    {
                        res += ",";
                    }
                }
                res += "\n";
            }
            return res;
        }
    }
}


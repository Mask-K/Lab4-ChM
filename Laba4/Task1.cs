using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba4
{
    internal class Task1
    {
        double f(double x) => 4 * Math.Pow(x, 16) + 6 * Math.Pow(x, 15) + Math.Pow(x, 14);
        void fill()
        {
            for (int i = 0; i < x.Length; i++)
            {
                for (int j = 0; j < x.Length + 1; j++)
                {
                    if (j == 0)
                        arr[i, j] = 1;
                    else
                        arr[i, j] = Math.Pow(x[i], j);
                }

            }
        }
        double[] GaussMeth(double[,] matr, double[] b)
        {
            double d, s;
            var res = new double[b.Length];
            for (int k = 0; k < b.Length; ++k)
            {
                double max_el = double.MinValue;
                int index = 0;
                for (int i = k; i < b.Length; ++i)
                {
                    if (max_el < Math.Abs(matr[i, k]))
                    {
                        max_el = Math.Abs(matr[i, k]);
                        index = i;
                    }
                }
                if (index != k)
                {
                    for (int i = 0; i < b.Length; ++i)
                    {
                        var temp = matr[index, i];
                        matr[index, i] = matr[k, i];
                        matr[k, i] = temp;
                    }
                    var t = b[index];
                    b[index] = b[k];
                    b[k] = t;
                }
                for (int j = k + 1; j < b.Length; ++j)
                {

                    d = matr[j, k] / matr[k, k];
                    for (int i = k; i < b.Length; ++i)
                    {
                        matr[j, i] = matr[j, i] - d * matr[k, i];
                    }
                    b[j] = b[j] - d * b[k];
                }
            }
            for (int k = b.Length - 1; k >= 0; --k)
            {
                d = 0;
                for (int j = k; j < b.Length; ++j)
                {
                    s = matr[k, j] * (k == b.Length - 1 ? 0 : res[j]);
                    d += s;
                }

                res[k] = Math.Round(((b[k] - d) / matr[k, k]), 3);
            }
            Console.WriteLine("Поліном Лагранжа:");
            for (int i = res.Length - 1; i >= 0; --i)
            {
                Console.Write($"{res[i]}x^{i}");
                if (i != 0)
                    Console.Write(" + ");
            }
            Console.WriteLine();
            return res;
        }
        void printCalc(double[] x)
        {
            double answ = 0;
            foreach (var el in x)
                answ += el;
            Console.WriteLine(answ);
        }

        const int len = 14;
        double[] x = new double[len];
        double[] y = new double[len];
        double[,] arr = new double[len, len + 1];

        public void Compute()
        {
            for (int i = 0; i < len; i++)
            {
                x[i] = i * 1.0 / (len - 1);
                y[i] = f(x[i]);
            }
            fill();

            var answ = GaussMeth(arr, y);
            Console.Write("f(xi), xi = 1: ");
            Console.WriteLine(f(1));
            Console.Write("L(xi), xi = 1: ");
            printCalc(answ);
        }
    }
}

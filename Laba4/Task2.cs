using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba4
{
    internal class Task2
    {
        const int len = 4;
        double[] x = new double[len];
        double[] y = new double[len];
        double[] h = new double[len], l = new double[len], delta = new double[len], lambda = new double[len], c = new double[len], d = new double[len], b = new double[len];
        double f(double x) => 2*Math.Pow(x, 7) + 3*Math.Pow(x, 6) + 4*Math.Pow(x, 5) + 3;
        void printCalc(int el)
        {
            double answ = y[el+1] - b[el+1] + c[el+1] - d[el+1];
            Console.WriteLine(answ);

        }
        void printSyst()
        {
            for(int i = 1; i < len; ++i)
            {
                Console.WriteLine($"Поліном для проміжку [{i - 1}; {i}]");
                Console.WriteLine($"{y[i]}*x^0 + {b[i]}*x^1 + {c[i]}*x^2 + {d[i]}*x^3");
            }
        }
        public void Compute()
        {
            int k = 0;
            for (int i = 0; i < len; i++)
            {
                x[i] = i;
                y[i] = f(x[i]);
            }
            for (k = 1; k < len; k++)
            {
                h[k] = x[k] - x[k - 1];
                
                l[k] = (y[k] - y[k - 1]) / h[k];
            }
            delta[1] = -h[2] / (2 * (h[1] + h[2]));
            lambda[1] = 1.5 * (l[2] - l[1]) / (h[1] + h[2]);
            for (k = 3; k < len; k++)
            {
                delta[k - 1] = -h[k] / (2 * h[k - 1] + 2 * h[k] + h[k - 1] * delta[k - 2]);
                lambda[k - 1] = (3 * l[k] - 3 * l[k - 1] - h[k - 1] * lambda[k - 2]) /
                      (2 * h[k - 1] + 2 * h[k] + h[k - 1] * delta[k - 2]);
            }
            c[0] = 0;
            c[len-1] = 0;
            for (k = len-1; k >= 2; k--)
            {
                c[k - 1] = delta[k - 1] * c[k] + lambda[k - 1];
            }
            for (k = 1; k < len; k++)
            {
                d[k] = (c[k] - c[k - 1]) / (3 * h[k]);
                b[k] = l[k] + (2 * c[k] * h[k] + h[k] * c[k - 1]) / 3;
            }
            printSyst();
            Console.WriteLine();
            Console.Write("f(xi), xi = 1: ");
            Console.WriteLine(f(1));
            Console.Write("Значення через другий утворений поліном: ");
            printCalc(1);
        }
    }
}

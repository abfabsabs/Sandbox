using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandboxConsole.Logic
{
    static class MathHelper
    {
        internal static bool IsPrimeNumber(this int number)
        {
            return (Enumerable.Range(1, number)
                    .Where(x => number % x == 0)
                    .Count() == 2);                 //  Prime numbers have exactly two factors: 1 and itself
        }

        internal static bool IsPrimeNumber(this long number)
        {
            if (number % 2 == 0)
                return false;
            else if (number % 3 == 0)
                return false;
            else if (number % 5 == 0)
                return false;
            else
            {
                decimal ceiling = Convert.ToDecimal(Math.Ceiling(Math.Pow(number, 0.5)));
                for (decimal i = 2; i <= ceiling; i++)
                {
                    decimal modOperator = number % i;
                    decimal modManual = Modulo(number, i);

                    if (modOperator == 0 && modManual == 0)
                    {
                        Console.WriteLine("{0} is divisible by {1}; not a prime number.", number, i);
                        return false;
                    }
                }
            }
            return true;
        }

        internal static decimal Modulo(decimal a, decimal b)
        {
            return (Math.Abs(a * b) + a) % b;
        }

        /// <summary>
        /// 0   1   2   3   4   5   6
        /// 1   2   3   5   8   13  21
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        internal static int GetFibonacciAtIndex(int index)
        {
            if (index <= 0)
                return 1;
            else
                return GetFibonacciAtIndex(index - 1) + GetFibonacciAtIndex(index - 2);
        }

        /// <summary>
        /// 0 1 2 3  4  5  6  7
        /// 2 3 5 7 11 13 17 19
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        internal static int GetPrimeNumberAtIndex(int index)
        {
            if (index <= 0)
                return 2;       //  the very first prime number
            else
            {
                int lastPrime = GetPrimeNumberAtIndex(index - 1);    //  the prime number at the previous index
                int thisPrime = lastPrime;
                for (int i = lastPrime + 1; i <= (lastPrime + index); i++)
                {
                    if (IsPrimeNumber(i))
                    {
                        thisPrime = i;
                        break;
                    }
                }
                return thisPrime;
            }
        }
    }
}

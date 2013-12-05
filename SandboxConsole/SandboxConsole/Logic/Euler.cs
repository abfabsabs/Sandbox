using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandboxConsole.Logic
{
    static class Euler
    {
        internal static void FizzBuzz()
        {
            string var = "";
            for (int i = 1; i <= 100; ++i)
            {
                var = "";
                if (i % 3 == 0)
                    var += "fizz";
                if (i % 5 == 0)
                    var += "buzz";
                if (var != "")
                    Console.WriteLine(var);
                else
                    Console.WriteLine(i.ToString());
            }
        }       

        /// <summary>
        /// http://projecteuler.net/problems #1
        /// </summary>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        internal static int SumNaturalNumbersUpTo(int maxValue)
        {
            int sumHolder = 0;

            for (int i = 0; i < maxValue; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    sumHolder += i;
                }
            }

            return sumHolder;
        }

        /// <summary>
        /// http://projecteuler.net/problems #1
        /// </summary>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        internal static int SumNaturalNumbersUpTo_Alt(int maxValue)
        {
            return Enumerable.Range(0, maxValue)
                .Where(n => n % 3 == 0 || n % 5 == 0)
                .Sum();
        }

        /// <summary>
        ///  http://projecteuler.net/problems #2
        /// </summary>
        /// <returns></returns>
        internal static int SumEvenFibonacci()
        {
            int sumOfEvens = 0;
            int lastFibonacci = 0;
            int index = 0;
            do
            {
                lastFibonacci = MathHelper.GetFibonacciAtIndex(index);
                if (lastFibonacci % 2 == 0)
                    sumOfEvens += lastFibonacci;
                index++;
            }
            while (lastFibonacci <= 4000000);

            return sumOfEvens;
        }

        /// <summary>
        ///  http://projecteuler.net/problems #3
        /// </summary>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        internal static long LargestPrimeFactorOf(long maxValue)
        {
            long largestPrimeHolder = 0;

            //for (long i = (maxValue - 1); i > 0; i--)
            for (long i = maxValue - 1; i > 0; i--)
            {
                if (MathHelper.IsPrimeNumber(i))
                {
                    largestPrimeHolder = i;
                    break;
                }
            }

            return largestPrimeHolder;
        }

        /// <summary>
        ///  http://projecteuler.net/problems #4
        /// </summary>
        /// <param name="numDigits"></param>
        /// <returns></returns>
        internal static int GetLargestPalindromeForDigits(int numDigits)
        {
            double maxValue = Math.Pow(10, numDigits) - 1;
            int largestPalindrome = 0;

            for (int i = 1; i <= maxValue; i++)
            {
                for (int j = 1; j <= maxValue; j++)
                {
                    int product = i * j;
                    if (product > largestPalindrome)
                    {
                        string testString = (i * j).ToString();
                        string reverseString = StringHelper.ReverseString(testString);
                        if (string.Equals(testString, reverseString))
                            largestPalindrome = Int32.Parse(testString);
                    }
                }
            }
            return largestPalindrome;
        }
        
        /// <summary>
        ///  http://projecteuler.net/problems #5
        /// </summary>
        /// <param name="startNum"></param>
        /// <param name="endNum"></param>
        /// <returns></returns>
        internal static int GetSmallestMultiple(int startNum, int endNum)
        { 
            int smallestMultiple = 0;
            int incrementor = 1;

            do{
                bool hasRemainder = false;
                for (int i = startNum; i <= endNum; i++ )
                {
                    if (incrementor % i != 0)
                    {
                        hasRemainder = true;
                        break;
                    }
                    
                }
                if (!hasRemainder)
                    smallestMultiple = incrementor;

                incrementor++;
            } while (smallestMultiple == 0);

            return smallestMultiple;
        }

        /// <summary>
        ///  http://projecteuler.net/problems #6
        /// </summary>
        /// <param name="startNum"></param>
        /// <param name="endNum"></param>
        /// <returns></returns>
        internal static double SumSquareDifference(int startNum, int endNum)
        {
            double sumSquares = 0;
            int numSum = 0;

            for (int i = startNum; i <= endNum; i++)
            {
                sumSquares += Math.Pow(i, 2);
                numSum += i;
            }
            double squareSums = Math.Pow(numSum, 2);
            return Math.Abs(sumSquares - squareSums);
        }

        /// <summary>
        ///  http://projecteuler.net/problems #7
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        internal static int GetNthPrimeNumber(int n)
        { 
            int primeCount = 0;
            int lastPrimeNum = 0;
            int incrementor = 0;

            do
            {
                if (MathHelper.IsPrimeNumber(incrementor))
                {
                    lastPrimeNum = incrementor;
                    primeCount++;
                }
                incrementor++;
            } while (primeCount < n);

            return lastPrimeNum;
        }

        /// <summary>
        ///  http://projecteuler.net/problems #8
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        internal static int GetGreatestProductOf5Consecutive(string val)
        {
            IEnumerable<int> digits = val.Select(c => c - '0').ToArray();

            //var digits2 = val.Select(c => (int)char.GetNumericValue(c)).ToArray();

            return Enumerable.Range(0, digits.Count() - 4)
                .Select(i => digits.ElementAt(i) * digits.ElementAt(i + 1) * digits.ElementAt(i + 2) * digits.ElementAt(i + 3) * digits.ElementAt(i + 4))
                .Max();
        }

        /// <summary>
        ///  http://projecteuler.net/problems #9
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        //static private int GetPythagoreanTripetFor(double value)
        //{
        //    double squareroot = Math.Sqrt(value);
        //    if (Math.Floor(squareroot) != squareroot)
        //        throw (new ArgumentException(String.Format("Square root of '{0}' is not a natural number.", value)));
        //    else
        //    {
        //        int c = (int)Math.Floor(squareroot);


        //    }

        //    return 0;
        //}
    }
}

using System;
using System.Collections.Generic;

namespace epstein_files_csharp_edition
{
    internal class Program
    {
        public delegate bool NumberCheck(int number);

        static int[] Filter(int[] array, NumberCheck check)
        {
            List<int> result = new List<int>();

            foreach (int number in array)
            {
                if (check(number))
                {
                    result.Add(number);
                }
            }

            return result.ToArray();
        }

        static bool IsEven(int number)
        {
            return number % 2 == 0;
        }

        static bool IsOdd(int number)
        {
            return number % 2 != 0;
        }

        static bool IsPrime(int number)
        {
            if (number < 2)
                return false;

            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                    return false;
            }

            return true;
        }
        static bool IsFibonacci(int number)
        {
            if (number < 0)
                return false;

            int a = 0;
            int b = 1;

            while (b < number)
            {
                int temp = a + b;
                a = b;
                b = temp;
            }

            return number == 0 || number == b;
        }

        static void PrintArray(string title, int[] array)
        {
            Console.WriteLine(title);

            foreach (int number in array)
            {
                Console.Write(number + " ");
            }

            Console.WriteLine();
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            int[] numbers =
            {
                0, 1, 2, 3, 4, 5, 8, 13, 17, 21, 34, 55, 89, 100
            };

            int[] evenNumbers = Filter(numbers, IsEven);
            int[] oddNumbers = Filter(numbers, IsOdd);
            int[] primeNumbers = Filter(numbers, IsPrime);
            int[] fibonacciNumbers = Filter(numbers, IsFibonacci);

            PrintArray("Even numbers:", evenNumbers);
            PrintArray("Odd numbers:", oddNumbers);
            PrintArray("Prime numbers:", primeNumbers);
            PrintArray("Fibonacci numbers:", fibonacciNumbers);
        }
    }
}

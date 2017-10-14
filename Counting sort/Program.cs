using System;
using System.Text;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 10;
            int minK = -100;
            int maxK = 100;
            
            int[] array = new int[n];
            int[] sortedArray;
            var randomNumbers = new Random();

            for (int i = 0; i < array.Length; i++)         // filling the array with random numbers 
                array[i] = randomNumbers.Next(minK, maxK);

            Console.Write("Counting sort\n\nRandom array: ");
            PrintArray(array);
            
            sortedArray = CountingSort(array, minK, maxK);

            Console.Write("Sorted array: ");
            PrintArray(sortedArray);
            
            Console.WriteLine("\nPress any key to continue...");
            Console.Read();
        }

        static int[] CountingSort(int[] array, int minNumber, int maxNumber)
        {
            int[] sortedArray = new int[array.Length];
            int[] numbers = new int[maxNumber - minNumber + 1];
            int i;

            for (i = 0; i < array.Length; i++)
                numbers[array[i] - minNumber] = numbers[array[i] - minNumber] + 1;

            for (i = 1; i <= maxNumber - minNumber; i++)
                numbers[i] = numbers[i] + numbers[i - 1];

            for (i = array.Length - 1; i >= 0; i--)
            {
                sortedArray[numbers[array[i] - minNumber] - 1] = array[i];
                numbers[array[i] - minNumber] = numbers[array[i] - minNumber] - 1;
            }

            return sortedArray;
        }

        static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
                Console.Write("{0,3} ", array[i]);
            Console.WriteLine();
        }

    }
}

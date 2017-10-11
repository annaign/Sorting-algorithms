using System;

namespace SortingAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 10;                         //array length
            int[] array = new int[n];           //sorting array

            CreateRandomArray(array);

            Console.Write("Quick sort\n\nRandom array: ");
            PrintArray(array);

            //Quick sort
            Quicksort(array);

            Console.Write("Sorted array: ");
            PrintArray(array);

            Console.WriteLine("\nPress any key to continue...");
            Console.Read();
        }

        static void Quicksort(int[] array)
        {
            Quicksort(array, 0, array.Length - 1);
        }

        static void Quicksort(int[] array, int start, int end)
        {
            if (start == end) return;

            var rnd = new Random();
            int pivot = array[rnd.Next(start, end)];

            int[] middle = Split(array, start, end, pivot);
            if (middle[0] > start)
            {
                Quicksort(array, start, middle[0] - 1);
            }
            else
            {
                middle[0]++;
                if (middle[1] > 0) middle[1]--;
            }

            if (middle[0] + middle[1] < end)
                Quicksort(array, middle[0] + middle[1], end);
        }

        static int[] Split(int[] array, int start, int end, int pivot)
        {
            int border = start;
            int pivotEqual = 0;

            for (int i = start; i <= end; i++)
            {
                if (array[i] < pivot)
                {
                    SwapElements(array, border, i);
                    if (pivotEqual > 0) SwapElements(array, i, border + pivotEqual);
                    border++;
                }
                else if (array[i] == pivot)
                {
                    SwapElements(array, border + pivotEqual, i);
                    pivotEqual++;
                }
            }
            //Console.Write("n={0} {1} {2} b={3}: ", pivotEqual, start, end, border);
            //PrintArray(array);

            return new int[] { border, pivotEqual };
        }

        static void SwapElements(int[] array, int element1, int element2)
        {
            if (element1 == element2) return;
            int temp = array[element1];
            array[element1] = array[element2];
            array[element2] = temp;
        }

        static void CreateRandomArray(int[] array)
        {
            var randomNumbers = new Random();

            for (int i = 0; i < array.Length; i++)      // filling the array with random numbers 
                array[i] = randomNumbers.Next(0, 100);
        }

        static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
                Console.Write("{0,3} ", array[i]);
            Console.WriteLine();
        }
    }
}

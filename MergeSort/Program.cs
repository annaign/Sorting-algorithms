using System;

namespace SortingAlgorithms
{
    class Program
    {
        static int[] tempArray;
        
        static void Main(string[] args)
        {
            int n = 10;                         //array length
            int[] array = new int[n];           //sorting array

            CreateRandomArray(array);

            Console.Write("Merge sort\n\nRandom array: ");
            PrintArray(array);

            //Merge sort
            MergeSort(array);

            Console.Write("Sorted array: ");
            PrintArray(array);

            Console.WriteLine("\nPress any key to continue...");
            Console.Read();
        }

        static void MergeSort(int[] array)
        {
            tempArray = new int[array.Length];
            MergeSort(array, 0, array.Length - 1);
        }

        static void MergeSort(int[] array, int start, int end)
        {
            if (start == end) return;

            int middle = (start + end) / 2;

            MergeSort(array, start, middle);
            MergeSort(array, middle + 1, end);

            Merge(array, start, middle, end);
        }

        static void Merge(int[] array, int start, int middle, int end)
        {
            int left = start;
            int right = middle + 1;
            int length = end - start + 1;

            for (int i = 0; i < length; i++)
            {
                if (right > end || (left <= middle && array[left] <= array[right]))
                {
                    tempArray[i] = array[left];
                    left++;
                }
                else
                {
                    tempArray[i] = array[right];
                    right++;
                }
            }

            for (int i = 0; i < length; i++)
                array[start + i] = tempArray[i];
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

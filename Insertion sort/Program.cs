using System;

namespace SortingAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 10;                         //array length
            int[] array = new int[n];           //sorting array

            var randomNumbers = new Random();

            for (int i = 0; i < array.Length; i++)      // filling the array with random numbers 
                array[i] = randomNumbers.Next(0, 100);

            Console.Write("Insertion sort\n\nRandom array: ");
            PrintArray(array);

            //Insertion sort
            int counter;
            for (int i = 1; i < array.Length; i++)
            {
                counter = i - 1;
                while (counter >= 0 && array[counter] > array[counter + 1])
                {
                    int temp = array[counter];
                    array[counter] = array[counter + 1];
                    array[counter + 1] = temp;
                    counter--;
                }
            }

            Console.Write("Sorted array: ");
            PrintArray(array);

            Console.WriteLine("\nPress any key to continue...");
            Console.Read();
        }

        static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
                Console.Write("{0,3} ", array[i]);
            Console.WriteLine();
        }
    }
}

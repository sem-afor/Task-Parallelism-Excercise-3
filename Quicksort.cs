using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Parallelism_Excercise_3
{
    internal class Quicksort
    {
        internal Quicksort(int arraySize)
        {
            int[] unsortedArray = new int[arraySize];
            Random random = new Random();

            // Generate random integers and populate the array
            for (int i = 0; i < arraySize; i++)
            {
                unsortedArray[i] = random.Next(0, 1000);
            }

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            quicksort(unsortedArray, 0, unsortedArray.Length - 1);
            stopwatch.Stop();

            //Console.WriteLine($"Sorted array: [{string.Join(", ", unsortedArray)}]");

            long elapsedMilliseconds = stopwatch.ElapsedMilliseconds;
            double elapsedSeconds = stopwatch.Elapsed.TotalSeconds;

            Console.WriteLine($"Quicksort took {elapsedMilliseconds} milliseconds ({elapsedSeconds} seconds) with size {arraySize}.");

        }
        static void quicksort(int[] myArray, int leftIndex, int rightIndex)
        {
            if (leftIndex < rightIndex)
            {
                int pivotIndex = sort(myArray, leftIndex, rightIndex);
                quicksort(myArray, leftIndex, pivotIndex - 1);
                quicksort(myArray, pivotIndex + 1, rightIndex);
            }
        }

        static int sort(int[] myArray, int leftIndex, int rightIndex)
        {
            int pivotElement = myArray[rightIndex];
            int i = leftIndex - 1;

            for (int j = leftIndex; j < rightIndex; j++)
            {
                if (myArray[j] < pivotElement)
                {
                    i++;
                    swapPlaces(myArray, i, j);
                }
            }

            swapPlaces(myArray, i + 1, rightIndex);
            return i + 1;
        }

        static void swapPlaces(int[] myArray, int i, int j)
        {
            int temp = myArray[i];
            myArray[i] = myArray[j];
            myArray[j] = temp;
        }
    }


}

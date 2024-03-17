using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Parallelism_Excercise_3
{
    internal class Mergesort
    {
        internal Mergesort(int arraySize)
        {
            int[] unsortedArray = new int[arraySize];
            Random random = new Random();
            for (int i = 0; i < arraySize; i++)
            {
                unsortedArray[i] = random.Next(0, 1000);
            }


            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            mergesort(unsortedArray, 0, unsortedArray.Length - 1);
            stopwatch.Stop();

            //Console.WriteLine($"Sorted array: [{string.Join(", ", unsortedArray)}]");

            long elapsedMilliseconds = stopwatch.ElapsedMilliseconds;
            double elapsedSeconds = stopwatch.Elapsed.TotalSeconds;

            Console.WriteLine($"Mergesort took {elapsedMilliseconds} milliseconds ({elapsedSeconds} seconds) with size {arraySize}.");

            
        }


        private void mergesort(int[] myArray, int leftIndex, int rightIndex)
        {
            if (leftIndex < rightIndex)
            {
                int midIndex = (leftIndex + rightIndex) / 2;
                mergesort(myArray, leftIndex, midIndex);
                mergesort(myArray, midIndex + 1, rightIndex);
                merge(myArray, leftIndex, midIndex, rightIndex);
            }
        }

        private void merge(int[] myArray, int leftIndex, int midIndex, int rightIndex)
        {
            int leftArraySize = midIndex - leftIndex + 1;
            int rightArraySize = rightIndex - midIndex;

            int[] leftArray = new int[leftArraySize];
            int[] rightArray = new int[rightArraySize];

            for (int i = 0; i < leftArraySize; i++)
                leftArray[i] = myArray[leftIndex + i];
            for (int j = 0; j < rightArraySize; j++)
                rightArray[j] = myArray[midIndex + 1 + j];

            int indexAtMyArray = leftIndex;
            int indexAtLeftArray = 0;
            int IndexAtRightArray = 0;

            while (indexAtLeftArray < leftArraySize && IndexAtRightArray < rightArraySize)
            {
                if (leftArray[indexAtLeftArray] <= rightArray[IndexAtRightArray])
                {
                    myArray[indexAtMyArray] = leftArray[indexAtLeftArray];
                    indexAtLeftArray++;
                }
                else
                {
                    myArray[indexAtMyArray] = rightArray[IndexAtRightArray];
                    IndexAtRightArray++;
                }
                indexAtMyArray++;
            }

            while (indexAtLeftArray < leftArraySize)
            {
                myArray[indexAtMyArray] = leftArray[indexAtLeftArray];
                indexAtLeftArray++;
                indexAtMyArray++;
            }

            while (IndexAtRightArray < rightArraySize)
            {
                myArray[indexAtMyArray] = rightArray[IndexAtRightArray];
                IndexAtRightArray++;
                indexAtMyArray++;
            }
        }
    }
}

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
        private readonly int maxParallelDepth;
        internal Mergesort(int arraySize, int maxDepth)
        {
            maxParallelDepth = maxDepth;
            int[] unsortedArray = new int[arraySize];
            Random random = new Random();
            for (int i = 0; i < arraySize; i++)
            {
                unsortedArray[i] = random.Next(0, 1000);
            }


            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            parallelMergesort(unsortedArray, 0, unsortedArray.Length - 1, 0);
            //sequentialMergesort(unsortedArray, 0, unsortedArray.Length - 1);
            stopwatch.Stop();

            long elapsedMilliseconds = stopwatch.ElapsedMilliseconds;
            double elapsedSeconds = stopwatch.Elapsed.TotalSeconds;

            Console.WriteLine($"Mergesort took {elapsedMilliseconds} milliseconds ({elapsedSeconds} seconds) with size size {arraySize} and max dept {maxParallelDepth}.");


        }


        private void parallelMergesort(int[] myArray, int leftIndex, int rightIndex, int depth)
        {
            // NAIVE
            //if (leftIndex < rightIndex)
            //{
            //    int midIndex = (leftIndex + rightIndex) / 2;
            //    Parallel.Invoke(
            //        () => parallelMergesort(myArray, leftIndex, midIndex, 0),
            //        () => parallelMergesort(myArray, midIndex + 1, rightIndex, 0)
            //    );
            //    merge(myArray, leftIndex, midIndex, rightIndex);
            //}

            if (leftIndex < rightIndex)
            {
                
                if (depth < maxParallelDepth)
                {
                    int midIndex = (leftIndex + rightIndex) / 2;
                    Parallel.Invoke(
                        () => parallelMergesort(myArray, leftIndex, midIndex, depth + 1),
                        () => parallelMergesort(myArray, midIndex + 1, rightIndex, depth + 1)
                    );
                    merge(myArray, leftIndex, midIndex, rightIndex);
                }
                else
                {
                    sequentialMergesort(myArray, leftIndex, rightIndex);
                }
            }
        }
        
        private void sequentialMergesort(int[] myArray, int leftIndex, int rightIndex)
        {
            if (leftIndex < rightIndex)
            {
                int midIndex = (leftIndex + rightIndex) / 2;
                sequentialMergesort(myArray, leftIndex, midIndex);
                sequentialMergesort(myArray, midIndex + 1, rightIndex);
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

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
        private readonly int maxParallelDepth;
        internal Quicksort(int arraySize, int maxDepth)
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
            parallelQuicksort(unsortedArray, 0, unsortedArray.Length - 1,0);
            stopwatch.Stop();

            long elapsedMilliseconds = stopwatch.ElapsedMilliseconds;
            double elapsedSeconds = stopwatch.Elapsed.TotalSeconds;

            Console.WriteLine($"Quicksort took {elapsedMilliseconds} milliseconds ({elapsedSeconds} seconds) with size {arraySize} and max dept {maxParallelDepth}.");

        }

        private void parallelQuicksort(int[] myArray, int leftIndex, int rightIndex, int depth)
        {
            //if (leftIndex < rightIndex)
            //{
            //    int pivotIndex = sort(myArray, leftIndex, rightIndex);
            //    var leftTask = Task.Run(() => quicksort(myArray, leftIndex, pivotIndex - 1));
            //    var rightTask = Task.Run(() => quicksort(myArray, pivotIndex + 1, rightIndex));
            //    Task.WhenAll(leftTask, rightTask).Wait();
            //}

            if (leftIndex < rightIndex)
            {
                if (depth < maxParallelDepth)
                {
                    int pivotIndex = sort(myArray, leftIndex, rightIndex);
                    Parallel.Invoke(
                        () => parallelQuicksort(myArray, leftIndex, pivotIndex - 1, depth + 1),
                        () => parallelQuicksort(myArray, pivotIndex + 1, rightIndex, depth + 1)
                    );
                }
                else
                {
                    sequentialQuicksort(myArray, leftIndex, rightIndex);
                }
            }
        }

        private void sequentialQuicksort(int[] myArray, int leftIndex, int rightIndex)
        {
            if (leftIndex < rightIndex)
            {
                int pivotIndex = sort(myArray, leftIndex, rightIndex);
                sequentialQuicksort(myArray, leftIndex, pivotIndex - 1);
                sequentialQuicksort(myArray, pivotIndex + 1, rightIndex);
            }
        }

        private int sort(int[] myArray, int leftIndex, int rightIndex)
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

        private void swapPlaces(int[] myArray, int i, int j)
        {
            int temp = myArray[i];
            myArray[i] = myArray[j];
            myArray[j] = temp;
        }
    }


}

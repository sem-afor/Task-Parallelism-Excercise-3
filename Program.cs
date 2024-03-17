using System;
using System.Diagnostics;
using Task_Parallelism_Excercise_3;

class Program
{
    static void Main()
    {
        // 1000000 bis 1400000
        new Quicksort(1000000);
        new Quicksort(1050000);
        new Quicksort(1100000);
        new Quicksort(1150000);
        new Quicksort(1200000);
        new Quicksort(1250000);
        new Quicksort(1300000);
        new Quicksort(1350000);
        new Quicksort(1400000);
        new Quicksort(1450000);


        // 4500000 bis 9000000
        new Mergesort(4500000);
        new Mergesort(4550000);
        new Mergesort(5500000);
        new Mergesort(5550000);
        new Mergesort(6500000);
        new Mergesort(6550000);
        new Mergesort(7500000);
        new Mergesort(8550000);
        new Mergesort(8500000);
        new Mergesort(8550000);
        new Mergesort(9000000);
        new Mergesort(9050000);


    }
}

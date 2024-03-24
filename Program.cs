using System;
using System.Diagnostics;
using Task_Parallelism_Excercise_3;

class Program
{
    static void Main()
    {
        // 0 like sequential

        // 1000000 bis 1400000
        int dept = 15;
        //new Quicksort(1000000,7);
        new Quicksort(1000000, dept);
        new Quicksort(1050000, dept);
        new Quicksort(1100000, dept);
        new Quicksort(1150000, dept);
        new Quicksort(1200000, dept);
        new Quicksort(1250000, dept);
        new Quicksort(1300000, dept);
        new Quicksort(1350000, dept);
        new Quicksort(1400000, dept);
        new Quicksort(1450000, dept);

        // 4500000 bis 9000000
        //new Mergesort(4500000, 7);
        new Mergesort(4500000, dept);
        new Mergesort(4550000, dept);
        new Mergesort(5500000, dept);
        new Mergesort(5550000, dept);
        new Mergesort(6500000, dept);
        new Mergesort(6550000, dept);
        new Mergesort(7500000, dept);
        new Mergesort(7550000, dept);
        new Mergesort(8500000, dept);
        new Mergesort(8550000, dept);
        new Mergesort(9000000, dept);
        new Mergesort(9050000, dept);

    }
}

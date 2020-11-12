using System;
using System.Collections;
using System.Collections.Generic;

class Util
{

    static int partition(List<Block> arr, int low, int high)
    {
        float pivot = arr[high].grade;


        int i = (low - 1);
        for (int j = low; j < high; j++)
        {

            if (arr[j].grade < pivot)
            {
                i++;

                Block temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }

        Block temp1 = arr[i + 1];
        arr[i + 1] = arr[high];
        arr[high] = temp1;

        return i + 1;
    }

    // A utility function to print array of size n 
    public static void printArray(List<Block> arr)
    {
        for (int i = 0; i < arr.Count; ++i)
            Console.Write(arr[i].grade + " ");

        Console.WriteLine();
    }


    /* The main function that implements QuickSort() 
    arr[] --> Array to be sorted, 
    low --> Starting index, 
    high --> Ending index */
    public static void QuickSort(List<Block> arr, int low, int high)
    {
        if (low < high)
        {
            int pi = partition(arr, low, high);
            QuickSort(arr, low, pi - 1);
            QuickSort(arr, pi + 1, high);
        }
    }

    private static int SortAscending(Block x, Block y)
    {
        if (x == null)
        {
            if (y == null)
            {
                // If x is null and y is null, they're
                // equal.
                return 0;
            }
            else
            {
                // If x is null and y is not null, y
                // is greater.
                return -1;
            }
        }
        else
        {
            // If x is not null...
            //
            if (y == null)
            // ...and y is null, x is greater.
            {
                return 1;
            }
            else
            {
                // ...and y is not null, compare the
                // lengths of the two strings.
                //
                int retval = x.grade.CompareTo(y.grade);

                if (retval != 0)
                {
                    // If the strings are not of equal length,
                    // the longer string is greater.
                    //
                    return retval;
                }
                else
                {
                    // If the strings are of equal length,
                    // sort them with ordinary string comparison.
                    //
                    return x.grade.CompareTo(y.grade);
                }
            }
        }
    }

}

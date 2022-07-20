using Basic;
using Comparator;
using GenericComparator;
using CallbackFunc;

public class BubbleSort
{
    static void PrintArr<T>(T[] arr)
    {
        Console.WriteLine("["+String.Join(",",arr)+"]");
    }

    public static void Sort(int[] arr)
    {
        // // basic
        // PrintArr(Sort.BSort(arr));

        // // comparator
        // IntComparator inc = new IntComparator();
        // arr.BSort(inc);
        // PrintArr(arr);

        // // comparator with generics
        // double[] dArr = { 3, 4, 2, 1 };
        // DoubleComparator dc = new DoubleComparator();
        // dArr.BSort(dc);
        // PrintArr(dArr);


        // callback
        Func<int, int, int> comparator = (int a, int b) => a > b ? 1 : -1;
        arr.BSort(comparator);
        PrintArr(arr);
    }
}

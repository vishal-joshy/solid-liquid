namespace GenericComparator
{
    public interface IComparatorStrategy<T>
    {
        int Execute(T a, T b);
    }

    public class IntComparator : IComparatorStrategy<int>
    {
        public int Execute(int a, int b)
        {
            return a > b ? 1 : (b < a) ? -1 : 0;
        }
    }

    public class DoubleComparator : IComparatorStrategy<double>
    {
        public int Execute(double a, double b)
        {
            return a > b ? 1 : (b < a) ? -1 : 0;
        }
    }

    public static class ArrSortExtension
    {
        public static void BSort<T>(this T[] arr, IComparatorStrategy<T> strategy)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (strategy.Execute(arr[j], arr[j + 1]) > 0)
                    {
                        T temp = arr[j + 1];
                        arr[j + 1] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
        }
    }
}
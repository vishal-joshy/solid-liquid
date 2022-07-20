namespace Comparator
{
    public interface IComparatorStrategy
    {
        int Execute(Object a, Object b);
    }

    public class IntComparator : IComparatorStrategy
    {
        public int Execute(Object a, Object b)
        {
            int pa = (int)a;
            int pb = (int)b;
            return pa > pb ? 1 : (pb < pa) ? -1 : 0;
        }
    }

    public static class ArrSortExtension
    {
        public static void BSort(this int[] arr, IComparatorStrategy strategy)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (strategy.Execute(arr[j], arr[j + 1]) > 0)
                    {
                        int temp = arr[j + 1];
                        arr[j + 1] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
        }
    }
}

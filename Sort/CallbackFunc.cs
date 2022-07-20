namespace CallbackFunc
{
    public static class ArrSortExtension
    {
        public static void BSort<T>(this T[] arr, Func<T, T, int> fn)
        {
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    for (int j = 0; j < arr.Length - i - 1; j++)
                    {
                        if (fn(arr[j], arr[j + 1]) > 0)
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
}
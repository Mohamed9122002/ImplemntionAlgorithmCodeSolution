using System.Buffers;

namespace InsertionSort
{
    internal class Program
    {
        public static void insertionSort(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++) 
            {
                int key = arr[i];
                int j;
                for (j = i - 1; j >= 0 && arr[j] > key; j--)
                {
                    arr[j + 1] = arr[j];
                }

                arr[j + 1] = key;
            }
            Console.WriteLine(string.Join(",", arr));

        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            insertionSort([9, 5, 1, 4]);
            Console.WriteLine("Sucess");
        }
    }
}

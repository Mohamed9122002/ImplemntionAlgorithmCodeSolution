namespace BinarySearch
{
    internal class Program
    {
        public static int BinarySearch(int[] array, int key)
        {
            int low = 0;
            int high = array.Length - 1;
            while (low <= high)
            {
                int mid = (low + high) / 2;
                if (array[mid] == key)                
                    return mid ;       
                else
                
                    if (key > array[mid])
                        low = mid + 1; // Search in the right half
                    else
                        high = mid - 1; // Search in the left half
            }
            return -1;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World! Bainay Search");
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int key = 5;
            int result = BinarySearch(array, key);
            if (result != -1)
            {
                Console.WriteLine($"Element found at index: {result}");
            }
            else
            {
                Console.WriteLine("Element not found in the array.");
            }
        }
    }
}

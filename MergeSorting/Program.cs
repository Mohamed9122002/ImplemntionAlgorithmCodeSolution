namespace MergeSorting
{
    internal class Program
    {
        // Merge Sort Algorithm
        // inputs arrary  , start ,end 
        public static void MergeSort(int[] array, int start, int end)
        {
            // exit if end <= start 
            if (end <= start) return;
            // Calculate the midpoint
            int midpoint = (end + start ) / 2;
            // Recursively sort the left half
            MergeSort(array, start, midpoint);
            // Recursively sort the right half
            MergeSort(array, midpoint + 1, end);
            // Merge the sorted halves
            Merge(array, start, midpoint, end);
        }
        // Merge 
        // inputs array, start , midpoint,end 
        public static void Merge(int[] array, int start, int midpoint, int end)
        {
            int i, j, k;
            int left_length = midpoint - start + 1;
            int right_length = end - midpoint;
            // Create Tow Arrays
            int[] leftArray = new int[left_length];
            int[] rightArray = new int[right_length];
            // Fill the left array
            for (i = 0; i < left_length; i++)
            {
                leftArray[i] = array[start + i];
            }
            // Fill the right array
            for (j = 0; j < right_length; j++)
            {
                rightArray[j] = array[midpoint + 1 + j];
            }
            // Initialize indices
            i = 0; // Index for left array
            j = 0; // Index for right array
            k = start; // Index for merged array
            // Compare And Sort 
            while (i < left_length && j < right_length)
            {
                if(leftArray[i] <= rightArray[j])
                {
                    array[k] = leftArray[i];
                    i++;
                }
                else
                {
                    array[k] = rightArray[j];
                    j++;
                }
                k++;

            }

            // move Remain items 
            while (i < left_length)
            {
                array[k] = leftArray[i];
                i++;
                k++;
            }
            while (j < right_length)
            {
                array[k] = rightArray[j];
                j++;
                k++;


            }

        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World! Merge Sorting ");
            int[] array = { 8, 65, 9, 7, 3, 5, 54 };

            Console.WriteLine(String.Join(", ", array));
            MergeSort(array, 0, array.Length - 1);
            Console.WriteLine(String.Join(", ", array));
        }
    }
}

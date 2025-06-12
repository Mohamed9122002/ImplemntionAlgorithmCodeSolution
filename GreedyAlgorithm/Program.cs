using GreedyAlgorithm.FractionalKnapsackProblem;
using System.Diagnostics;

namespace GreedyAlgorithm
{
    internal class Program
    {
        //  Greedy Algorithm – Activity Selection
        public static List<int> GreedyActivitySelection(int[] start, int[] end)
        {
            List<int> resultCount = new List<int> { 0 };
            int j = 0;
            for (int i = 1; i < start.Length; i++)
            {
                if (start[i] >= end[j])
                {
                    resultCount.Add(i);
                    j = i; // Update the last selected activity
                }
            }
            return resultCount;
        }
        #region Fractional Knapsack Problem
        public static void MergeSort(List<Item> array, int start, int end)
        {
            if (end <= start) return;

            int midpoint = (start + end) / 2;
            MergeSort(array, start, midpoint);
            MergeSort(array, midpoint + 1, end);
            Merge(array, start, midpoint, end);
        }

        public static void Merge(List<Item> array, int start, int midpoint, int end)
        {
            int i, j, k;
            int leftLength = midpoint - start + 1;
            int rightLength = end - midpoint;

            var left = new List<Item>();
            var right = new List<Item>();

            for (i = 0; i < leftLength; i++) left.Add(array[start + i]);
            for (i = 0; i < rightLength; i++) right.Add(array[midpoint + 1 + i]);

            i = 0; j = 0; k = start;

            while (i < left.Count && j < right.Count)
            {
                if (left[i].Ratio > right[j].Ratio)
                {
                    array[k] = left[i];
                    i++;
                    k++;
                }
                else
                {
                    array[k] = right[j];
                    j++;
                    k++;
                }
            }

            while (i < left.Count) {
                array[k] = left[i];
                i++;
                k++;
            }
            while (j < right.Count)
            {
                array[k] = right[j];
                j++;
                k++;
            }
        }
        public static void PrintArray(List<Item> items)
        {
            Console.WriteLine("n\tv\tw\tr");
            foreach (var item in items)
            {
                Console.WriteLine($"{item.Name}\t{item.Value:F2}\t{item.Weight:F2}\t{item.Ratio:F2}");
            }
        }
        public static void PrintItems(Knapsack bag)
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine($"total value: {bag.TotalValue}");
            Console.WriteLine($"current capacity: {bag.CurrentCapacity}");
            Console.WriteLine("items:");
            Console.WriteLine("n\tv\tw");
            foreach (var item in bag.Items)
            {
                Console.WriteLine($"{item.Name}\t{item.Value:F2}\t{item.Weight:F2}");
            }
        }
        #endregion
        static void Main(string[] args)
        {
            //int[] Start = { 9, 10, 11, 12, 13, 15 };
            //int[] End = { 11, 11, 12, 14, 15, 16 };
            //List<int> selectedActivities = GreedyActivitySelection(Start, End);
            //Console.WriteLine("Selected activity indices: " + string.Join(", ", selectedActivities));
            //// Time Complexity: O(n)

            #region Sorted Characters Frequencies
            //CharactersFrequencies cf = new CharactersFrequencies();
            //string msg = "Hello World";
            ////cf.ASCIIMethod(msg);
            //cf.ASCIIMethod(msg);
            //cf.AnyCodeMethod(msg);
            #endregion
            #region Huffman Coding
            //string msg = "internet";
            //HuffmanCode huff = new HuffmanCode(msg);

            //foreach (char k in huff.codes.Keys)
            //{
            //    Console.Write(k + " ");
            //    Console.WriteLine(huff.codes[k]);
            //}
            #endregion
            #region Fractional Knapsack Problem
            double[] Values = { 4, 9, 12, 11, 6, 5 };
            double[] weights = { 1, 2, 10, 4, 3, 5 };

            var newitems = new List<Item>();

            for (int i = 0; i < Values.Length; i++)
            {
                newitems.Add(new Item(Values[i], weights[i], $"#{i}"));
            }

            // Sort items by ratio using merge sort
            MergeSort(newitems, 0, newitems.Count - 1);

            // Print sorted array
            PrintArray(newitems);

            // Create knapsack and add items
            Knapsack bag = new Knapsack(12);
            int j = 0;
            while (bag.CurrentCapacity < bag.MaxCapacity && j < newitems.Count)
            {
                bag.AddItem(newitems[j]);
                j++;
            }

            // Print knapsack contents
            PrintItems(bag);
            #endregion

        }
    }
}

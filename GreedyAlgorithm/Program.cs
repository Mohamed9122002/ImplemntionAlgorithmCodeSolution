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
        #region Sorted Characters Frequencies

        #endregion
        static void Main(string[] args)
        {
            //int[] Start = { 9, 10, 11, 12, 13, 15 };
            //int[] End = { 11, 11, 12, 14, 15, 16 };
            //List<int> selectedActivities = GreedyActivitySelection(Start, End);
            //Console.WriteLine("Selected activity indices: " + string.Join(", ", selectedActivities));
            //// Time Complexity: O(n)

            #region Sorted Characters Frequencies
            CharactersFrequencies cf = new CharactersFrequencies();
            string msg = "Hello World";
            //cf.ASCIIMethod(msg);
            cf.ASCIIMethod(msg);
            cf.AnyCodeMethod(msg);
            #endregion

        }
    }
}

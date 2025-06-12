using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedyAlgorithm
{
    public class CharactersFrequencies
    {
        public CharactersFrequencies() { }
        public void ASCIIMethod(string message)
        {
            Console.WriteLine("ASCIIMethod");
            int[] frequency = new int[127];
            for (int i = 0; i < message.Length; i++)
            {
                // Convert Char to ASCII value 
                int CurrentCode = (int)message[i];
                frequency[CurrentCode]++;
            }
            for (int i = 0; i < frequency.Length; i++)
            {
                if (frequency[i] > 0)
                {
                    Console.WriteLine($"Character: {(char)i}, Frequency: {frequency[i]}");
                }
            }
        }

        // UTF-8 Method
        public void AnyCodeMethod(string message)
        {
            Console.WriteLine("AnyCodeMethod");
            Hashtable frequency = new Hashtable();
            for (int i = 0; i < message.Length; i++)
            {
                if (frequency[message[i]] is null)
                {
                    frequency[message[i]] = 1;
                }
                else
                {
                    frequency[message[i]] = (int)frequency[message[i]] + 1;
                }

            }
            foreach (char entry in frequency.Keys)
            {
                Console.WriteLine($"Character: {entry}, Frequency: {frequency[entry]}");
            }
            SortedHashTable(frequency);
        }


        // Sorted Characters Frequencies 
        public void SortedHashTable(Hashtable Freq)
        {
            int[,] FreqArray = new int[Freq.Count, 2];
            int index = 0;
            foreach (char k in Freq.Keys)
            {
                FreqArray[index, 0] = (int)k; // ASCII value
                FreqArray[index, 1] = (int)Freq[k]; // Frequency
                index++;
            }
            // Sort the array based on frequency
            this.Sorted(FreqArray, 0, Freq.Count - 1);
            Console.WriteLine("Print Sorted Data...");
            for (index = 0; index < Freq.Count; index++)
            {
                Console.WriteLine((char)FreqArray[index, 0] + " ");
                Console.WriteLine(FreqArray[index, 1]);
            }

        }
        public void Sorted(int[,] array, int start, int end)
        {
            if (end <= start) return;
            int midPoint = (start + end) / 2;
            Sorted(array, start, midPoint);
            Sorted(array, midPoint + 1, end);
            Merge(array, start, midPoint, end);

        }

        private void Merge(int[,] array, int start, int midPoint, int end)
        {
            int i, j, k;
            int leftLength = midPoint - start + 1;
            int rightLength = end - midPoint;
            int[,] leftArray = new int[leftLength, 2];
            int[,] rightArray = new int[rightLength, 2];
            for (i = 0; i < leftLength; i++)
            {
                leftArray[i, 0] = array[start + i, 0];
                leftArray[i, 1] = array[start + i, 1];
            }
            for (j = 0; j < rightLength; j++)
            {
                rightArray[j, 0] = array[midPoint + 1 + j, 0];
                rightArray[j, 1] = array[midPoint + 1 + j, 1];
            }
            i = 0; // Initial index of first sub-array
            j = 0; // Initial index of second sub-array
            k = start; // Initial index of merged sub-array
            while (i < leftLength && j < rightLength)
            {
                if (leftArray[i, 1] <= rightArray[j, 1])
                {
                    array[k, 0] = leftArray[i, 0];
                    array[k, 1] = leftArray[i, 1];
                    i++;
                }
                else
                {
                    array[k, 0] = rightArray[j, 0];
                    array[k, 1] = rightArray[j, 1];
                    j++;
                }
                k++;
            }
            while (i < leftLength)
            {
                array[k, 0] = leftArray[i, 0];
                array[k, 1] = leftArray[i, 1];
                i++;
                k++;
            }
            while (j < rightLength)
            {
                array[k, 0] = rightArray[j, 0];
                array[k, 1] = rightArray[j, 1];
                i++;
                k++;
            }

        }
    }
}

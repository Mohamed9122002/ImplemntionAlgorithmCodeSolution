using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedyAlgorithm
{
    public class HuffmanCode
    {
        private char internal_char = (char)0;
        public Hashtable codes = new Hashtable();
        public PriorityQueue<HeapNode, int> priorityQueue = new PriorityQueue<HeapNode, int>();
        public HuffmanCode(string message)
        {
            // Get the chars frequences
            Hashtable freqHash = new Hashtable();
            int i;
            for (i = 0; i < message.Length; i++)
            {
                if (freqHash[message[i]] == null)
                {
                    freqHash[message[i]] = 1;
                }
                else
                {
                    freqHash[message[i]] = (int)freqHash[message[i]] + 1;

                }

            }
            // Convert Hashtable to Queue[minHeap]
            i = 0;
            foreach (char key in freqHash.Keys)
            {
                HeapNode node = new HeapNode(key, (int)freqHash[key]);
                priorityQueue.Enqueue(node, node.frequency);
                i++;
            }
            // Build the Huffman Tree
            HeapNode Top, left, right;
            int newFrequency;
            while (priorityQueue.Count != 1)
            {
                left = priorityQueue.Dequeue();
                right = priorityQueue.Dequeue();
                newFrequency = left.frequency + right.frequency;
                Top = new HeapNode(internal_char, newFrequency);
                Top.left = left;
                Top.right = right;
                priorityQueue.Enqueue(Top, newFrequency);
            }
            // Generate the codes

            this.GenerateCodes(priorityQueue.Peek(), string.Empty);
        }
        private void GenerateCodes(HeapNode node, string code)
        {
            if (node == null) return;
            if (node.data != internal_char)
            {
                codes[node.data] = code;

            }
            GenerateCodes(node.left, code + "0");
            GenerateCodes(node.right, code + "1");
        }
    }
}

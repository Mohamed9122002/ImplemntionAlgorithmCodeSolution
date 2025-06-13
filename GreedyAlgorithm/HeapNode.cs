using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedyAlgorithm
{
    public class HeapNode
    {
        public char data;
        public int frequency; 
        public HeapNode left, right;
        public HeapNode(char data, int frequency)
        {
            this.data = data;
            this.frequency = frequency;
            left = right = null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedyAlgorithm.FractionalKnapsackProblem
{
    public class Item
    {
        public double Value { get; set; }
        public double Weight { get; set; }
        public string Name { get; set; }
        public double Ratio { get; set; }
        public Item(double value, double weight, string name)
        {
            Name = name;
            Value = value;
            Weight = weight;
            Ratio = value / weight; // Calculate the value-to-weight ratio
        }

    }
}

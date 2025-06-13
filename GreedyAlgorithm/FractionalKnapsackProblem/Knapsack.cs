using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedyAlgorithm.FractionalKnapsackProblem
{
   public class Knapsack
    {
        public double MaxCapacity { get; private set; }
        public double CurrentCapacity { get; private set; } = 0;
        public double TotalValue { get; private set; } = 0;
        public List<Item> Items { get; private set; } = new List<Item>();
        public Knapsack(double maxCapacity)
        {
            MaxCapacity = maxCapacity;
        }
        public void AddItem(Item newItem)
        {
            double remaining = MaxCapacity - CurrentCapacity;

            if (newItem.Weight > remaining)
            {
                newItem.Weight = remaining;
                newItem.Value = newItem.Ratio * remaining;
            }

            Items.Add(newItem);
            CurrentCapacity += newItem.Weight;
            TotalValue += newItem.Value;
        }

    }
}

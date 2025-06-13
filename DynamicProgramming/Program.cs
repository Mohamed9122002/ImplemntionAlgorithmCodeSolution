namespace DynamicProgramming
{
    class State
    {
        public string From { get; set; }
        public string To { get; set; }
        public int Cost { get; set; }
    }
    internal class Program
    {

        static void Main(string[] args)
        {
            #region Stagecoach Problem 
            string[] labels = ["A", "B", "C", "D", "E", "F", "G", "H", "I", "J"];

            int[,] data = {
            {0, 2, 4, 3, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 7, 4, 6, 0, 0, 0},
            {0, 0, 0, 0, 3, 2, 4, 0, 0, 0},
            {0, 0, 0, 0, 4, 1, 5, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 1, 4, 0},
            {0, 0, 0, 0, 0, 0, 0, 6, 3, 0},
            {0, 0, 0, 0, 0, 0, 0, 3, 3, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 3},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 4},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        };
            int n = data.GetLength(0);
            var states = new State[n];
            states[n - 1] = new State { From = "", To = "", Cost = 0 };
            for (int i = n - 2; i >=0 ; i--)
            {
                int j =i+1;
                states[i] = new State { From = labels[i], To = labels[j], Cost = int.MaxValue };
                for ( j = i + 1; j < n; j++)
                {
                    if (data[i, j] == 0) continue;
                    int newCost = data[i, j] + states[j].Cost;
                    if (newCost < states[i].Cost)
                    {
                        states[i].To = labels[j];
                        states[i].Cost = newCost;
                    }
                }
            }

            Console.WriteLine("Minimum Cost: " + states[0].Cost);
            List<string> path = new List<string> { "A" };
            int index = 0;

            while (index < states.Length)
            {
                if (states[index].From == path[^1])
                {
                    path.Add(states[index].To);
                }
                index++;
            }

            Console.WriteLine("Minimum path: " + string.Join(" -> ", path));
        }

        #endregion
    }
}


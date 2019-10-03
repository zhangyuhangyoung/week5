using System;

namespace GreedyFlorist
{
    class Program
    {
        static int getMinimumCost(int k, int[] c)
        {
            int flowers = c.Length;
            int old = flowers - k;
            int minCost = 0;
            int d = 0;
            Array.Sort(c);
            Array.Reverse(c);
            for (int i = 0; i < flowers; i++)
            {
                if (i % k == 0)
                {
                    d++;
                }
                minCost = minCost + d * c[i];

            }
            return minCost;
        }

        static void Main(string[] args)
        {
            int k = 3;
            int[] c = new int[] { 1, 3, 5, 7 ,9 };
            int minimumCost = getMinimumCost(k, c);

            Console.WriteLine(minimumCost);

        }
    }
}

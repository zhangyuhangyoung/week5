using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

namespace CutTheTree
{
    class Program
    {
        static void dfs(List<List<int>> v, List<int> data, List<bool> b, List<int> sum, int j)
        {
            int s = 0;
            for (int p = 0; p < v[j].Count; p++)
            {
                if (b[v[j][p]] == false)
                {
                    b[v[j][p]] = true;
                    dfs(v, data, b, sum, v[j][p]);
                    s += sum[v[j][p]];
                }
            }
            sum[j] = s + data[j - 1];
        }
        static int cutTheTree(List<int> data, List<List<int>> edges)
        {
            int total = 0;
            int n = data.Count;
            for (int i = 0; i < n; i++)
                total = total + data[i];
            int min = total;

            List<List<int>> v = new List<List<int>>();
            //v=new List<int>();
            for (int i = 0; i < n; i++)
            {
                v[i] = new List<int>();
            }
            for (int i = 0; i < n; i++)
            {
                v[edges[i][0]].Add(edges[i][1]);
                v[edges[i][1]].Add(edges[i][0]);
            }
            List<int> sum = new List<int>();
            List<bool> b = new List<bool>();

            b[1] = true;
            dfs(v, data, b, sum, 1);
            for (int i = 2; i <= n; i++)
                if (Math.Abs(total - 2 * sum[i]) < min)
                    min = Math.Abs(total - 2 * sum[i]);


            return min;
        }
        static void Main(string[] args)
        {
            List<int> data = new List<int> { 100, 200, 100, 500, 100, 600 };
            int [][] arr=new int[5][2]{ {1, 2 }, { 2, 3 }, { 2, 5 }, { 4, 5 }, { 5, 6 } };
            List<List<int>> edges = new List<List<int>> {{1, 2 },{ 2, 3 },{ 2, 5 },{ 4, 5 },{ 5, 6 }};
            edges.Add(0,1,2);
            int result = cutTheTree(data, edges);

            Console.WriteLine(result);

        }
    }
}

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
class Point1
{
    public int x;
    public int y;
}
class Solution
{

    // Complete the knightlOnAChessboard function below.
    static string[] knightlOnAChessboard(int n)
    {
        int[,] result = new int[n, n];
        string[] s1 = new string[n];
        for (int i = 1; i < n; ++i)
        {
            for (int j = 1; j < n; ++j)
            {
                int px = i - 1;
                int py = j - 1;
                if (result[py, px] != 0)
                {
                    result[px, py] = result[py, px];
                }
                else
                {
                    result[px, py] = steps(n, i, j);
                }
            }
        }
        for (int i = 0; i < n - 1; ++i)
        {
            StringBuilder sb = new StringBuilder();
            bool first = true;
            for (int j = 0; j < n - 1; ++j)
            {
                if (!first)
                {
                    sb.Append(" ");
                }

                first = false;
                sb.Append(result[i, j]);
            }
            s1[i] = sb.ToString();
        }
        return s1;
    }

    static int steps(int n, int i, int j)
    {
        int[,] distances = new int[n, n];
        int[] xNew = new int[8] { 1, 1, 1, 1, -1, -1, -1, -1 };
        int[] yNew = new int[8] { 1, 1, -1, -1, 1, 1, -1, -1 };
        for (int q = 0; q < 8; ++q)
        {
            if (q % 2 == 0)
            {
                xNew[q] *= i;
                yNew[q] *= j;
            }
            else
            {
                xNew[q] *= j;
                yNew[q] *= i;
            }
        }

        Point1 p = new Point1()
        {
            x = 0,
            y = 0
        };

        Stack<Point1> stack = new Stack<Point1>();
        stack.Push(p);
        while (stack.Count > 0)
        {
            p = stack.Pop();
            int totalMoves = distances[p.x, p.y] + 1;
            for (int q = 0; q < 8; ++q)
            {
                int newX = p.x + xNew[q];
                if (newX < 0 || newX >= n)
                {
                    continue;
                }

                int newY = p.y + yNew[q];
                if (newY < 0 || newY >= n)
                {
                    continue;
                }

                int oldMoves = distances[newX, newY];
                if (oldMoves == 0)
                {
                    oldMoves = int.MaxValue;
                }

                if (totalMoves < oldMoves)
                {
                    distances[newX, newY] = totalMoves;
                    Point1 px = new Point1()
                    {
                        x = newX,
                        y = newY
                    };

                    stack.Push(px);
                }
            }
        }

        if (distances[n - 1, n - 1] == 0)
        {
            return -1;
        }
        else
        {
            return distances[n - 1, n - 1];
        }
    }

    static void Main(string[] args)
        {
        int n = 5;
        string[] s= knightlOnAChessboard(n);
            Console.WriteLine(String.Join("\n", s));
        }
    }


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

namespace TheBombermanGame
{
    class Point1
    {
        public int x;
        public int y;
    }
    class Program
    {
        static string[] bomberMan(int n, string[] grid)
        {
            int m = grid.Length;
            Stack<Point1> stack = new Stack<Point1>();
            char[][] charGrid = new char[m][];
            int d = 0, k = 0;
            // base on pop bomb check 4 directs point {-1,0},{1,0},{0,1},{0,-1}
            int[,] dr={ { -1, 0 },{ 1, 0 },{ 0, -1 },{ 0, 1 }};

            if (n > 7)
            {
                if (n % 2 == 0) d = 2;
                if ((n - 1) % 4 == 0) d = 5;
                if ((n - 1) % 4 == 2) d = 7;
            }
            else d = n;

            for (int i = 0; i < m; i++)
            {
                charGrid[i] = grid[i].ToCharArray();
            }
            if (n == 1) goto end;
            for (int a = 0; a < d; a++)
            {
                k++;
            start:
                for (int b = 0; b < m; b++)
                {
                    for (int c = 0; c < grid[0].Length; c++)
                    {
                        if (charGrid[b][c] == 'O')
                        {
                            stack.Push(new Point1() { x = b, y = c });
                        }
                        else
                        {
                            //fill all cells with 'O'
                            charGrid[b][c] = 'O';
                        }
                    }
                }
                k++;
                if (k == d) goto end;
                while (stack.Count > 0)
                {
                    Point1 p = stack.Pop();
                    //set cell to visited continue to traversal the grid
                    charGrid[p.x][p.y] = '.';
                    for (int i = 0; i < 4; i++)
                    {
                        //if dr[i]=-1 check above line; dr[i]=1 check under line base on pop point
                        int newX = p.x + dr[i,0];
                        int newY = p.y + dr[i,1];

                        if (newX < 0 || newY < 0) continue;
                        if (newX >= m || newY >= charGrid[0].Length) continue;
                        charGrid[newX][newY] = '.';
                    }
                }
                k++;
                if (k < d) goto start;
            }
        end:
            string[] result = new string[m];
            for (int i = 0; i < m; i++)
            {
                result[i] = new string(charGrid[i]);
            }
            return result;

        }
        static void Main(string[] args)
        {
            int n = 3;//seconds
            string[] grid = new string[]{ ".......",  "...O...", "....O..",".......","OO.....", "OO....." };
            string[] result = bomberMan(n, grid);

            Console.WriteLine(string.Join("\n", result));
        }
    }
}

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

class Solution
{

    // Complete the flippingMatrix function below.
    static int flippingMatrix(int[][] matrix)
    {
        int n = matrix.Length;
        int ans = 0;
        for (int i = 0; i < n / 2; i++)
        {
            for (int j = 0; j < n / 2; j++)
            {
                ans += Math.Max(Math.Max(matrix[i][j], matrix[i][n - j - 1]), Math.Max(matrix[n - i - 1][j], matrix[n - i - 1][n - j - 1]));
            }
        }
        return ans;
    }

    static void Main(string[] args)
        {
        int n = 2;
        int[][] arr = new int[2*n][];
        arr[0]= Array.ConvertAll("112 42 83 119".Split(' '), matrixTemp => Convert.ToInt32(matrixTemp));
        arr[1] = Array.ConvertAll("56 125 56 49".Split(' '), matrixTemp => Convert.ToInt32(matrixTemp));
        arr[2] = Array.ConvertAll("15 78 101 43".Split(' '), matrixTemp => Convert.ToInt32(matrixTemp));
        arr[3] = Array.ConvertAll("62 98 114 108".Split(' '), matrixTemp => Convert.ToInt32(matrixTemp));
        int result = flippingMatrix(arr);
        Console.WriteLine(result);
        }
    }


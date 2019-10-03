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

    // Complete the maxSubarray function below.
    static int[] maxSubarray(int[] arr)
    {
        return new int[] { maxOfSubarray(arr), maxOfSubSequence(arr) };
    }
    public static int maxOfSubSequence(int[] a)
    {
        int maxSum = 0;
        int[] result = new int[2];
        //get maxSum
        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] > 0 && maxSum <= 0)
            {
                maxSum = a[i];
            }
            else if (a[i] > 0 && maxSum > 0)
            {
                maxSum = maxSum + a[i];
            }
            else if (a[i] < 0 && maxSum == 0)
            {
                maxSum = a[i];
            }
            else if (a[i] < 0 && maxSum < 0)
            {
                maxSum = a[i] > maxSum ? a[i] : maxSum;
            }

        }
        return maxSum;
    }
    public static int maxOfSubarray(int[] a)
    {
        int currentMax = a[0], max = a[0];
        for (int i = 1; i < a.Length; i++)
        {
            currentMax = Math.Max(a[i], currentMax + a[i]);
            max = Math.Max(max, currentMax);
        }
        return max;
    }
    static void Main(string[] args)
        {
        int[] arr = { 2 ,- 1, 2, 3 ,4 ,- 5 };
        int[] s = maxSubarray(arr);
            Console.WriteLine(string.Join(" ", s));
        }
    }


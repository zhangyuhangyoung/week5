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

namespace ZigZagSequence
{
    class Program
    {
        public static void findZigZagSequence(int[] a, int n)
        {
            Array.Sort(a);
            int mid = (n + 1) / 2 - 1;
            int temp = a[mid];
            a[mid] = a[n - 1];
            a[n - 1] = temp;

            int st = mid + 1;
            int ed = n - 2;
            while (st <= ed)
            {
                temp = a[st];
                a[st] = a[ed];
                a[ed] = temp;
                st = st + 1;
                ed = ed - 1;
            }
            for (int i = 0; i < n; i++)
            {
                if (i > 0) Console.Write(" ");
                Console.Write(a[i]);
            }
        }
        static void Main(string[] args)
        {
            int n = 7;
            int[] a = new int[]{ 1, 2, 3, 4, 5, 6, 7 };
            findZigZagSequence(a, n);
        }
    }
}

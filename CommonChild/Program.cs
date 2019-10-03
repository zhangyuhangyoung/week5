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

    // Complete the commonChild function below.
    static int commonChild(string s1, string s2)
    {
        int n = s1.Length;
        int[,] l = new int[n + 1, n + 1];
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                if (s1[i - 1] == s2[j - 1])
                {
                    l[i, j] = l[i - 1, j - 1] + 1;
                }
                else
                {
                    l[i, j] = Math.Max(l[i - 1, j], l[i, j - 1]);
                }
            }
        }
        return l[n, n];
    }
    static void Main(string[] args)
      {
        string s1 = "HARRY";
        string s2 = "SALLY";
    
        int result = commonChild(s1, s2);
            Console.WriteLine(result);
        }
    }


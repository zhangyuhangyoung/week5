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

    // Complete the biggerIsGreater function below.
    static string biggerIsGreater(string w)
    {
        int l = w.Length;
        char[] letter = w.ToCharArray();

        for (int i = l - 1; i > 0; i--)
        {
            if (letter[i] > letter[i - 1])
            {
                char c = letter[i - 1];
                char[] s = w.Substring(i - 1, l + 1 - i).ToCharArray();
                Array.Sort(s);
                int first = 0;
                for (int j = 0; j < l + 1 - i; j++)
                {
                    if (s[j] > c)
                    {
                        letter[i - 1] = s[j];
                        first = j;
                        break;
                    }
                }
                for (int j = 0, m = i; j < l + 1 - i; j++)
                {
                    if (j != first)
                    {
                        letter[m] = s[j];
                        m++;
                    }
                }
                string result = new string(letter);
                return result;

            }
        }

        return "no answer";
    }

    static void Main(string[] args)
        {
         string s1 = "dcba";
         string s = biggerIsGreater(s1);
         Console.WriteLine(s);
        }
    }


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

    // Complete the countSort function below.
    struct Line
    {
        public int key;
        public string value;

        public Line(int key, string value)
        {
            this.key = key;
            this.value = value;
        }
    }

    static void countSort(List<List<string>> arr)
    {
        var lines = new List<Line>();
        for (var i = 0; i < arr.Count; ++i)
        {
            var num = Int32.Parse(arr[i][0]);
            var str = arr[i][1];
            if (i < arr.Count / 2)
            {
                str = "-";
            }
            lines.Add(new Line(num, str));
        }
        var orderedLines = lines.OrderBy(x => x.key).ToList();
        var sb = new StringBuilder();
        for (var i = 0; i < orderedLines.Count; ++i)
        {
            sb.Append(orderedLines[i].value).Append(" ");
        }
        Console.WriteLine(sb);
    }


    static void Main(string[] args)
        {
        List<List<string>> arr = new List<List<string>>{ new List<string> { "0", "ab" },new List<string> { "6", "cd" }, new List<string> { "0", "ef" },
            new List<string> {"6","gh" },new List<string>{"4","ij" },new List<string>{"0","ab" },new List<string>{"6","cd" },new List<string>{"0","ef" },
            new List<string> {"6","gh" },new List<string>{"0","ij"},new List<string> {"4","that" },new List<string>{"3","be" },new List<string>{"0","to" },
            new List<string> {"1","be" },new List<string>{"5","question" },new List<string>{"1"," or" },new List<string>{"2","not" },
            new List<string> {"4","is" },new List<string> {"2","to" },new List<string> {"4","the"} };
         countSort(arr);
        }
    }


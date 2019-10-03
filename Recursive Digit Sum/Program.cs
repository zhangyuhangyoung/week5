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

    static int countnumber(string n)
    {
        int total = 0;
        char[] num = n.ToCharArray();
        for (int i = 0; i < n.Length; i++)
        {
            total += int.Parse(num[i].ToString());
        }
        if (total > 9)
        {
            total = countnumber(total.ToString());
        }
        return total;
    }
    static int superDigit(string n, int k)
    {
        string bigNumber = "";
 
        int result = countnumber(n);
        result = result * k;
        bigNumber = result.ToString();
        result = countnumber(bigNumber);

        return result;
    }

    static void Main(string[] args)
        {
        

        string n = "123";

        int k = 3;

        int result = superDigit(n, k);

        Console.WriteLine(result);

    }
}


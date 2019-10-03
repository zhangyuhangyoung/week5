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

class Result
{

    /*
     * Complete the 'getWays' function below.
     *
     * The function is expected to return a LONG_INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. LONG_INTEGER_ARRAY c
     */
    private static Dictionary<Tuple<long, int>, long> mem = new Dictionary<Tuple<long, int>, long>();

    public static long getWays(int n, List<long> c)
    {
        return getWaysRec(n, c, c.Count);
    }

    static long getWaysRec(long money, List<long> c, int coinType)
    {
        if (coinType <= 0 || money < 0) return 0;
        if (money == 0) return 1;

        var key = new Tuple<long, int>(money, coinType);
        if (mem.ContainsKey(key)) return mem[key];

        mem[key] = getWaysRec(money, c, coinType - 1) + getWaysRec(money - c[coinType - 1], c, coinType);
        return mem[key];
    }
}

namespace TheCoinChangeProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 10;
            List<long> c = new List<long>{ 2, 5, 3, 6 };
            long result = Result.getWays(n, c);
            Console.WriteLine(result);
        }
    }
}

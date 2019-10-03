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
     * Complete the 'initialize' function below.
     *
     * The function accepts STRING s as parameter.
     */
    static int mod = 1000000007;
    static int alphabets = 26;
    static int[,] chars;
    static int maxOccur = 0;
    static int[] modFact;

    public static int inv_mod(int a, int b)
    {
        int b1 = b, t, q;
        int x1 = 0, x2 = 1;
        if (b == 1) return 1;
        while (a > 1)
        {
            q = a / b;

            t = b;
            b = a % b;
            a = t;

            t = x1;
            x1 = x2 - q * x1;
            x2 = t;

        }
        if (x2 < 0)
            x2 += b1;
        return x2;
    }

    public static void initialize(string s)
    {
        // This function is called once before all queries.
        chars = new int[s.Length + 1, alphabets];

        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];
            for (int j = 0; j < alphabets; j++)
                chars[i + 1, j] = chars[i, j];
            chars[i + 1, c - 'a']++;
            if (chars[i + 1, c - 'a'] > maxOccur)
                maxOccur = chars[i + 1, c - 'a'];
        }

        modFact = new int[s.Length / 2 + 1];
        modFact[0] = 1;
        //Calculate mod of factorial n
        for (int i = 1; i < modFact.Length; i++)
            modFact[i] = (int)((modFact[i - 1] * (long)i) % mod);

    }


    public static int answerQuery(int l, int r)
    {
        // Return the answer for this query modulo 1000000007.
        int[] charSet = new int[26];
        int nSingle = 0;

        int numMaxPal = 1;

        int halfParLen = 0;
        for (int i = 0; i < alphabets; i++)
        {
            charSet[i] = chars[r, i] - chars[l - 1, i];
            if (charSet[i] == 0)
                continue;

            if (charSet[i] % 2 == 1)
                nSingle++;

            halfParLen += charSet[i] / 2;
            numMaxPal = (int)((numMaxPal * (long)inv_mod(modFact[charSet[i] / 2], mod)) % mod);
        }
        if (nSingle != 0)
            numMaxPal = (int)((numMaxPal * (long)nSingle) % mod);

        numMaxPal = (int)((numMaxPal * (long)modFact[halfParLen]) % mod);
        return numMaxPal;

    }

}

class Solution
{
    public static void Main(string[] args)
    {


        string s = "madamimadam";

        Result.initialize(s);

        int l = 4;

        int r = 7;

        int result = Result.answerQuery(l, r);

        Console.WriteLine(result);
        }

        
}

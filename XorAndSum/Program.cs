using System;

namespace XorAndSum
{
    class Program
    {
        static int xorAndSum(string a, string b)
        {
            long mod = 1000000007;
            double x = 0;
            long A = long.Parse(a.ToString());
            long B = long.Parse(b.ToString());
            long sum = 0;
            int i = 0;
            while (A > 0)
            {      // for decimal a
                x += Math.Pow(2, i) * (A % 10);
                i++;
                A /= 10;
            }
            A = Int32.Parse(x.ToString());
            x = i = 0;
            while (B > 0)
            {      //for decimal b
                x += Math.Pow(2, i) * (B % 10);
                i++;
                B /= 10;
            }
            B = Int32.Parse(x.ToString());
            for (i = 0; i < 314160; i++)
            {
                sum += A ^ (B << i);
            }
            return (int)(sum % mod);
        }
        static void Main(string[] args)
        {
            string a = "10";
            string b="1010";
            int result = xorAndSum(a, b);
            Console.WriteLine(result);
        }
    }
}

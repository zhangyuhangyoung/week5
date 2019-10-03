using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Time_in_Words
{
    enum hoursminutes { one = 1, two, three, four, five, six, seven, eight, nine, ten, eleven, twelve, thirteen, fourteen, quarter, sixteen, severteen, nineteen, twenty };

    class Program
    {
        public static string timeInWords(int h, int m)
        {
            string strTime = "";

            hoursminutes h1;
            hoursminutes t1;
            if (m > 30)
            {
                if (h == 12) h = 1;
                h++;
            }
            h1 = (hoursminutes)h;
            if (m == 0 || m == 60)
            {
                strTime = h1 + " o' clock";
            }
            else if (m == 1) strTime = "one minute past " + h1;

            else if (m > 30 && m != 45)
            {

                m = 60 - m;
                if (m > 20)
                {
                    m = m - 20;
                    strTime = "twenty ";
                }
                t1 = (hoursminutes)m;
                strTime = strTime + t1 + " minutes to " + h1;
            }
            else if (m == 45)
            {
                strTime = "quarter to " + h1;
            }
            else if (m == 30) strTime = "half past " + h1;
            else if (m == 15) strTime = "quarter past " + h1;
            else if (m < 30)
            {
                if (m > 20)
                {
                    m = m - 20;
                    strTime = "twenty ";
                }
                t1 = (hoursminutes)m;
                strTime = strTime + t1 + " minutes past " + h1;

            }
            return strTime;
        }
        static void Main(string[] args)
        {
            int h = 7;
            int m = 39;
            string s = timeInWords(h, m);
            Console.Write(s);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Tuple<char, int, string>[] operators = new Tuple<char, int, string>[5];
            operators[0] = Tuple.Create('+', 2, "left");
            operators[1] = Tuple.Create('-', 2, "left");
            operators[2] = Tuple.Create('*', 3, "left");
            operators[3] = Tuple.Create('/', 3, "left");
            operators[4] = Tuple.Create('^', 4, "right");

            string s = "";


        }
    }
}

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
            List<Tuple<char, int, string> > operators = new List<Tuple<char, int, string> >();
            char[] opers = {'+', '-', '*', '/', '^'};
            char[] nums = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            operators.Add(Tuple.Create('+', 2, "left"));
            operators.Add(Tuple.Create('-', 2, "left"));
            operators.Add(Tuple.Create('*', 3, "left"));
            operators.Add(Tuple.Create('/', 3, "left"));
            operators.Add(Tuple.Create('^', 4, "right"));

            string s = "";
            Stack<string> output = new Stack<string>();
            Stack<char> operatorStack = new Stack<char>();

            string input = Console.ReadLine().Replace(" ", "");
            int length = input.Length;

            for (int i = 0; i < length; i++)
            {
                if (input[i] == '(')  //   (
                {

                }
                
                else if (input[i] == ')')   //      )
                {

                }

                else if (opers.Contains(input[i]))      //      +,-,*,/,^
                {

                }
                
                else if (nums.Contains(input[i]))      //          numbers
                {
                    s += input[i];
                    if (i != length && nums.Contains(input[i + 1]))
                    {
                        i++;
                        while(i < length && nums.Contains(input[i]))
                        {
                            s += input[i];
                            i++;
                        }
                        i--;
                    }
                    Console.WriteLine(s);
                    s = "";
                }
            }
            Console.ReadKey();
        }
    }
}

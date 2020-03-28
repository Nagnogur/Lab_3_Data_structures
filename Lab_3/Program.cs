using System;
using System.Collections;
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
            bool negative = true;

            for (int i = 0; i < length; i++)
            {
                if (input[i] == '(')  //   (
                {
                    operatorStack.Push(input[i]);
                    negative = true;
                }
                
                else if (input[i] == ')')   //      )
                {
                    while (operatorStack.Peek() != '(')
                    {
                        CalcExpression(output, operatorStack.Peek());
                        operatorStack.Pop();
                    }
                    operatorStack.Pop();
                    negative = false;
                }

                else if (!negative && opers.Contains(input[i]))      //      +,-,*,/,^
                {
                    int index = Array.IndexOf(opers, input[i]);
                    if (operatorStack.Count == 0 || operatorStack.Peek() == '(' || (operators[Array.IndexOf(opers, operatorStack.Peek())].Item2 < operators[index].Item2))
                    {
                        operatorStack.Push(input[i]);
                    }
                    else
                    {
                        while (operatorStack.Count > 0 && operatorStack.Peek() != '(' && (operators[Array.IndexOf(opers, operatorStack.Peek())].Item2 > operators[index].Item2 || (operators[Array.IndexOf(opers, operatorStack.Peek())].Item2 == operators[index].Item2 && operators[index].Item3 == "left")))
                        {

                            CalcExpression(output, operatorStack.Peek());
                            operatorStack.Pop();
                        }
                        operatorStack.Push(input[i]);
                    }
                    negative = true;
                }
                
                else if (negative || nums.Contains(input[i]))      //          numbers
                {
                    s += input[i];
                    negative = false;
                    if (i != length - 1 && nums.Contains(input[i + 1]))
                    {
                        i++;
                        while(i < length && nums.Contains(input[i]))
                        {
                            s += input[i];
                            i++;
                        }
                        i--;
                    }
                    output.Push(s);
                    s = "";
                }
                

            }
            while(operatorStack.Count > 0)
            {
                CalcExpression(output, operatorStack.Peek());
                operatorStack.Pop();
            }
            PrintValues(output);
            Console.Write("  ||  ");
            PrintValues(operatorStack);
            Console.WriteLine();
            Console.WriteLine(output.Peek());
            Console.ReadKey();
        }

        public static void PrintValues(IEnumerable myCollection)
        {
            foreach (Object obj in myCollection)
                Console.Write("{0} ", obj);
        }

        public static void CalcExpression(Stack<string> stack1, char action)
        {
            int u = Convert.ToInt32(stack1.Peek());
            stack1.Pop();
            int v = Convert.ToInt32(stack1.Peek());
            stack1.Pop();
            int ans = 0;

            if (action == '+')
            {
                ans =  v + u;
            }
            else if (action == '-')
            {
                ans = v - u;
            }
            else if (action == '*')
            {
                ans = v * u;
            }
            else if (action == '/')
            {
                ans = v / u;
            }
            else if (action == '^')
            {
                ans = (int)Math.Pow(v, u);
            }
            stack1.Push(Convert.ToString(ans));
        }

    }
}

using System;
using System.Collections.Generic;

namespace Task1
{
    class Program
    {
        public static int CalculatePrefixExpression(string expression)
        {
            Stack<int> stack = new Stack<int>();

            string[] tokens = expression.Split(' ');

            for(int i = tokens.Length - 1; i >= 0; i--)
            {
                string token = tokens[i];

                if(int.TryParse(token, out int num))
                {
                    stack.Push(num);
                }
                else
                {
                    int operand1 = stack.Pop();
                    int operand2 = stack.Pop();

                    switch (token)
                    {
                        case "+":
                            stack.Push(operand1 + operand2);
                            break;

                        case "-":
                            stack.Push(operand1 - operand2);
                            break;

                        case "*":
                            stack.Push(operand1 * operand2);
                            break;

                        case "/":
                            stack.Push(operand1 / operand2);
                            break;

                        default:
                            throw new ArgumentException("Wrong operator: " + token);
                    }
                }
            }

            return stack.Pop();
        }

        public static void Main_Task1()
        {
            string expression = "+ 10 * 2 3"; 
            int result = CalculatePrefixExpression(expression);
            Console.WriteLine("Результат: " + result); 
        }
    }
}
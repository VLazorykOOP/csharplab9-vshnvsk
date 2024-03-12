using System.Collections;

namespace Task3
{
    class Program
    {
        public static void Main_Task3_1()
        {
            Console.WriteLine("Enter the expression in prefix form, separating operators and operands with spaces:");
            string expression = Console.ReadLine();

            ArrayList tokens = TokenizeExpression(expression);
            Console.WriteLine("Result: " + CalculatePrefixExpression(tokens));
        }

        static ArrayList TokenizeExpression(string expression)
        {
            string[] tokenArray = expression.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            ArrayList tokens = new ArrayList(tokenArray);
            return tokens;
        }

        static double CalculatePrefixExpression(ArrayList tokens)
        {
            Stack operandStack = new Stack();

            for (int i = tokens.Count - 1; i >= 0; i--)
            {
                string token = (string)tokens[i];
                if (IsOperator(token))
                {
                    double operand1 = (double)operandStack.Pop();
                    double operand2 = (double)operandStack.Pop();
                    double result = PerformOperation(token, operand1, operand2);
                    operandStack.Push(result);
                }
                else
                {
                    operandStack.Push(double.Parse(token));
                }
            }

            return (double)operandStack.Pop();
        }

        static bool IsOperator(string token)
        {
            return token == "+" || token == "-" || token == "*" || token == "/";
        }

        static double PerformOperation(string operation, double operand1, double operand2)
        {
            switch (operation)
            {
                case "+":
                    return operand1 + operand2;
                case "-":
                    return operand1 - operand2;
                case "*":
                    return operand1 * operand2;
                case "/":
                    if (operand2 == 0)
                        throw new DivideByZeroException("Division by 0");
                    return operand1 / operand2;
                default:
                    throw new ArgumentException("Unknown operation: " + operation);
            }
        }
    }

    class WordComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            return string.Compare((string)x, (string)y);
        }
    }

    class Program_2
    {
        public static void Main_Task3_2()
        {
            ArrayList properCaseWords = new ArrayList();
            ArrayList lowerCaseWords = new ArrayList();

            string file = "C:\\Users\\YANA\\Source\\Repos\\csharplab9-vshnvsk\\Lab9_10CharpT\\input.txt";

            string[] words = System.IO.File.ReadAllText(file).Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in words)
            {
                if (char.IsUpper(word[0]))
                    properCaseWords.Add(word);
                else
                    lowerCaseWords.Add(word);
            }

            properCaseWords.Sort(new WordComparer());
            lowerCaseWords.Sort(new WordComparer());

            Console.WriteLine("Words that start with a uppercase letter:");
            foreach (string word in properCaseWords)
            {
                Console.WriteLine(word);
            }

            Console.WriteLine("\nWords that start with a lowercase letter:");
            foreach (string word in lowerCaseWords)
            {
                Console.WriteLine(word);
            }
        }
    }
}
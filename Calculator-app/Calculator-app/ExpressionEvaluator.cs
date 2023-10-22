using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_app
{
  
    public static class ExpressionEvaluator
    {
        public static double Evaluate(string expression)
        {
            List<string> tokens = TokenizeExpression(expression);

            Stack<double> values = new Stack<double>();
            Stack<char> operators = new Stack<char>();

            foreach (string token in tokens)
            {
                if (double.TryParse(token, out double value))
                {
                    values.Push(value);
                }
                else if (IsOperator(token))
                {
                    while (operators.Count > 0 && IsHigherOrEqualPrecedence(operators.Peek(), token[0]))
                    {
                        double b = values.Pop();
                        double a = values.Pop();
                        char op = operators.Pop();
                        values.Push(DoOperation(a, b, op));
                    }
                    operators.Push(token[0]);
                }
            }

            while (operators.Count > 0)
            {
                double b = values.Pop();
                double a = values.Pop();
                char op = operators.Pop();
                values.Push(DoOperation(a, b, op));
            }

            return values.Pop();
        }

        private static List<string> TokenizeExpression(string expression)
        {
            List<string> tokens = new List<string>();
            string currentToken = "";

            foreach (char c in expression)
            {
                if (IsOperator(c.ToString()) || c == ' ')
                {
                    if (!string.IsNullOrEmpty(currentToken))
                    {
                        tokens.Add(currentToken);
                        currentToken = "";
                    }

                    if (c != ' ')
                    {
                        tokens.Add(c.ToString());
                    }
                }
                else
                {
                    currentToken += c;
                }
            }

            if (!string.IsNullOrEmpty(currentToken))
            {
                tokens.Add(currentToken);
            }

            return tokens;
        }

        private static bool IsOperator(string token)
        {
            return token == "+" || token == "-" || token == "*" || token == "/";
        }

        private static int GetPrecedence(char op)
        {
            if (op == '*' || op == '/')
            {
                return 2;
            }
            else if (op == '+' || op == '-')
            {
                return 1;
            }
            return 0; // Default precedence
        }

        private static bool IsHigherOrEqualPrecedence(char op1, char op2)
        {
            int precedence1 = GetPrecedence(op1);
            int precedence2 = GetPrecedence(op2);
            return precedence1 >= precedence2;
        }

        private static double DoOperation(double a, double b, char op)
        {
            if (op == '+') return a + b;
            if (op == '-') return a - b;
            if (op == '*') return a * b;
            if (op == '/')
            {
                if (b == 0)
                {
                    throw new DivideByZeroException("Division by zero is not allowed.");
                }
                return a / b;
            }
            throw new ArgumentException("Invalid operator: " + op);
        }
    }

}

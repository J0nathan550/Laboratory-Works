using NCalc; // library to help us calculate expression from almost zero by Sebastien Ros
using System.Text.RegularExpressions;

namespace Laboratory_Works__4___KDM_Functions_and_Numbers
{
    public static class FuncAndNum
    {

        /// <summary>
        /// Checks the parity of a number and returns "Even" or "Odd".
        /// </summary>
        public static string CheckParity(int number)
        {
            if (number % 2 == 0)
            {
                return "Even";
            }
            else
            {
                return "Odd";
            }
        }

        /// <summary>
        /// Checks the parity of a number and returns true for even, false for odd.
        /// </summary>
        public static bool CheckParityLogic(int number)
        {
            if (number % 2 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Checks if a number is prime.
        /// </summary>
        public static bool IsPrime(int number)
        {
            if (number <= 1)
            {
                return false;
            }
            for (int i = 2; i * i <= number; i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Calculates the greatest common divisor (GCD) of two integers.
        /// </summary>
        public static int CalculateGCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        /// <summary>
        /// Finds and prints the prime factors of a number.
        /// </summary>
        public static void FindPrimeFactors(int number)
        {
            Console.Write("Prime Factors: ");
            for (int i = 2; i <= number; i++)
            {
                int count = 0;
                while (number % i == 0)
                {
                    number /= i;
                    count++;
                }
                if (count > 0)
                {
                    Console.Write(i);
                    if (count > 1)
                    {
                        Console.Write($"^{count}");
                    }
                    if (number > 1)
                    {
                        Console.Write(" * ");
                    }
                }
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Calculates the least common multiple (LCM) of two integers.
        /// </summary>
        public static int CalculateLCM(int a, int b)
        {
            int gcd = CalculateGCD(a, b);
            return (a / gcd) * b;
        }

        /// <summary>
        /// Calculates Euler's Totient function for a positive integer n.
        /// </summary>
        public static int CalculateEulersTotient(int n)
        {
            int result = n;
            for (int p = 2; p * p <= n; p++)
            {
                if (n % p == 0)
                {
                    while (n % p == 0)
                    {
                        n /= p;
                    }
                    result -= result / p;
                }
            }
            if (n > 1)
            {
                result -= result / n;
            }
            return result;
        }

        /// <summary>
        /// Calculates the sum of the first n odd numbers.
        /// </summary>
        public static int SumOfOddNumbers(int n)
        {
            int counter = 0;
            int number = 1;
            int sum = 0;

            while (counter < n)
            {
                if (number % 2 == 1)
                {
                    counter += 1;
                    sum += number;
                }
                number += 1;
            }
            return sum;
        }

        /// <summary>
        /// Evaluates a mathematical expression with variable assignments.
        /// </summary>
        /// <param name="expression">The mathematical expression.</param>
        /// <param name="paramaters">Variable assignments in the format 'x = 3, y = 2'.</param>
        /// <returns>The result of the expression evaluation.</returns>
        public static object EvaluateFunction(string? expression, string? paramaters)
        {
            if (expression == null || paramaters == null)
            {
                Console.WriteLine("One of the data paramaters was null. Task is skipped.");
                return 0;
            }
            Dictionary<string, object>? varParams = ParseVariableAssignments(paramaters);

            if (varParams == null)
            {
                Console.WriteLine("You have problems with parsing parameters, please try again!");
                return 0;
            }

            try
            {
                expression = Regex.Replace(expression, @"(\w+)\s*\^\s*(\w+)", "Pow($1,$2)");
                expression = Regex.Replace(expression, @"(\d+)\s*(\w+)", "$1*$2");
                var exp = new Expression(expression);

                // Assign the variables to the expression
                exp.Parameters = varParams;
                // Evaluate the expression
                object result = exp.Evaluate();
                return result;
            }
            catch (EvaluationException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return 0;
        }

        /// <summary>
        /// Parses variable assignments from a string in the format 'x = 3, y = 2'.
        /// </summary>
        /// <param name="input">The input string with variable assignments.</param>
        /// <returns>A dictionary of variable assignments.</returns>
        private static Dictionary<string, object>? ParseVariableAssignments(string input)
        {
            Dictionary<string, object> variableAssignments = new();
            string[] assignments = input.Split(',');

            foreach (var assignment in assignments)
            {
                string[] parts = assignment.Trim().Split('=');

                if (parts.Length == 2)
                {
                    string variable = parts[0].Trim();
                    if (!int.TryParse(parts[1].Trim(), out int value))
                    {
                        Console.WriteLine($"Invalid value for {variable}. Value must be an integer.");
                        return null;
                    }

                    variableAssignments[variable] = value;
                }
                else
                {
                    Console.WriteLine("Invalid assignment format. Use 'variable = value'.");
                    return null;
                }
            }

            return variableAssignments;
        }
    }
}
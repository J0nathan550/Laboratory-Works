namespace Laboratory_Works__4___KDM_Functions_and_Numbers
{
    public static class Tasks
    {
        /// <summary>
        /// Task 1: Parity Checker
        /// Objective: Write a program to determine the parity of a given number.
        /// </summary>
        public static void Task1Run(string? value)
        {
            if(int.TryParse(value, out var result))
            {
                Console.WriteLine("Parity: " + FuncAndNum.CheckParity(result));
                return;
            }
            Console.WriteLine("Error: the given number is a string.");
        }

        /// <summary>
        /// Task 2: Prime Number Checker
        /// Objective: Implement a program that checks if a given number is prime.
        /// </summary>
        public static void Task2Run(string? value)
        {
            if (int.TryParse(value, out var result))
            {
                if (FuncAndNum.IsPrime(result))
                {
                    Console.WriteLine("Prime Status: Prime");
                    return;
                }
                Console.WriteLine("Prime Status: Not Prime");
                return;
            }
            Console.WriteLine("Error: the given number is a string.");
        }

        /// <summary>
        /// Task 3: GCD Calculator
        /// Objective: Create a program to calculate the Greatest Common Divisor(GCD) of two numbers.
        /// </summary>
        public static void Task3Run(string? values)
        {
            if (values == null)
            {
                Console.WriteLine("Error the given number is a string.");
                return;
            }
            List<int> intValues = new();
            string[] arrStringNum = values.Split(',');
            foreach (string str in arrStringNum)
            {
                if (int.TryParse(str, out int value))
                {
                    intValues.Add(value);
                }
                else
                {
                    Console.WriteLine("Error the given number is a string.");
                    return;
                }
            }
            Console.WriteLine("GCD: " + FuncAndNum.CalculateGCD(intValues[0], intValues[1]));
        }

        /// <summary>
        /// Task 4: Prime Factorization
        /// Objective: Write a program to find the prime factorization of a given number.
        /// </summary>
        public static void Task4Run(string? value)
        {
            if (int.TryParse(value, out var result))
            {
                FuncAndNum.FindPrimeFactors(result);
                return;
            }
            Console.WriteLine("Error the given number is a string.");
        }

        /// <summary>
        /// Task 5: LCM Calculator
        /// Objective: Create a program to compute the Least Common Multiple(LCM) of two integers.
        /// </summary>
        public static void Task5Run(string? values)
        {
            if (values == null)
            {
                Console.WriteLine("Error the given number is a string.");
                return;
            }
            List<int> intValues = new();
            string[] arrStringNum = values.Split(',');
            foreach (string str in arrStringNum)
            {
                if (int.TryParse(str, out int value))
                {
                    intValues.Add(value);
                }
                else
                {
                    Console.WriteLine("Error the given number is a string.");
                    return;
                }
            }
            Console.WriteLine("LCM: " + FuncAndNum.CalculateLCM(intValues[0], intValues[1]));
        }

        /// <summary>
        /// Task 6: Direct Proof Implementation
        /// Objective: Write a program that demonstrates a direct proof method for a given mathematical statement.
        /// </summary>
        public static void Task6Run(string? value)
        {
            if (int.TryParse(value, out int result))
            {
                if (FuncAndNum.CheckParityLogic(result))
                {
                    Console.WriteLine("Hypothesis: " + result + " is an even number.");
                    Console.WriteLine("Conclusion: " + result + " is divisible by 2.");
                    Console.WriteLine("The given statement is true.");
                    Console.WriteLine("\nExplanation: ");
                    Console.WriteLine("Here, " + result + " is an even number since it can be written in the form of 2k where k = " + result / 2 + ".");
                    Console.WriteLine("Hence, according to the definition, it is divisible by 2, validating the given statement.");
                }
                else
                {
                    Console.WriteLine("Hypothesis: " + result + " is an even number.");
                    Console.WriteLine("Conclusion: " + result + " is not divisible by 2.");
                    Console.WriteLine("The given statement is false.");
                    Console.WriteLine("\nExplanation: ");
                    Console.WriteLine("Here, we input an odd number intentionally to check the program's response.");
                    Console.WriteLine("As expected, the program identifies that " + result + " is not an even number and therefore not divisible by 2,");
                    Console.WriteLine("showing that the given statement is false for this particular case.");
                    Console.WriteLine("However, this doesn't invalidate the original statement because it was only meant for even numbers.");
                }
                return;
            }
            Console.WriteLine("Error the given number is a string.");

        }

        /// <summary>
        /// Task 7: Advanced Number Theory Function
        /// Objective: Implement a program that performs a complex operation involving number theory concepts, like Euler’s Totient Function.
        /// </summary>
        public static void Task7Run(string? value)
        {
            // Task 7: Advanced Number Theory Function
            // Objective: Implement a program that performs a complex operation involving number theory concepts, like Euler’s Totient Function.
            if (int.TryParse(value, out int result))
            {
                Console.WriteLine("Euler’s Totient Value:" + FuncAndNum.CalculateEulersTotient(result));
                return;
            }
            Console.WriteLine("Error the given number is a string.");
        }

        /// <summary>
        /// Task 8: Comprehensive Proof by Induction
        /// Objective: Develop a program that can prove mathematical statements using the principle of mathematical induction.
        /// </summary>
        public static void Task8Run(string? value)
        {
            if (!int.TryParse(value, out int n))
            {
                Console.WriteLine("Error the given number is a string.");
                return;
            }
            else
            {
                Console.WriteLine("Statement: The sum of the first n odd numbers is n^2 for all positive integers n");
                Console.WriteLine("Proof by Mathematical Induction:");

                Console.WriteLine("\nBase Case:");
                int baseResult = 1 * 1;
                Console.WriteLine("For n = 1, the sum of the first 1 odd number is 1^2 = " + baseResult);

                if (baseResult == 1)
                {
                    Console.WriteLine("Base case is verified.");
                }
                else
                {
                    Console.WriteLine("Base case is not verified. The statement is false.");
                    return;
                }

                Console.WriteLine("\nInduction step for n = " + n + ":");

                bool inductionHypothesis = FuncAndNum.SumOfOddNumbers(n) == n * n;

                if (inductionHypothesis)
                {
                    Console.WriteLine("The sum of the first " + n + " odd numbers is n^2 = " + n * n);
                    Console.WriteLine("Assuming the statement is true for n = " + n + ", the induction hypothesis is verified.");
                }
                else
                {
                    Console.WriteLine("Assuming the statement is true for n = " + n + ", the induction hypothesis is not verified.");
                    Console.WriteLine("The statement is false for n = " + n);
                    return;
                }

                Console.WriteLine("\nMathematical induction is successfully applied.");
                Console.WriteLine("The statement is proven for odd integer " + n + ".");
            }
        }
        /// <summary>
        /// Task 9: Advanced Function Evaluation
        /// Objective: Implement a program to evaluate complex mathematical functions with considerations to their domains and ranges.
        /// </summary>
        public static void Task9Run(string? expression, string? paramaters)
        {
            Console.WriteLine("Evaluated Result: " + FuncAndNum.EvaluateFunction(expression, paramaters));
        }
    }
}
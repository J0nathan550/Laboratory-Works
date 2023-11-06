namespace Laboratory_Works__4___KDM_Functions_and_Numbers
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Console.Write("Write a number to check parity (Task 1): ");
            Tasks.Task1Run(Console.ReadLine());
            Console.WriteLine();

            Console.Write("Write a number to check if given number is prime (Task 2): ");
            Tasks.Task2Run(Console.ReadLine());
            Console.WriteLine();

            Console.Write("Write numbers seperated by commas to calculate GCD (Task 3): ");
            Tasks.Task3Run(Console.ReadLine());
            Console.WriteLine();

            Console.Write("Write a number to factorize prime with (Task 4): ");
            Tasks.Task4Run(Console.ReadLine());
            Console.WriteLine();

            Console.Write("Write numbers seperated by commas to calculate LCM (Task 5): ");
            Tasks.Task5Run(Console.ReadLine());
            Console.WriteLine();

            Console.Write("Write a number to check Direct Proof Implementation (Task 6): ");
            Tasks.Task6Run(Console.ReadLine());
            Console.WriteLine();

            Console.Write("Write a number to calculate using Euler Toient Function (Task 7): ");
            Tasks.Task7Run(Console.ReadLine());
            Console.WriteLine();

            Console.Write("Write a number to check Comprehensive Proof by Induction (Task 8): ");
            Tasks.Task8Run(Console.ReadLine());
            Console.WriteLine();

            Console.Write("Write an expression (Task 9): ");
            string? expression = Console.ReadLine();
            Console.Write("Write paramaters, to define paramater you need to do following: x = 3 (that's one variable) for more, x = 3, y = 2 ... (Task 9): ");
            string? paramaters = Console.ReadLine();
            Tasks.Task9Run(expression, paramaters);
        }
    }
}
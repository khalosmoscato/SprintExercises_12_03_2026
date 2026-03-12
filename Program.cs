using System.Security.Cryptography.X509Certificates;

namespace SprintExercise_12_03_2026;

class Program
{
    public static void Main()
    {
        Task00.Run();
        Task01.MultiplyInt(((int)2.2), ((int)4.9m));
        Console.WriteLine(Task01.MultiplyInt(((int)2.2), ((int)4.9m)));
    }

    public static void Divide(out double result)
    {
        // check the `Task01` class file to see another potential Divide method
        double num1 = 0;
        decimal num2 = 0;
        // I am defualting result because in the method signature I am promising to return a result (of type double)
        result = 0;
        // creating a while loop I check if the user input is valid, if not valid, displays an error message and restarts the loop until we have a valid input to use:
        while (true)
        {
            Console.WriteLine("Enter an integer");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int numTyped))
            {
                num1 = numTyped;
                break; // while loop only exits when it hits the `break`
            }
            else
            {
                Console.WriteLine("Invalid input.");
                // loop will restart, there is no break here
            }
        }
        
        while(true)
        {
            Console.WriteLine("Enter a decimal (0 is not accepted)");
            string input2 = Console.ReadLine();
            if ((decimal.TryParse(input2, out decimal numTyped2)) && numTyped2 != 0)
            {
                num2 = numTyped2;
                break;
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }
        result = num1 / (double)num2;
        Console.WriteLine(result);
    }
}
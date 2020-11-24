using System;
namespace Console_Calculator
{
    class Calculator
    {
        public static double DoOperation(double num1, double num2, string op)
        {
            double result = double.NaN; // Default value is "not-a-number" which we use if an operation, such as division, could result in an error.
            // Use a switch statement to do the math.
            switch (op)
            {
                case "a":
                    result = num1 + num2;
                    break;
                case "s":
                    result = num1 - num2;
                    break;
                case "m":
                    result = num1 * num2;
                    break;
                case "d":
                    // Ask the user to enter a non-zero divisor.
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    break;
                // Return text for an incorrect option entry.
                default:
                    break;
            }
            return result;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;
            // Display title as the C# console calculator app.
            Console.WriteLine("Console Calculator in C#\r");
            Console.WriteLine("------------------------\n");
            while (!endApp)
                {
                // Declare Vars and set to empty.
                string numInput1 = "";
                string numInput2 = "";
                double result = 0;
                Console.WriteLine("Type a number, and then press Enter");
                numInput1 = Console.ReadLine();
                double cleanNum1 = 0;
                while (!double.TryParse(numInput1, out cleanNum1))
                {
                    Console.Write("Uhh uhh, this isn't a valid number. Try using an  interger");
                    numInput1 = Console.ReadLine();
                }
                Console.WriteLine("Type another number, and then press Enter: ");
                numInput2 = Console.ReadLine();
                double cleanNum2 = 0;
                while (!double.TryParse(numInput2, out cleanNum2))
                {
                    Console.Write("Uhh uhh, this isn't a valid number. Try using an  interger");
                    numInput1 = Console.ReadLine();
                }
                // User operators, you much choose one
                Console.WriteLine("Choose an operator from the following list: ");
                Console.WriteLine("\ta - Add");
                Console.WriteLine("\ts - Subtract");
                Console.WriteLine("\tm - Multipy");
                Console.WriteLine("\td - divide");
                Console.WriteLine("Your option? ");
                string op = Console.ReadLine();
                try
                {
                    result = Calculator.DoOperation(cleanNum1, cleanNum2, op);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("This result will return in an error. \n");
                    }
                    else Console.WriteLine("Your result: {0:0.##}\n", result);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Uh-oh, an error occured" + e.Message);
                }
                Console.WriteLine("------------------------\n");
                // Waiting for the user to respond before closing.
                Console.WriteLine("Press 'n' and Enter to close the app, or press another key and Enter to continue: ");
                if (Console.ReadLine() == "n") endApp = true;
                Console.WriteLine("\n");
            }
            return;
            }
        }
    }

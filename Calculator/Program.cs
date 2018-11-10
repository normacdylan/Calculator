using System;

namespace Calculator
{

    class Calculator 
    {
        public int FirstNumber { get; set;}
        public int SecondNumber { get; set;}
        public int NumberInMemory { get; set;}

        public Calculator() 
        {
        }

        public override string ToString()
        {
            return "First Number: " + FirstNumber + "\n"
                + "Second Number: " + SecondNumber + "\n"
                + "Number In Memory: " + NumberInMemory;
        }

        public int SumNumbers()
        {
            return FirstNumber + SecondNumber;
        }

        public int MultiplyNumbers()
        {
            return FirstNumber * SecondNumber;
        }

        public int SumInBetween()
        {
            int sum = 0;
            for (int i = FirstNumber; i < SecondNumber + 1; i++) 
            {
                sum += i;
            }
            return sum;
        }


    }

    class Program
    {
        static string[] options = {"Add two numbers", "Multiply two numbers",
            "Sum the numbers between two numbers", "Add number to memory", 
            "Clear memory", "Print calculator contents", "Quit"};

        public static void PrintMenu() 
        {
            for (int i = 0; i < options.Length; i++) 
            {
                Console.WriteLine((i + 1).ToString() + ". " + options[i]);
            }
        }

        public static int TryInput()
        {
            bool invalid = true;
            int result = 0;
            while (invalid)
            {
                string input = Console.ReadLine();
                try 
                {
                    result = Convert.ToInt32(input);
                    invalid = false;
                } catch 
                {
                    Console.WriteLine("Invalid input. Must be a number. Try again");
                } 
            }
            return result;
        }

        public static int[] AskForNumbers(int length)
        {
            int[] numbers = new int[length];
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine("Pick a number");
                numbers[i] = TryInput();
            }
            return numbers;
        }

        public static bool PerformCalcAction(Calculator calc, int choice)
        {
            bool keepRunning = true;
            switch (choice)
            {
                case 1:
                    int[] numbers = AskForNumbers(2);
                    calc.FirstNumber = numbers[0];
                    calc.SecondNumber = numbers[1];
                    Console.WriteLine("The sum is " + calc.SumNumbers());

                    break;
                case 2:
                    int[] chosenNumbers = AskForNumbers(2);
                    calc.FirstNumber = chosenNumbers[0];
                    calc.SecondNumber = chosenNumbers[1];
                    Console.WriteLine("The product is " + calc.MultiplyNumbers());
                    break;
                case 3:
                    int[] pickedNumbers = AskForNumbers(2);
                    calc.FirstNumber = pickedNumbers[0];
                    calc.SecondNumber = pickedNumbers[1];
                    Console.WriteLine("The in between sum is " + calc.SumInBetween());
                    break;
                case 4:
                    int number = AskForNumbers(1)[0];
                    calc.NumberInMemory = number;
                    Console.WriteLine("Number successfully added to memory");
                    break;
                case 5:
                    calc.NumberInMemory = 0;
                    Console.WriteLine("Number in memory cleared");
                    break;
                case 6:
                    Console.WriteLine(calc.ToString());
                    break;
                case 7:
                    Console.WriteLine("Goodbye!");
                    keepRunning = false;
                    break;
                default:
                    Console.WriteLine("That is not a valid action");
                    break;
            }
            return keepRunning;
        }

        public static void Main(string[] args)
        {
            Calculator calc = new Calculator();
            bool running = true;

            while (running) 
            {
                PrintMenu();
                int choice = TryInput();
                running = PerformCalcAction(calc, choice);
            }

        }
    }
}

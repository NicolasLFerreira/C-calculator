using System;
using System.Diagnostics;
using System.Linq.Expressions;

namespace CSharp_Test_Field
{
    class Program
    {
        static void Main(string[] args)
        {

            //Intro

            Console.WriteLine($"Welcome to the \"C# Console Calculator\"" +
                              $"\nTo get started, simply write down an operation following these structures: " +
                              $"\n'xxx.xxx.xxx.xxx'" +
                              $"\nWhere 'x' is a number, and '.' is an operator, which can be either:" +
                              $"\n-> + (Summation)" +
                              $"\n-> - (Subtraction)" +
                              $"\n-> * (Multiplication)" +
                              $"\n-> / (Division)" +
                              $"\n-> ^x (Power and exponent, 1 - 9)" +
                              $"\nOther letters or symbols will be ignored, and listed if the user wishes so.");
            System.Threading.Thread.Sleep(1000);

            //Calling for input

            Console.Write("\nEnter the operation you want to complete: ");
            string equation = Console.ReadLine(); // Input

            Console.Write("\nShow ignored? Y/N: ");
            char yesNo = Console.ReadKey().KeyChar;
            bool show = false;

            Console.WriteLine();

            if (yesNo == 'y')
            {
                show = true;
            }

            Console.WriteLine($"\nResult: {Calculator.Calculate(equation, show)}");
        }
    }

    class Calculator
    {
        public static double Calculate(string equation, bool showIgnored)
        {
            double checkNumber; // Used to check if "equation[i]" equals a number

            // Arrays to store and get the values of numbers or operators

            string[] numbers = new string[equation.Length];
            char[] operands = new char[equation.Length];

            // Indexers will be used to access specific value of the arrays

            int indexNumber = 0;
            int indexOperand = 0;

            //Ignored items

            string ignored = string.Empty;

            // Variable to store the result

            double result = 0;

            for (int i = 0; i < equation.Length; i++) // Reading and splitting up the equation
            {

                // Getting the numbers. Will get algarism per algarism, but they will be put together in a string, then converted to an integer

                if (double.TryParse(equation[i].ToString(), out checkNumber))
                {
                    numbers[indexNumber] += equation[i];
                }

                // Getting the operators. Will be used later to identify which operation has to be done

                else if (equation[i] == '-' || equation[i] == '+' || equation[i] == '*' || equation[i] == '/' || equation[i] == '^')
                {
                    operands[indexOperand++] = equation[i];

                    if (equation[i] == '^')
                    {
                        i++;
                        operands[indexOperand++] = equation[i];
                    }

                    indexNumber++; //Start new number after operator
                }

                //If the current item is neither number or operator, it will be ignored and printed

                else
                {
                    if (showIgnored)
                    {
                        if (equation[i] == ' ')
                        {
                            ignored += "BLANK" + " - ";
                            continue;
                        }
                        ignored += equation[i] + " - ";
                    }
                }
            }

            if (showIgnored) Console.WriteLine(ignored);

            //Variable result, gets the first number and start working with it

            result = Convert.ToDouble(numbers[0]);

            //Actual calculation now
            // 'i' for numbers, 'j' for operators

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i]);
                if (i < numbers.Length)
                    Console.Write(operands[i]);
            }

            for (int i = 0, j = 1; j < numbers.Length && i < operands.Length; i++, j++)
            {
                switch (operands[i])
                {
                    case '+':
                        result += Convert.ToDouble(numbers[j]);
                        break;
                    case '-':
                        result -= Convert.ToDouble(numbers[j]);
                        break;
                    case '*':
                        result *= Convert.ToDouble(numbers[j]);
                        break;
                    case '/':
                        result /= Convert.ToDouble(numbers[j]);
                        break;
                    case '^':
                        result = Math.Pow(result, Convert.ToDouble(operands[1 + i++].ToString()));
                        break;
                    default:
                        break;
                }
            }

            return result;
        }
    }
}
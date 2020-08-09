using System;

namespace CSharp_Test_Field
{
    class Program
    {
        static void Main(string[] args)
        {
            string equation = Console.ReadLine(); // Input
            Console.WriteLine(Calculator.Calculate(equation));
        }
    }

    class Calculator
    {
        public static double Calculate(string equation)
        {
            int integer;

            // Arrays to store and get the values of numbers or operators

            string[] numbers = new string[equation.Length];
            char[] operands = new char[equation.Length];

            // Indexers will be used to access specific value of the arrays

            int indexNumber = 0;
            int indexOperand = 0;

            // Variable to store the result

            double result = 0;

            // Reading and splitting up the equation

            for (int i = 0; i < equation.Length; i++)
            {

                // Getting the numbers. Will get algarism per algarism, but they will be put together in a string, then converted to an integer

                if (int.TryParse(equation[i].ToString(), out integer))
                {
                    numbers[indexNumber] += equation[i];
                }

                // Getting the operators. Will be used later to identify which operation has to be done

                else if (equation[i] == '-' || equation[i] == '+' || equation[i] == '*' || equation[i] == '/')
                {
                    operands[indexOperand++] = equation[i];

                    //If the current item is an operator, the number array will start storing a new number

                    indexNumber++;
                }

                //If the current item is neither number or operator, it will be ignored and printed

                else
                {
                    Console.WriteLine($"Ignored: {equation[i]}");
                }
            }

            //Variable result, gets the first number and start working with it

            result = Convert.ToInt32(numbers[0]);

            // 'i' for numbers, 'j' for operators

            for (int j = 0, i = 1; i < numbers.Length && j < operands.Length; i++, j++)
            {
                switch (operands[j])
                {
                    case '+':
                        result += Convert.ToInt32(numbers[i]);
                        break;
                    case '-':
                        result -= Convert.ToInt32(numbers[i]);
                        break;
                    case '*':
                        result *= Convert.ToInt32(numbers[i]);
                        break;
                    case '/':
                        result /= Convert.ToInt32(numbers[i]);
                        break;
                    default:
                        break;
                }
            }

            return result;
        }
    }
}
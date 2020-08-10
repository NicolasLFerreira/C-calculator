using System;
using System.Diagnostics;
using System.Linq.Expressions;

namespace  CSharp_Calculator.Code
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
}
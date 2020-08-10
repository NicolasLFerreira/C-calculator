using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace CSharp_Calculator.Code
{
    class Utilities
    {
        // Capture integer input
        public static int IntInput()
        {
            string input = Console.ReadLine();
            int output;

            while (!int.TryParse(input, out output))
            {

                Console.Write("\nPlease enter an integer: ");
                input = Console.ReadLine();
            }
            return output;
        }

        // Capture char input
        public static char CharInput()
        {
            return Console.ReadKey().KeyChar;
        }
    }
}

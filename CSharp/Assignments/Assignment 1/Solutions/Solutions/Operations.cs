using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions
{
    class Operations
    {
        public static void Main()
        {
            Console.WriteLine("Enter First number :");
            int num1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Second number :");
            int num2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Input Operation");
            string operand = Console.ReadLine();
            Console.WriteLine();
            int result = 0;

            switch (operand)
            {
                case "+":
                    result = num1 + num2;
                    break;
                case "-":
                    result = num1 - num2;
                    break;
                case "*":
                    result = num1 * num2;
                    break;
                case "/":
                    if (num2 != 0)
                        result = num1 / num2;
                    else
                    {
                        Console.WriteLine("Can't be divided by zero");
                    }
                    break;
                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
            Console.WriteLine("{0} {1} {2} = {3}", num1, operand, num2, result);
            Console.ReadLine();
        }
    }
}

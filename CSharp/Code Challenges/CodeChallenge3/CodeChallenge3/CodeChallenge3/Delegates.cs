using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Write a program that uses delegate object as an argument to call Calculator Functionalities like 
// 1. Addition, 2. Subtraction and 3. Multiplication
//   by taking 2 integers and returning the output to the user.
//  You should display all the return values accordingly.

namespace CodeChallenge3
{
     
        public delegate int CalculatorDelegate(int a, int b);
        public static class Calculator
        {
           public static int Add(int a, int b)
            {
              return a + b;
            }

           public static int Subtract(int a, int b)
            {
              return a - b;
            }

           public static int Multiply(int a, int b)
           {
              return a * b;
           }

    }

    class Delegates
        {
        public static void PerformOperation(CalculatorDelegate operation, int x, int y, string operationName)
        {
            int result = operation(x, y);
            Console.WriteLine($"{operationName} of {x} and {y} is: {result}");
        }

        static void Main(string[] args)
            {

            //CalculatorDelegate add = new CalculatorDelegate(Calculator.Add);
            //CalculatorDelegate subtract = new CalculatorDelegate(Calculator.Subtract);
            //CalculatorDelegate multiply = new CalculatorDelegate(Calculator.Multiply);

            bool exit = false;

                while (!exit)
                {
                    Console.WriteLine("\n--- Calculator Menu ---");
                    Console.WriteLine("1. Addition");
                    Console.WriteLine("2. Subtraction");
                    Console.WriteLine("3. Multiplication");
                    Console.WriteLine("4. Exit");
                    Console.Write("Choose an option (1-4): ");
                    string choice = Console.ReadLine();

                    if (choice == "4")
                    {
                        exit = true;
                        Console.WriteLine("Exiting program.....");
                        break;
                    }

                    Console.Write("Enter first number: ");
                    int num1 = int.Parse(Console.ReadLine());

                    Console.Write("Enter second number: ");
                    int num2 = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case "1":
                        PerformOperation(Calculator.Add, num1, num2, "Addition");
                          // add(num1, num2);
                            break;
                        case "2":
                        PerformOperation(Calculator.Subtract, num1, num2, "Subtraction");
                        //subtract(num1, num2);
                            break;
                        case "3":
                          PerformOperation(Calculator.Multiply, num1, num2, "Multiplication");
                        //multiply(num1, num2);
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please select a valid option.");
                            break;
                    }
                }

                Console.ReadKey();
            }
        }
    }

    
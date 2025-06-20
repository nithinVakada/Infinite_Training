using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2_
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter 1st number :");
            int num1 =int.Parse( Console.ReadLine());

            Console.WriteLine("Enter 2nd number :");
            int num2 = int.Parse(Console.ReadLine());
            
            Swap(num1,num2);
        }

        static void Swap(int num1,int num2)
        {
            Console.WriteLine("Before Swapping :");
            Console.WriteLine("num1 = " + num1 + " num2 = " + num2);
            Console.WriteLine();

            num1 = num1 + num2;       //5=2+3
            num2 = num1 - num2;      //num2 =5-3
            num1 = num1 - num2;      //num1=5-2

            Console.WriteLine("After Swapping :");
            Console.WriteLine("num1 = " + num1 + " num2 = " + num2);
            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Program to find largest among three numbers
namespace CC1
{
    class LargestOfThreeNumbers
    {
        static void Main(string[] args)
        {
            int num1, num2, num3;
            Console.WriteLine("Enter num 1: ");
            num1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter num 2: ");
            num2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter num 3: ");
            num3 = int.Parse(Console.ReadLine());

            int largest;
            if(num1>num2)
            {
                if (num1 > num3)
                    largest = num1;
                else
                    largest = num3;
            }
            else
            {
                if (num2 > num3)
                    largest = num2;
                else
                    largest = num3;
            }
            Console.WriteLine("The largest number is " + largest);
            Console.Read();
        }
    }
}

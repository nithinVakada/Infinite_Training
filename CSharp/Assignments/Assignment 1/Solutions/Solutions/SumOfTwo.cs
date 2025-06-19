using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions
{
    class SumOfTwo
    {
        public static void Main()
        {
            Console.WriteLine("Enter 1st number :");
            int num1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter 2nd number :");
            int num2 = int.Parse(Console.ReadLine());
            int result = num1 + num2;
            if (num1 == num2)
                result += num1;
            Console.WriteLine("Result = {0}", result);
        }
    }
}

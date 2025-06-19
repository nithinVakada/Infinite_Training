using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions
{
    class EqualOrNot
    {
        static void Main(string[] args)
        {
            int num1, num2;
            Console.WriteLine("Enter num1: ");
            num1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter num2: ");
            num2 = int.Parse(Console.ReadLine());

            if (num1 == num2)
                Console.WriteLine("{0} and {1} are equal", num1, num2);
            else
                Console.WriteLine("{0} and {1} are not equal", num1, num2);
            Console.Read();
        }
    }

}

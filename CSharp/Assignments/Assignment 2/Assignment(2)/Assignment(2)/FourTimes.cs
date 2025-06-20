using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Program to print a number 4 times in a row with and without spaces
namespace Assignment_2_
{
    class FourTimes
    {
        static void Main()
        {
            Console.WriteLine("Enter a digit");
            int num1 = int.Parse(Console.ReadLine());

            for(int i=0;i<2;i++)
            {
                Console.WriteLine("{0} {0} {0} {0}", num1);
                Console.WriteLine("{0}{0}{0}{0}", num1);
            }
            Console.ReadLine();

        }
    }
}

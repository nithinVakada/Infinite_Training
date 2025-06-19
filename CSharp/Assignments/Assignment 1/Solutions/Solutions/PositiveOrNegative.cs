using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions
{
    class PositiveOrNegative
    {
        static void Main()
        {
            Console.WriteLine("Enter a Number: ");
            int num = int.Parse(Console.ReadLine());
            string result = (num >= 0) ? "positive" : "negative";
            Console.WriteLine("{0} is {1} number", num, result);
            Console.ReadLine();
        }
    }
}

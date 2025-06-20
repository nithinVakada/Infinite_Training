using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Program to print reverse of the string
namespace Assignment_2_
{
    class String2
    {
        static void Main()
        {
            Console.WriteLine("Enter String");
            string s = Console.ReadLine();
            Console.WriteLine("Reverse of the string " + s + " is " + new string(s.Reverse().ToArray()));
            Console.ReadLine();
        }
    }
}

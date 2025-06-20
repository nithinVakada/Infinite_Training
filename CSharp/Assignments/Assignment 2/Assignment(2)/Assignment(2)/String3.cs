using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Program to check whether both the strings same or not
namespace Assignment_2_
{
    class String3
    {
        static void Main()
        {
            string s1, s2;
            Console.WriteLine("Enter string 1:");
            s1 =( Console.ReadLine());
            s1 = s1.ToUpper();
            Console.WriteLine("Enter string 2:");
            s2 = (Console.ReadLine());
            s2 = s2.ToUpper();

            //Converted both the strings into Uppercase,
            //otherwise it would display Both are not same for the strings NITHIN and Nithin

            bool result = SameOrNot(s1, s2);
            
            if (result)
                Console.WriteLine("Both the strings are same");
            else
                Console.WriteLine("Both the strings are not same");

            Console.ReadLine();
        }
        static bool SameOrNot(string s1, string s2)
        {
            bool result = true;
            int i = 0, j = 0;
            while (i < s1.Length && j < s2.Length)
            {
                if (s1[i] != s2[i])
                {
                    result = false;
                    break;
                }
                i += 1;
                j += 1;
            }
            return result;
        }
    }
}

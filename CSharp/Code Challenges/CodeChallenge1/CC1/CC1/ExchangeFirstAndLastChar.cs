using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//c# Program to swap first and last characters of a string

namespace CC1
{
    class ExchangeFirstAndLastChar
    {
        static void Main(string[] args)
        {
            string str;
            Console.WriteLine("Enter the string");
            str = Console.ReadLine();
            int size = str.Length;
            char first_char = str[0];
            char last_char = str[size-1];
            string resultant = str;
            if(size>2)
            {
                 resultant = last_char + str.Substring(1, size - 2) + first_char;
            }
            
            Console.WriteLine("After Swapping first and last char : " +resultant);
            Console.ReadLine();
        }
    }
}

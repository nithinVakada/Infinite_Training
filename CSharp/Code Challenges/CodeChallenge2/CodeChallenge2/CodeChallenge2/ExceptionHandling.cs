using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Writing a C# program to implement a method
//that takes an integer as input and
//throws an exception if the number is negative. Handle the exception in the calling code.
namespace CodeChallenge2
{
    class ExceptionHandling
    {
        static void Verify(int number)
        {
            if(number>=0)
            {
                Console.WriteLine("The number is valid..");
            }
            else
            {
                throw new ArgumentException("The number should be non-negative..");
            }
        }
        static void Main()
        {
            int number;
            Console.WriteLine("Enter a number");
            try
            {
                number = int.Parse(Console.ReadLine());
                Verify(number);

            }
            catch(ArgumentException Ax)
            {
                Console.WriteLine(Ax.Message);
            }
            catch(FormatException Fe)
            {
                Console.WriteLine(Fe.Message);
            }
            Console.Read();
        }
    }
}

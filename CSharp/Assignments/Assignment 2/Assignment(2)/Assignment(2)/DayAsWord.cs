using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Program to print Day as a word according to  day's number
namespace Assignment_2_
{
    class DayAsWord
    {
        enum Days { Monday = 1, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday };
        static void Main()
        {
            
            Console.WriteLine("Enter Day number");
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine(Enum.GetName(typeof(Days), num));
            Console.ReadLine();
        }
    }
}

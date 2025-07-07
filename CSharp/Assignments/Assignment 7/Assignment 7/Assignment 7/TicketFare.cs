using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelConcessionLib;

namespace Assignment_7
{
    class TicketFare
    {

        const double TotalFare = 500.0;

        static void Main()
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            Console.Write("Enter your age: ");
            int age = int.Parse(Console.ReadLine());

            ConcessionCalculator calculator = new ConcessionCalculator();
            string result = calculator.CalculateConcession(age, TotalFare);

            Console.WriteLine($"\nHello {name}, {result}");
            Console.ReadKey();

        }
    }
}

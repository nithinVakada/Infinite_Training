using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a query that returns list of numbers and their squares only if square is greater than 20 

//Example input [7, 2, 30]
//Expected output
//→ 7 - 49, 30 - 900

namespace Assignment_7
{
    

    class Program
    {
        static void Main()
        {
            List<int> list = new List<int>();

            Console.Write("Enter the size of list : ");
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                Console.Write($"Enter number {i + 1}: ");
                int num = int.Parse(Console.ReadLine());
                list.Add(num);
            }
            
            List<int> result = list.FindAll(n => (n * n) > 20);

            Console.WriteLine("\nFiltered numbers and their squares:");
            foreach (int number in result)
            {
                Console.WriteLine($"{number} - {number * number}");
            }
            Console.ReadKey();
        }
    }

}

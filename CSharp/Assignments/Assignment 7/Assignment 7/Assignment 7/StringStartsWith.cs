using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a query that returns words starting with letter 'a' and ending with letter 'm'.


//Expected input and output
//"mum", "amsterdam", "bloom" → "amsterdam"

namespace Assignment_7
{


    class StringStartsWith
    {
        static void Main()
        {
            List<string> list = new List<string>();

            Console.Write("No. of words :  ");
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                Console.Write($"Enter word {i + 1}: ");
                string word = Console.ReadLine();
                list.Add(word);
            }
            
            List<string> result = list.FindAll(s => s.StartsWith("a") && s.EndsWith("m"));

            Console.WriteLine("\nFiltered words:");
            foreach (string word in result)
            {
                Console.WriteLine(word);
            }
            Console.ReadKey();
        }
    }

}

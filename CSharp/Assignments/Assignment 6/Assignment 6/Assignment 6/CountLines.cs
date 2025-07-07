using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment_6
{
    class CountLines
    {
        static void Main()
        {
            
            string filePath = @"C:\Users\nithinkumarv\Desktop\Practice\Practice\output.txt";

            try
            {
                
                int lineCount = File.ReadAllLines(filePath).Length;

                Console.WriteLine($"The file '{filePath}' contains {lineCount} lines.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading the file: " + ex.Message);
            }
            Console.ReadKey();
        }
    }
}


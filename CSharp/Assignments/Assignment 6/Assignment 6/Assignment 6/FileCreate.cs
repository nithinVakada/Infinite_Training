using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment_6
{
    class FileCreate
    {
        static void Main()
        {

            string filePath = @"C:\Users\nithinkumarv\Desktop\Practice\Practice\output.txt";

            
            string[] lines = {
                   "line 1",
                   "line 2",
                   "line 3",
                   "line 4",
                   "line 5"
                 };


            try
            {
                // Write all lines to the file
                File.WriteAllLines(filePath, lines);
                Console.WriteLine($"File '{filePath}' created and data written successfully.");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error writing to file: " + ex.Message);
            }
            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

//Write a program in C# Sharp to append some text to an existing file. 
//If file is not available, then create one in the same workspace.
//Hint: (Use the appropriate mode of operation. Use stream writer class)
namespace CodeChallenge3
{
    class AppendText
    {
       
        static void Main(string[] args)
        {
            string filePath = "CC4.txt";
            // The file will be located at
            // InfiniteTraining\CSharp\Code Challenges\CodeChallenge3\CodeChallenge3\CodeChallenge3\bin\Debug
            Console.WriteLine("Enter text to append to the file:");
            string userInput = Console.ReadLine();

            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("File does not exist. Creating a new file...");
                }
                else
                {
                    Console.WriteLine("File found. Appending to existing file...");
                }

                using (StreamWriter sw = new StreamWriter(filePath, true))
                {
                    sw.WriteLine(userInput);
                }

                Console.WriteLine("Operation completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.ReadKey();
        
    }

}
}

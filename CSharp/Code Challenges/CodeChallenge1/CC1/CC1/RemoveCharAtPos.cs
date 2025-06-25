using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//C# Program to remove a character at a given posistion

namespace CC1
{
    class RemoveCharAtPos
    {
        static void Main(string[] args)
        {
            string str;
            Console.WriteLine("Enter the string");
            str = Console.ReadLine();
            Console.WriteLine("Enter the position");
            int pos = int.Parse(Console.ReadLine());
            Console.WriteLine("The resultant string is "+str.Remove(pos,1));

            Console.Read();
        }
    }
}

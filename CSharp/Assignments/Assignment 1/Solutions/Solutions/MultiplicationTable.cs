using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions
{
    class MultiplicationTable
    {
        public static void Main()
        {
            Console.WriteLine("Enter number:");
            int num = int.Parse(Console.ReadLine());
            int result;
            for (int i = 1; i <= 10; i++)
            {
                result = i * num;
                Console.WriteLine("{0} *  {1} = {2}", num, i, result);
            }
            Console.ReadLine();
        }
        
    }
}

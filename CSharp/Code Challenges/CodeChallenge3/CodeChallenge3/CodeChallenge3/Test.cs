using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a class Box that has Length and breadth as its members.
//Write a function that adds 2 box objects and stores in the 3rd. 
//Display the 3rd object details. Create a Test class to execute the above.

namespace CodeChallenge3
{

    class  Box
    {
        public int length { get; set; }
        public int breadth { get; set; }


        public Box(int Length, int Breadth)
        {
            length = Length;
            breadth = Breadth;
        }

        public static Box addObj(Box b1,Box b2)
        {
            int fin_len = b1.length + b2.length;
            int fin_breadth = b1.breadth + b2.breadth;
            return new Box(fin_len, fin_breadth);
        }

        public void Display()
        {
           
            Console.WriteLine($"Length : {length}  Breadth : {breadth}");
        }

    }
    class Test
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter length of box 1 : ");
            int length1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter breadth of box 1 : ");
            int breadth1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter length of box 2 : ");
            int length2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter breadth of box 2");
            int breadth2 = int.Parse(Console.ReadLine());

            Box b1 = new Box(length1, breadth1);
            Box b2 = new Box(length2, breadth2);
            Box b3 = Box.addObj(b1, b2);

            Console.WriteLine("***********");
            Console.WriteLine("Dimesions of Box 3");
            b3.Display();
            Console.ReadKey();
        }
    }
}

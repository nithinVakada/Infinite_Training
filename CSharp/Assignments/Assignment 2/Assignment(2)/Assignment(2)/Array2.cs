using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Program to find Total,Average,Minimum Marks,Maximum Marks,
// Displaying marks in Ascending and Descending Order
namespace Assignment_2_
{
    class Array2
    {
        static void Main()
        {
            int[] marks = new int[10];
            int total = 0;
            Console.WriteLine("Enter Marks :");

            for(int i=0;i<10;i++)
            {
                marks[i] = int.Parse(Console.ReadLine());
                total += marks[i];
            }

            //Total Marks
            Console.WriteLine("Total Marks = " + total);

            //Average Marks
            Console.WriteLine("Average Marks = " + (float)total / marks.Length);

            //Minimum and Maximum marks
            int min = MinMax(marks, out int max);
            Console.WriteLine("Minimum marks = {0}", min);
            Console.WriteLine("Maximum marks = {0}", max);

            //Ascending Order
            int[] sorted = Sort(marks);
            Console.WriteLine("Marks in Ascending order :");
            for(int i=0;i<sorted.Length;i++)
            {
                Console.WriteLine(sorted[i]);
            }

            //Marks in Descending order
            Console.WriteLine("Marks in Descending order :");
            for (int i = sorted.Length-1; i>=0; i--)
            {
                Console.WriteLine(sorted[i]);
            }

            Console.ReadLine();
        }

        static int MinMax(int[] marks, out int max)
        {
            int min = int.MaxValue;
            max = int.MinValue;
            for (int i = 0; i < marks.Length; i++)
            {
                if (marks[i] < min)
                    min = marks[i];
                if (marks[i] > max)
                    max = marks[i];
            }

            return min;
        }

        static int[] Sort(int[] marks)
        {
            //using selection sort   87,56,98,21,74
            for(int i=0;i<marks.Length-1;i++)
            {
                int min_index = i;
                for(int j=i+1;j<marks.Length;j++)
                {
                    if(marks[j]<marks[min_index])
                    {
                        min_index = j;
                    }
                }
                int temp = marks[i];
                marks[i] = marks[min_index];
                marks[min_index] = temp;
            }
            return marks;
        }
    }
}

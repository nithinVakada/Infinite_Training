using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Program to copy elements from one Array to other Array
namespace Assignment_2_
{
    class Array3
    {
        static void Main()
        {
            Console.WriteLine("Enter size of the array");
            int size = int.Parse(Console.ReadLine());
            int[] arr_1 = new int[size];

            Console.WriteLine("Enter elements of arr :");
            for(int i=0;i<size;i++)
            {
                arr_1[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Elements of Array_2:");
            int[] arr_2 = Copy(arr_1);
            for(int i=0;i<arr_2.Length;i++)
            {
                Console.WriteLine(arr_2[i]);
            }
            Console.ReadLine();
        }
        static int[] Copy(int[] arr_1)
        {
            int[] arr_2 = new int[arr_1.Length];
            for(int i=0;i<arr_1.Length;i++)
            {
                arr_2[i] = arr_1[i];
            }
            return arr_2;
        }
    }
}

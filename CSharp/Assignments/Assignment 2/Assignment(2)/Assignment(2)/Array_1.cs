using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Program to find Average,Minimum and Maximum in an array

namespace Assignment_2_
{
    class Array_1
    {
        static void Main()
        {
            Console.WriteLine("Enter size of array :");
            int size = int.Parse(Console.ReadLine());
            int[] arr = new int[size];

            //Array initialisation
            Console.WriteLine("Enter elements of array :");
            for (int i = 0; i < size; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }

            //Average of an Array
            float Avg = AvgOfArr(arr);
            Console.WriteLine("Average of array = " + Avg);

            //Finding Min,Max values of the array
            //using out variables
            int min= MinMax(arr, out int max);
            Console.WriteLine("Minimum value of the array = {0}", min);
            Console.WriteLine("Maximum value of the array = {0}", max);



            Console.ReadLine();
        }

        //Finding average of array
        static float AvgOfArr(int[] arr)
        {
            int sum = 0;
            for(int i=0;i<arr.Length;i++)
            {
                sum += arr[i];
            }
            float avg = sum / arr.Length;
            return avg;
        }

        static int MinMax(int[] arr,out int max)
        {
            int min = int.MaxValue;
            max = int.MinValue;
            for(int i=0;i<arr.Length;i++)
            {
                if (arr[i] < min) 
                    min = arr[i];
                if (arr[i] > max)
                    max= arr[i];
            }
            
            return min;
        }
    }
}

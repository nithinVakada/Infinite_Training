using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    
    class Saledetails
    {
        static int SalesNo;
        static int ProductNo;
        static double Price;
        static string DateOfSale;
        static int Qty;
        static double TotalAmount;


        public Saledetails(int salesNo, int productNo, double price, int qty, string dateOfSale)
        {
            SalesNo = salesNo;
            ProductNo = productNo;
            Price = price;
            Qty = qty;
            DateOfSale = dateOfSale;
            Sales(qty,price); 
        }


        public void Sales(int qty, double price)
        {
            TotalAmount = qty * price;
        }


        public static void ShowData()
        {
            Console.WriteLine("\n--- Sale Details ---");
            Console.WriteLine("Sales No      : "+ SalesNo);
            Console.WriteLine("Product No    : "+ ProductNo);
            Console.WriteLine($"Price        : "+ Price);
            Console.WriteLine($"Quantity     : "+ Qty);
            Console.WriteLine($"Date of Sale : "+ DateOfSale);
            Console.WriteLine($"Total Amount : "+ TotalAmount+"/-");
        }

        static void Main()
        {
            Console.Write("Enter Sales No: ");
            int salesNo = int.Parse(Console.ReadLine());

            Console.Write("Enter Product No: ");
            int productNo = int.Parse(Console.ReadLine());

            Console.Write("Enter Price: ");
            double price = double.Parse(Console.ReadLine());

            Console.Write("Enter Quantity: ");
            int qty = int.Parse(Console.ReadLine());

            Console.Write("Enter Date of Sale (dd-mm-yyyy): ");
            string dateOfSale = Console.ReadLine();

            Saledetails sale = new Saledetails(salesNo, productNo, price, qty, dateOfSale);
          
            Saledetails.ShowData();

            Console.Read();
        }
    }

}

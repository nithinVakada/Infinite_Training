using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Create a Class called Products with
//Productid, Product Name, Price.
//Accept 10 Products, sort them based on the price, and display the sorted Products

namespace CodeChallenge2
{
    class Product
    {
          public int ProductId { get; set; }
          public string ProductName { get; set; }
          public int Price { get; set; }

         public void ShowProducts()
        {
            Console.WriteLine("ID : {0} Name : {1} Price : {2}", ProductId, ProductName, Price);
        }
            
    }

    class PriceComparision:IComparer<Product>
    {
        public int Compare(Product first,Product second)
        {
            if (first.Price > second.Price)
                return 1;
            else if (first.Price < second.Price)
                return -1;

                return 0;
        }
    }

    class Program
    {
       

        static void Main()
        {
            List<Product> pr = new List<Product>();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Product {i + 1}");

                Console.WriteLine("Enter Prodct Id : ");
                int id = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter Product Name :");
                string name = Console.ReadLine();

                Console.WriteLine("Enter Prodct Price : ");
                int price = int.Parse(Console.ReadLine());

                pr.Add(new Product { ProductId = id, ProductName = name, Price = price });

            }
                pr.Sort(new  PriceComparision());


                Console.WriteLine("After sorting prices:");
                foreach (Product product in pr)
                {
                    product.ShowProducts();
                }
            Console.Read();

            
        }

    }
}

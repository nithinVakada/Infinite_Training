using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment_7
{
    class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpCity { get; set; }
        public double EmpSalary { get; set; }

        public void Display()
        {
            Console.WriteLine($"ID: {EmpId}, Name: {EmpName}, City: {EmpCity}, Salary: {EmpSalary}");
        }
    }

    class Employee1
    {
        static void Main()
        {
            List<Employee> employees = new List<Employee>();

            Console.Write("Enter no. of employees : ");
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"\nEnter details for Employee {i + 1}:");

                Console.Write("EmpId: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("EmpName: ");
                string name = Console.ReadLine();

                Console.Write("EmpCity: ");
                string city = Console.ReadLine();

                Console.Write("EmpSalary: ");
                double salary = double.Parse(Console.ReadLine());

                employees.Add(new Employee
                {
                    EmpId = id,
                    EmpName = name,
                    EmpCity = city,
                    EmpSalary = salary
                });
            }

            char ch;
            Console.WriteLine();
            do
            {
                Console.WriteLine("\nEnter a character to perform an action:");
                Console.WriteLine("a : Display all employees");
                Console.WriteLine("b : Display employees with salary > 45000");
                Console.WriteLine("c : Display employees from Bangalore");
                Console.WriteLine("d : Display employees sorted by name (ascending)");
                Console.WriteLine("e : Exit");

                Console.Write("Your choice: ");
                ch = char.Parse(Console.ReadLine());

                switch (ch)
                {
                    case 'a':
                        Console.WriteLine("--- All Employees ---");
                        foreach (var emp in employees)
                            emp.Display();
                        break;

                    case 'b':
                        Console.WriteLine("--- Employees with Salary > 45000 ---");
                        foreach (var emp in employees.Where(e => e.EmpSalary > 45000))
                            emp.Display();
                        break;

                    case 'c':
                        Console.WriteLine("--- Employees from Bangalore ---");
                        foreach (var emp in employees.Where(e => e.EmpCity.Equals("Bangalore", StringComparison.OrdinalIgnoreCase)))
                            emp.Display();
                        break;

                    case 'd':
                        Console.WriteLine("--- Employees Sorted by Name (Ascending) ---");
                        foreach (var emp in employees.OrderBy(e => e.EmpName))
                            emp.Display();
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please enter a, b, c, or d.");
                        break;
                }
            } while (ch!='e');
            Console.ReadKey();
        }
    }
}

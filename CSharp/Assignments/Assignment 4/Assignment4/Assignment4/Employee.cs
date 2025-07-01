using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Scenario: Employee Management System(Console - Based)
    ---------------------------------------------------- -
    You are tasked with developing a simple console-based Employee Management System using C# that allows users to manage a list of employees. Use a menu-driven approach to perform CRUD operations on a List<Employee>.

    Each Employee has the following properties:

    int Id

    string Name

    string Department

    double Salary

    Functional Requirements
    Design a menu that repeatedly prompts the user to choose one of the following actions:

    ===== Employee Management Menu =====
    1. Add New Employee
    2. View All Employees
    3. Search Employee by ID
    4. Update Employee Details
    5. Delete Employee
    6. Exit
    ====================================
     */

namespace Assignment4
{
    

    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public double Salary { get; set; }
    }

    class Program
    {
        static List<Employee> employees = new List<Employee>();

        static void Main()
        {
            int choice = 0;
            while (choice != 6)
            {
                Console.WriteLine("\n===== Employee Management Menu =====");
                Console.WriteLine("1. Add New Employee");
                Console.WriteLine("2. View All Employees");
                Console.WriteLine("3. Search Employee by ID");
                Console.WriteLine("4. Update Employee Details");
                Console.WriteLine("5. Delete Employee");
                Console.WriteLine("6. Exit");
                Console.WriteLine("====================================");
                Console.Write("Enter your choice: ");

                string input = Console.ReadLine();
                bool isValid = int.TryParse(input, out choice);

                if (!isValid || choice < 1 || choice > 6)
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 6.");
                    continue;
                }

                switch (choice)
                {
                    case 1: AddEmployee(); break;
                    case 2: ViewEmployees(); break;
                    case 3: SearchEmployee(); break;
                    case 4: UpdateEmployee(); break;
                    case 5: DeleteEmployee(); break;
                    case 6: Console.WriteLine("Exiting..."); break;
                }
            }
        }

        static void AddEmployee()
        {
            Employee emp = new Employee();
            Console.Write("Enter ID: ");
            emp.Id = int.Parse(Console.ReadLine());
            Console.Write("Enter Name: ");
            emp.Name = Console.ReadLine();
            Console.Write("Enter Department: ");
            emp.Department = Console.ReadLine();
            Console.Write("Enter Salary: ");
            emp.Salary = double.Parse(Console.ReadLine());

            employees.Add(emp);
            Console.WriteLine("Employee added successfully.");
        }

        static void ViewEmployees()
        {
            Console.WriteLine("\n--- Employee List ---");
            foreach (Employee emp in employees)
            {
                Console.WriteLine($"ID: {emp.Id}, Name: {emp.Name}, Dept: {emp.Department}, Salary: {emp.Salary}");
            }
        }

        static void SearchEmployee()
        {
            Console.Write("Enter Employee ID to search: ");
            int id = int.Parse(Console.ReadLine());
            Employee found = null;

            foreach (Employee emp in employees)
            {
                if (emp.Id == id)
                {
                    found = emp;
                    break;
                }
            }

            if (found != null)
            {
                Console.WriteLine($"ID: {found.Id}, Name: {found.Name}, Dept: {found.Department}, Salary: {found.Salary}");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }

        static void UpdateEmployee()
        {
            Console.Write("Enter Employee ID to update: ");
            int id = int.Parse(Console.ReadLine());
            Employee found = null;

            foreach (Employee emp in employees)
            {
                if (emp.Id == id)
                {
                    found = emp;
                    break;
                }
            }

            if (found != null)
            {
                Console.Write("Enter New Name: ");
                found.Name = Console.ReadLine();
                Console.Write("Enter New Department: ");
                found.Department = Console.ReadLine();
                Console.Write("Enter New Salary: ");
                found.Salary = double.Parse(Console.ReadLine());
                Console.WriteLine("Employee updated successfully.");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }

        static void DeleteEmployee()
        {
            Console.Write("Enter Employee ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            Employee toRemove = null;

            foreach (Employee emp in employees)
            {
                if (emp.Id == id)
                {
                    toRemove = emp;
                    break;
                }
            }

            if (toRemove != null)
            {
                employees.Remove(toRemove);
                Console.WriteLine("Employee deleted successfully.");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }
    }

}

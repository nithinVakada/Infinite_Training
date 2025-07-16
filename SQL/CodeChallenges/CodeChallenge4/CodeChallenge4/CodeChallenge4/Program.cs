using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeChallenge4
{
    public class employee
    {
        public int employeeid { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string title { get; set; }
        public DateTime dob { get; set; }
        public DateTime doj { get; set; }
        public string city { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<employee> emp_list = new List<employee>
            {
                new employee { employeeid = 1001, firstname = "Malcolm", lastname = "Daruwalla", title = "Manager", dob = DateTime.Parse("1984-11-16"), doj = DateTime.Parse("2011-06-08"), city = "Mumbai" },
                new employee { employeeid = 1002, firstname = "Asdin", lastname = "Dhalla", title = "Asstmanager", dob = DateTime.Parse("1994-08-20"), doj = DateTime.Parse("2012-07-07"), city = "Mumbai" },
                new employee { employeeid = 1003, firstname = "Madhavi", lastname = "Oza", title = "Consultant", dob = DateTime.Parse("1987-11-14"), doj = DateTime.Parse("2015-04-12"), city = "Pune" },
                new employee { employeeid = 1004, firstname = "Saba", lastname = "Shaikh", title = "SE", dob = DateTime.Parse("1990-06-03"), doj = DateTime.Parse("2016-02-02"), city = "Pune" },
                new employee { employeeid = 1005, firstname = "Nazia", lastname = "Shaikh", title = "SE", dob = DateTime.Parse("1991-03-08"), doj = DateTime.Parse("2016-02-02"), city = "Mumbai" },
                new employee { employeeid = 1006, firstname = "Amit", lastname = "Pathak", title = "Consultant", dob = DateTime.Parse("1989-11-07"), doj = DateTime.Parse("2014-08-08"), city = "Chennai" },
                new employee { employeeid = 1007, firstname = "Vijay", lastname = "Natrajan", title = "Consultant", dob = DateTime.Parse("1989-12-02"), doj = DateTime.Parse("2015-06-01"), city = "Mumbai" },
                new employee { employeeid = 1008, firstname = "Rahul", lastname = "Dubey", title = "Associate", dob = DateTime.Parse("1993-11-11"), doj = DateTime.Parse("2014-11-06"), city = "Chennai" },
                new employee { employeeid = 1009, firstname = "Suresh", lastname = "Mistry", title = "Associate", dob = DateTime.Parse("1992-08-12"), doj = DateTime.Parse("2014-12-03"), city = "Chennai" },
                new employee { employeeid = 1010, firstname = "Sumit", lastname = "Shah", title = "Manager", dob = DateTime.Parse("1991-04-12"), doj = DateTime.Parse("2016-01-02"), city = "Pune" }
            };

            Console.WriteLine("All Employees:");
            foreach (var emp in emp_list)
                display(emp);

            Console.WriteLine("\nEmployees not in Mumbai:");
            foreach (var emp in emp_list.Where(e => e.city != "Mumbai"))
                display(emp);

            Console.WriteLine("\nEmployees with title 'Asstmanager':");
            foreach (var emp in emp_list.Where(e => e.title == "Asstmanager"))
                display(emp);

            Console.WriteLine("\nEmployees whose last name starts with 'S':");
            foreach (var emp in emp_list.Where(e => e.lastname.StartsWith("S")))
                display(emp);
            Console.ReadKey();
        }

        static void display(employee emp)
        {
            Console.WriteLine($"ID: {emp.employeeid}, Name: {emp.firstname} {emp.lastname}, Title: {emp.title}, DOB: {emp.dob:dd-MM-yyyy}, DOJ: {emp.doj:dd-MM-yyyy}, City: {emp.city}");
        }

    }
}

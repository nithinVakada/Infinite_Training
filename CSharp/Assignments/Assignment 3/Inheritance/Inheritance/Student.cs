using System;

namespace Inheritance
{
    class Student
    {
        int rollNo;
        string name;
        string studentClass;
        int semester;
        string branch;
        int[] marks = new int[5];

        // Constructor
        public Student(int r, string n, string c, int s, string b)
        {
            rollNo = r;
            name = n;
            studentClass = c;
            semester = s;
            branch = b;
        }

        // Method to input marks
        public void GetMarks()
        {
            Console.WriteLine("Enter marks for 5 subjects:");
            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Subject {i + 1}: ");
                marks[i] = int.Parse(Console.ReadLine());
            }
        }

        // Method to calculate and display result
        public void DisplayResult()
        {
            int total = 0;
            bool hasFailedSubject = false;

            for (int i = 0; i < 5; i++)
            {
                total += marks[i];
                if (marks[i] < 35)
                {
                    hasFailedSubject = true;
                }
            }

            float average = total / 5.0f;

            Console.WriteLine("\n--- Result ---");
            if (hasFailedSubject)
            {
                Console.WriteLine("Result: Failed (One or more subjects below 35)");
            }
            else if (average < 50)
            {
                Console.WriteLine($"Average Marks: {average:F2}");
                Console.WriteLine("Result: Failed (Average below 50)");
            }
            else
            {
                Console.WriteLine($"Average Marks: {average:F2}");
                Console.WriteLine("Result: Passed");
            }
        }

        // Method to display student details
        public void DisplayData()
        {
            Console.WriteLine("\n--- Student Details ---");
            Console.WriteLine("Roll No     : "+ rollNo);
            Console.WriteLine("Name        : "+ name);
            Console.WriteLine("Class       : "+ studentClass);
            Console.WriteLine("Semester    : "+ semester);
            Console.WriteLine("Branch      : "+ branch);
            //Console.WriteLine("Marks       : " + string.Join(", ", marks));
            Console.WriteLine("Marks :");
            for(int i=0;i<5;i++)
            {
                Console.Write("{0} " ,marks[i]);
            }
        }
    }

    class Origin
    {
        static void Main()
        {
            Console.Write("Enter Roll No: ");
            int rollNo = int.Parse(Console.ReadLine());

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Class: ");
            string studentClass = Console.ReadLine();

            Console.Write("Enter Semester: ");
            int semester = int.Parse(Console.ReadLine());

            Console.Write("Enter Branch: ");
            string branch = Console.ReadLine();

            Student student = new Student(rollNo, name, studentClass, semester, branch);
            student.GetMarks();
            student.DisplayData();
            student.DisplayResult();
            Console.Read();
        }
    }
}

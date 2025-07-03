using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Create an Abstract class Student with  Name, StudentId, Grade as members and also an abstract method Boolean Ispassed(grade) which takes grade as an input and checks whether student passed the course or not.  

//Create 2 Sub classes Undergraduate and Graduate that inherits all members of the student
//and overrides Ispassed(grade) method

//For the UnderGrad class, if the grade is above 70.0, then isPassed returns true,
//otherwise it returns false. For the Grad class, if the grade is above 80.0, then isPassed returns true, otherwise returns false.
 
//Test the above by creating appropriate objects

namespace CodeChallenge2
{
    abstract class Student
    {
        public string Name { get; set; }
        public int StudentID { get; set; }
        public float grade { get; set; }

        public abstract bool IsPassed(float grade);
    }

    class UnderGraduate: Student
    {
        public override bool IsPassed(float grade)
        {
            if (grade >= 70.0)
                return true;
            return false;
        }
    }

    class Graduate : Student
    {
        public override bool IsPassed(float grade)
        {
            if (grade >= 80.0)
                return true;
            return false;
        }
    }

    class Verifying
    {
        public static void Main()
        {
            int choice;
            do
            {
                Console.WriteLine("Enter details of Student :");

                Console.WriteLine("Enter Student Type \n 1: UnderGraduate \n 2:Graduate");
                int type = int.Parse(Console.ReadLine());

                Student st;
                if (type == 1)
                {
                    st = new UnderGraduate();
                }
                else if (type == 2)
                {
                    st = new Graduate();
                }
                else
                {
                    Console.WriteLine("Invalid Student Type..");
                    Console.Read();
                    return;
                }

                Console.WriteLine("Enter Student Id : ");
                int id = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter Student Name : ");
                string name = Console.ReadLine();

                Console.WriteLine("Enter Student Grade : ");
                float grade = float.Parse(Console.ReadLine());

                st.Name = name;
                st.StudentID = id;
                st.grade = grade;

                Console.WriteLine($"Student ID : {st.StudentID}\n " +
                    $"Student Name : {st.Name}\n Student grade : {st.grade}");

                bool result = st.IsPassed(st.grade);

                if (result)
                    Console.WriteLine("Result : Passed ");

                else
                    Console.WriteLine("Result : Failed");

                Console.WriteLine("---------------------");

                Console.WriteLine("Enter choice : \n 1.Continue \n 2.Exit");
                choice=int.Parse(Console.ReadLine());

            } while (choice!=2);
            //Console.WriteLine("Enter details of Student :");

            //Console.WriteLine("Enter Student Type \n 1: UnderGraduate \n 2:Graduate");
            //int type = int.Parse(Console.ReadLine());
            
            //Student st;
            //if(type==1)
            //{
            //    st = new UnderGraduate();
            //}
            //else if(type ==2 )
            //{
            //    st = new Graduate();
            //}
            //else
            //{
            //    Console.WriteLine("Invalid Student Type..");
            //    Console.Read();
            //    return;
            //}

            //Console.WriteLine("Enter Student Id : ");
            //int id = int.Parse(Console.ReadLine());

            //Console.WriteLine("Enter Student Name : ");
            //string name = Console.ReadLine();

            //Console.WriteLine("Enter Student Grade : ");
            //float grade = float.Parse(Console.ReadLine());

            //st.Name = name;
            //st.StudentID = id;
            //st.grade = grade;

            //Console.WriteLine($"Student ID : {st.StudentID}\n " +
            //    $"Student Name : {st.Name}\n Student grade : {st.grade}");

            //bool result = st.IsPassed(st.grade);

            //if (result)
            //    Console.WriteLine("Result : Passed ");

            //else
            //    Console.WriteLine("Result : Failed");

            //Console.Read();

        }
    }
}
